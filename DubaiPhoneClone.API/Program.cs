
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Application.services.Brands;
using DubaiPhoneClone.Application.services.cartitems;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Application.services.product;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Infrastructure.Repositories;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DubaiPhoneClone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            var connection = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<ApplicationContext>(option =>
                option.UseSqlServer(connection));

            //Account
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            //        ValidateAudience = true,
            //        ValidAudience = builder.Configuration["JWT:ValidAudiance"],
            //        IssuerSigningKey =
            //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
            //    };
            //});

            //builder.Services.AddCors(corsOptions =>
            //{
            //    corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
            //    {
            //        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //    });
            //});

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProuductService, productServices>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandServices, BrandService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICartIemServices, CartIemServices>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            //app.UseAuthentication();//Check JWT token

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
