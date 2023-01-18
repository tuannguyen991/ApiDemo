using System;
using System.Linq;
using ApiDemo.Books;
using ApiDemo.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ApiDemo.EntityFrameworkCore;

[DependsOn(
    typeof(ApiDemoDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class ApiDemoEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        ApiDemoEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ApiDemoDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also ApiDemoMigrationsDbContextFactory for EF Core tooling. */
            options.UseNpgsql();
        });

        // Config Load Related Entity
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<User>(o =>
            {
                var daysRecently = DateTime.Now.Subtract(TimeSpan.FromDays(10));

                o.DefaultWithDetailsFunc = query => query
                                            .Include(
                                                o => o.Packages
                                                    .OrderBy(package => package.StartDate)
                                            )
                                            .Include(
                                                o => o.Histories
                                                    .OrderBy(userHistory => userHistory.Date)
                                            )
                                            .Include(
                                                o => o.UserLibraries
                                                    .OrderBy(userLibrary => userLibrary.LastRead)
                                            )
                                            .Include(
                                                o => o.Highlights
                                                    .OrderByDescending(highlight => highlight.Date)
                                            );
            });

            options.Entity<Book>(o =>
            {
                o.DefaultWithDetailsFunc = query => query
                                            .Include(o => o.Authors)
                                                .ThenInclude(e => e.Author)
                                            .Include(o => o.Categories)
                                                .ThenInclude(e => e.Category);
            });
        });
    }
}
