using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Wallet.App.BillDetails;
using Wallet.App.PaymentTypeCategories;

namespace Wallet.App.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AppDbContext :
    AbpDbContext<AppDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules
    public DbSet<BillDetail> BillDetails { get; set; } = null!;
    public DbSet<PaymentTypeCategory> PaymentTypeCategories { get; set; } = null!;

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureOpenIddict();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AppConsts.DbTablePrefix + "YourEntities", AppConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentTypeCategory>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "PaymentTypeCategories", AppConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.CategoryName).HasColumnName(nameof(PaymentTypeCategory.CategoryName)).IsRequired().HasMaxLength(PaymentTypeCategoryConsts.CategoryNameMaxLength);
                b.Property(x => x.Status).HasColumnName(nameof(PaymentTypeCategory.Status));
                b.Property(x => x.Description).HasColumnName(nameof(PaymentTypeCategory.Description)).IsRequired().HasMaxLength(PaymentTypeCategoryConsts.DescriptionMaxLength);
                b.Property(x => x.LastModifiercationTime).HasColumnName(nameof(PaymentTypeCategory.LastModifiercationTime));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<BillDetail>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "BillDetails", AppConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Money).HasColumnName(nameof(BillDetail.Money));
                b.Property(x => x.Note).HasColumnName(nameof(BillDetail.Note)).IsRequired().HasMaxLength(BillDetailConsts.NoteMaxLength);
                b.Property(x => x.CreatedAt).HasColumnName(nameof(BillDetail.CreatedAt));
                b.HasOne<PaymentTypeCategory>().WithMany().IsRequired().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
                b.HasOne<IdentityUser>().WithMany().IsRequired().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            });

        }
    }
}
