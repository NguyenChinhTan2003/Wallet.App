using Wallet.App.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Wallet.App.Permissions;

public class AppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AppPermissions.GroupName);


        //Define your own permissions here. Example:
        //myGroup.AddPermission(AppPermissions.MyPermission1, L("Permission:MyPermission1"));

        var paymentTypeCategoryPermission = myGroup.AddPermission(AppPermissions.PaymentTypeCategories.Default, L("Permission:PaymentTypeCategories"));
        paymentTypeCategoryPermission.AddChild(AppPermissions.PaymentTypeCategories.Create, L("Permission:Create"));
        paymentTypeCategoryPermission.AddChild(AppPermissions.PaymentTypeCategories.Edit, L("Permission:Edit"));
        paymentTypeCategoryPermission.AddChild(AppPermissions.PaymentTypeCategories.Delete, L("Permission:Delete"));

        var billDetailPermission = myGroup.AddPermission(AppPermissions.BillDetails.Default, L("Permission:BillDetails"));
        billDetailPermission.AddChild(AppPermissions.BillDetails.Create, L("Permission:Create"));
        billDetailPermission.AddChild(AppPermissions.BillDetails.Edit, L("Permission:Edit"));
        billDetailPermission.AddChild(AppPermissions.BillDetails.Delete, L("Permission:Delete"));
        billDetailPermission.AddChild(AppPermissions.BillDetails.ViewTotalBalance, L("Permission:ViewTotalBalance"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AppResource>(name);
    }
}