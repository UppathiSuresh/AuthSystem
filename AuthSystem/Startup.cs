using AuthSystem.Models;
using DrinkAndGo.Data;
using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Mocks;
using DrinkAndGo.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem
{
    public class Startup
    {

        private IConfigurationRoot _configurationRoot;
        //public Startup(IHostingEnvironment hostingEnvironment)
        //{
        //    _configurationRoot = new ConfigurationBuilder()
        //        .SetBasePath(hostingEnvironment.ContentRootPath)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransactionDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "36482779104-g8m701kdsiao4mqe96lh1dm0g13d76ea.apps.googleusercontent.com";
                options.ClientSecret = "qHEEEkKhcIwjGcnzCrq38EEJ";
            });





            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //Authentication, Identity config
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddTransient<IDrinkRepository, MockDrinkRepository>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ////services.AddScoped(sp => ShoppingCart.GetCart(sp));
            //services.AddTransient<IOrderRepository, OrderRepository>();

            //services.AddMvc();
            //services.AddMemoryCache();
            //services.AddSession();






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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });



            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //       name: "drinkdetails",
            //       template: "Drink/Details/{drinkId?}",
            //       defaults: new { Controller = "Drink", action = "Details" });

            //    routes.MapRoute(
            //        name: "categoryfilter",
            //        template: "Drink/{action}/{category?}",
            //        defaults: new { Controller = "Drink", action = "List" });

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{Id?}");
            //});

            //DbInitializer.Seed(app);
        }
    }
}
