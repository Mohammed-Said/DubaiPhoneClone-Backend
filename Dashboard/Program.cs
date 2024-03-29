using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Application.services.Brands;
<<<<<<< HEAD
using DubaiPhoneClone.Application.services.Categorys;
=======
>>>>>>> b1898cd8587e26f1f277c3a2a4193e4884e8d05a
using DubaiPhoneClone.Application.services.product;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<ApplicationContext>(option =>
                option.UseSqlServer(connection));


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProuductService, productServices>();
<<<<<<< HEAD
            builder.Services.AddScoped<ICategoryServices , CategoryServices>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>(); 
            builder.Services.AddScoped<IBrandServices , BrandService>();
            builder.Services.AddScoped<IBrandRepository , BrandRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandServices, BrandService>();
=======
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandServices, BrandService>();
>>>>>>> b1898cd8587e26f1f277c3a2a4193e4884e8d05a
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
