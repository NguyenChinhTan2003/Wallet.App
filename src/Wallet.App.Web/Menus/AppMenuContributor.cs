using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Wallet.App.Localization;
using Wallet.App.Permissions;
using Wallet.App.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Wallet.App.Web.Menus;

public class AppMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AppResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                AppMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);


        context.Menu.AddItem(
            new ApplicationMenuItem(
                AppMenus.PaymentTypeCategories,
                l["Menu:PaymentTypeCategories"],
                url: "/PaymentTypeCategories",
icon: "fa fa-file-alt",
                requiredPermissionName: AppPermissions.PaymentTypeCategories.Default)
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                AppMenus.BillDetails,
                l["Menu:BillDetails"],
                url: "/BillDetails",
icon: "fa fa-file-alt",
                requiredPermissionName: AppPermissions.BillDetails.Default)
        );
        return Task.CompletedTask;
    }
}