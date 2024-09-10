using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using System.Linq;
using static Volo.Abp.Identity.IdentityPermissions;

namespace Wallet.App.Web.Controllers
{
    public class UserAuthenController : AbpControllerBase
    {
        private readonly IdentityUserManager _userManager;
        private readonly IOptionsMonitor<OpenIddictServerOptions> _oidcOptions;


        public UserAuthenController(IdentityUserManager userManager, IOptionsMonitor<OpenIddictServerOptions> oidcOptions)
        {
            _userManager = userManager;
            _oidcOptions = oidcOptions;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<UserLoginDto> Login([FromBody] UserLoginInput loginDto)
        {
            UserLoginDto result = new UserLoginDto();
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                result.IsSucess = false;
                result.Message = "Sai tên truy cập hoặc mặt khẩu";
                return result;
            }
            var checkPass = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (checkPass)
            {
                result.IsSucess = false;
                result.Message = "Sai tên truy cập hoặc mặt khẩu";
                return result;
            }

            var token = await GenerateJwtToken(user);
            result.IsSucess = true;
            result.AccessToken = token;
            // Trả về token
            return result;
        }
        private async Task<string> GenerateJwtToken(Volo.Abp.Identity.IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("given_name", user.UserName),
                new Claim("email", user.Email),
                new Claim("tenantid", user.TenantId?.ToString() ?? ""),
                new Claim("scope", "address email phone roles profile offline_access Qa") //replace Qa with yours
            };

            claims.AddRange(roles.Select(role => new Claim("role", role)));
            var options = _oidcOptions.CurrentValue;
            var descriptor = new SecurityTokenDescriptor
            {
                Audience = "Qa", // replace with yours,
                EncryptingCredentials = options.DisableAccessTokenEncryption
                    ? null
                    : options.EncryptionCredentials.First(),
                Expires = null,
                Subject = new ClaimsIdentity(claims, TokenValidationParameters.DefaultAuthenticationType),
                IssuedAt = DateTime.UtcNow,
                Issuer = "https://localhost:44388/", // replace with yours,
                SigningCredentials = options.SigningCredentials.First(),
                TokenType = OpenIddictConstants.JsonWebTokenTypes.AccessToken,
            };

            var accessToken = options.JsonWebTokenHandler.CreateToken(descriptor);

            return accessToken;
        }
    }
}