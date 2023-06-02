using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using ApiDemo.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ApiDemo.EntityFrameworkCore;

// [ReplaceDbContext(typeof(IIdentityDbContext))]
// [ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ApiDemoDbContext :
    AbpDbContext<ApiDemoDbContext>
// IIdentityDbContext,
// ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    // public DbSet<IdentityUser> Users { get; set; }
    // public DbSet<IdentityRole> Roles { get; set; }
    // public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    // public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    // public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    // public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // // Tenant Management
    // public DbSet<Tenant> Tenants { get; set; }
    // public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<ReadingPackage> ReadingPackages { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserReadingPackage> UserReadingPackages { get; set; }

    public DbSet<UserHistory> UserHistories { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<BookWithAuthor> BookWithAuthors { get; set; }

    public DbSet<BookWithCategory> BookWithCategories { get; set; }

    public DbSet<UserLibrary> UserLibraries { get; set; }

    public DbSet<Reminder> Reminders { get; set; }

    public DbSet<Highlight> Highlights { get; set; }

    public ApiDemoDbContext(DbContextOptions<ApiDemoDbContext> options)
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
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ApiDemoConsts.DbTablePrefix + "YourEntities", ApiDemoConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<ReadingPackage>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "ReadingPackages",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasMany<UserReadingPackage>()
                .WithOne()
                .HasForeignKey(p => p.ReadingPackageId);
        });

        builder.Entity<User>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Users",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasMany<UserReadingPackage>(u => u.Packages)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            b.HasMany<UserHistory>(u => u.Histories)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            b.HasMany<UserLibrary>(u => u.UserLibraries)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            b.HasMany<Highlight>(u => u.Highlights)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            b.HasMany<Reminder>(u => u.Reminders)
                .WithOne()
                .HasForeignKey(p => p.UserId);

            b.Ignore(p => p.CurrentPackage);

            b.Ignore(p => p.RecentlyHistories);

            b.Ignore(p => p.TotalReadingTime);

            b.Ignore(p => p.TotalReadingBooks);

            b.Ignore(p => p.Ranking);
        });

        builder.Entity<UserReadingPackage>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "UserReadingPackages",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<UserHistory>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "UserHistories",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<Author>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Authors",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(AuthorConsts.MaxNameLength);

            b.HasIndex(x => x.Name);

            b.HasMany<BookWithAuthor>()
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);
        });

        builder.Entity<Category>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Categories",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasMany<BookWithCategory>()
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        });

        builder.Entity<Book>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Books",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasMany<BookWithAuthor>(u => u.BookWithAuthors)
                .WithOne()
                .HasForeignKey(p => p.BookId);

            b.HasMany<BookWithCategory>(u => u.BookWithCategories
            )
                .WithOne()
                .HasForeignKey(p => p.BookId);

            b.HasMany<UserLibrary>(x => x.UserLibraries)
                .WithOne()
                .HasForeignKey(p => p.BookId);

            b.HasMany<Highlight>()
                .WithOne(h => h.Book)
                .HasForeignKey(p => p.BookId);
        });

        builder.Entity<BookWithAuthor>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "BookWithAuthors",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<BookWithCategory>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "BookWithCategories",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<UserLibrary>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "UserLibraries",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<Highlight>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Highlights",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });

        builder.Entity<Reminder>(b =>
        {
            b.ToTable(ApiDemoConsts.DbTablePrefix + "Reminders",
                ApiDemoConsts.DbSchema);

            b.ConfigureByConvention();
        });
    }
}
