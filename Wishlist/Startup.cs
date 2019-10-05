using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wishlist.Identity;
using Wishlist.Models;

namespace Wishlist
{
    public class Startup
    {
        public const string IS_ADMIN_AUTH_POLICY = "IsAdmin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var cosmosDbConfig = Configuration.GetSection("CosmosDb");
            var cosmosDbClient = InitializeCosmosDbClient(cosmosDbConfig);

            services.AddAuthentication();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    IS_ADMIN_AUTH_POLICY,
                    policy => policy.RequireClaim("IsAdmin"));
            });

            var builder = services.AddIdentity<ApplicationUser, ApplicationRole>();
            services.AddSingleton(
                typeof(IUserStore<>).MakeGenericType(builder.UserType),
                InitializeCosmosDbUserStore(cosmosDbClient, cosmosDbConfig));
            services.AddSingleton(
                typeof(IRoleStore<>).MakeGenericType(builder.RoleType),
                typeof(CosmosDbRoleStore));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(InitializeWishServiceAsync(cosmosDbClient, cosmosDbConfig));
        }

        private static CosmosDbUserStore InitializeCosmosDbUserStore(CosmosClient client, IConfigurationSection config)
        {
            return new CosmosDbUserStore(
                client,
                config.GetSection("DatabaseName").Value,
                config.GetSection("UsersContainerName").Value);
        }

        private static CosmosClient InitializeCosmosDbClient(IConfigurationSection config)
        {
            var clientBuilder = new CosmosClientBuilder(
                config.GetSection("Account").Value,
                config.GetSection("Key").Value);
            return clientBuilder.WithConnectionModeDirect().Build();
        }

        private static IWishService InitializeWishServiceAsync(CosmosClient client, IConfigurationSection config)
        {
            return new WishService(
                client,
                config.GetSection("DatabaseName").Value,
                config.GetSection("WishesContainerName").Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Wishes}/{action=Index}/{id?}");
            });
        }
    }
}
