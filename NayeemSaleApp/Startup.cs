using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using NayeemSaleApp.Data;
using NayeemSaleApp.Data.Entity;
using NayeemSaleApp.Services.AuthService;
using NayeemSaleApp.Services.AuthService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NayeemSaleApp.Services.MasterDataServiceInformation;
using NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces;
using NayeemSaleApp.Services.SaleRecordServiceInformation.Interfaces;
using NayeemSaleApp.Services.SaleRecordServiceInformation;
using NayeemSaleApp.Services.PaymentRecordServiceInformation.Interfaces;
using NayeemSaleApp.Services.PaymentRecordServiceInformation;

namespace NayeemSaleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();

            #region App Database Settings
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));


            services.AddMemoryCache();
            //.AddDefaultTokenProviders();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ERPDbContext>();
            #endregion


            #region Auth Related Settings
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;


            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);

                options.LoginPath = "/Auth/Account/Login";
                options.AccessDeniedPath = "/Auth/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion


            #region Areas Config
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

            });
            #endregion

            #region UserService
            services.AddScoped<IUserInfoes, UserInfoes>();
            #endregion



            #region SaleRecordService
            services.AddScoped<ISaleRecordService, SaleRecordService>();
            #endregion
            #region ProductService
            services.AddScoped<IProductService, ProductService>();
            #endregion
            #region CustomerService
            services.AddScoped<ICustomerService, CustomerService>();
            #endregion
            #region PaymentRecordService
            services.AddScoped<IPaymentRecordService, PaymentRecordService>();
            #endregion
            #region PDF
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions
                   .PropertyNamingPolicy = null;
             });


            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseMvc(routes => {
                routes.MapRoute(
                name: "MyArea",
                template: "{area=Auth}/{controller=Account}/{action=Login}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
