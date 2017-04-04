using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebCourse.Models;
using WebCourse.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebCourse
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json");

            configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<MyIdentityDbContext>(options =>
                options.UseNpgsql(configuration["DbConnectionString"]));

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.User.RequireUniqueEmail = true;
                opts.SignIn.RequireConfirmedEmail = true;
                opts.User.AllowedUserNameCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ@.";
            }).AddEntityFrameworkStores<MyIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration["DbConnectionString"]));

            services.AddTransient<ICompanyRepository, EFCompanyRepository>();
            services.AddTransient<INewsRepository, EFNewsRepository>();
            services.AddTransient<IInnovativeProductRepository, EFInnovativeProductRepository>();
            services.AddTransient<ICertificateRepository, EFCertificateRepository>();
            services.AddTransient<ILicenseRepository, EFLicenseRepository>();
            
            services.AddTransient<ICommentRepository, EFCommentRepository>();

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseSession();
            app.UseIdentity();

            app.UseVkontakteAuthentication(new AspNetCore.Security.OAuth.Vkontakte.VkontakteAuthenticationOptions {
                ClientId = configuration["VAppId"],
                ClientSecret = configuration["VSecureKey"],
                Scope = { "email" },
                Fields = { "first_name", "last_name", "email" }
            });

            app.UseFacebookAuthentication(new FacebookOptions {
                AppId = configuration["FAppId"],
                AppSecret = configuration["FAppSecret"],
                Scope = { "email" },
                Fields = { "name", "email" },
                SaveTokens = true,
            });

            app.UseGoogleAuthentication(new GoogleOptions {
                ClientId = configuration["GClientId"],
                ClientSecret = configuration["GClientSecret"]
            });


            app.UseMvc(routes =>{
                routes.MapRoute(
                    name: "",
                    template: "News/Edit/{id}",
                    defaults: new {controller = "News", action="Edit"}
                );
                routes.MapRoute(
                    name:"",
                    template: "Product/Edit/{id}",
                    defaults: new {controller = "Product", action="Edit"}
                );
                routes.MapRoute(
                    name:"",
                    template: "Product/{id}",
                    defaults: new {controller = "Product", action = "Product"}
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            SeedData.AddValues(app);
            SeedData.CreateAdminAcc(app.ApplicationServices, configuration).Wait();
        }
    }
}
