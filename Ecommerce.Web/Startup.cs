using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service;
using Ecommerce.Service.Interface;
using Ecommerce.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Web
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
            services.AddDbContext<EcommerceDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


            ConfigureCoreAndRepositoryService(services);
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
            }
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
        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IServices<>), typeof(EcommerceServices<>));

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartServices, CartService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductSevice, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISupplierServices, SupplierService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<ICartDetailsServices, CartDetailsServices>();
            services.AddScoped<ICartDetailsRepository, CartDetailsRepository>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserProfileService, UserProfileService>();
        }
    }
}
