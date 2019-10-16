using ds.NorthwindApp.Model;
using ds.NorthwindApp.Model.Interface;
using ds.NorthwindApp.Model.Repository;
using ds.NorthwindApp.Service;
using ds.NorthwindApp.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ds.NorthwindApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // DB Context
            services.AddDbContext<NorthwindContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("northwind"))
            );

            // Repository
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<ISupplierRepository, SupplierRepository>();

            // Service
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISupplierService, SupplierService>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}