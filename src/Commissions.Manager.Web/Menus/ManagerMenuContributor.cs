using System.Threading.Tasks;
using Commissions.Manager.Localization;
using Commissions.Manager.Permissions;
using Commissions.Manager.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace Commissions.Manager.Web.Menus;

public class ManagerMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<ManagerResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ManagerMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        // Employees
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Employees", 
                l["Menu:Employees"],
                url: "/Employees",
                icon: "fa fa-person",
                order: 2
            )
        );

        // Commissions
            context.Menu.AddItem(
            new ApplicationMenuItem(
                "Commissions",
                l["Menu:Commissions"],
                url: "/Commissions",
                icon: "fas fa-percentage"
            )
        );

        // Customers
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Customers",
                l["Menu:Customers"],
                url: "/Customers",
                icon: "fa fa-person",
                order: 3
            )
        );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);
        
        return Task.CompletedTask;
    }
}
