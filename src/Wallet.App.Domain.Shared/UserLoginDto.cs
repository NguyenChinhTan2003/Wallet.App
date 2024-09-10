using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.App
{
    public class UserLoginDto
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
    }
}
