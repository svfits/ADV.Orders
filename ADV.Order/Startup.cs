using ADV.OrdersProducts.Interfaces;
using ADV.OrdersProducts.Mapping;
using ADV.OrdersProducts.Model;
using ADV.OrdersProducts.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADV.Orders
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
            ///��� ������� ����� ������������ ����� ��
            services.AddDbContext<DataContextApp>(options => options.UseInMemoryDatabase(databaseName: "DB"));

            services.AddScoped<IServicesHome, ServiceHome>();

            services.AddAutoMapper(typeof(Mappings));

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            AddDataForAPI(serviceProvider);
        }

        readonly Random Random = new Random();

        /// <summary>
        /// ���������� ������
        /// ��� ��� ������ ��� ������� 
        /// � ��� ����� ������� � midleware 
        /// </summary>
        /// <param name="serviceProvider"></param>
        private void AddDataForAPI(IServiceProvider serviceProvider)
        {
            var ctx = serviceProvider.GetRequiredService<DataContextApp>();

            for (int i = 0; i < 100; i++)
            {
                ctx.Products.Add(new Product()
                {
                    Price = Random.Next(1, 19),
                    ProductName = "ProductName #" + i,
                    Qty = i == 0 ? 9 : i,

                });
                ctx.SaveChanges();
            }

            for (int i = 0; i < 10; i++)
            {
                ctx.Orders.Add(new Order()
                {
                    DateCreate = DateTime.Now.AddDays(i * (-1)),
                    OrderName = "Order �" + i,
                    Status = i % 3 == 0 ? Status.Complete : Status.Inprogress,
                });
                ctx.SaveChanges();
            }

            var orders = ctx.Orders.ToList();
            var product = ctx.Products.Distinct().ToList();          

            for (int i = 0; i < 10; i++)
            {
                //    //var tt = 
                for (int j = 0; j < 10; j++)
                {
                    ctx.Add(new OrdersProducts.Model.OrdersProducts()
                    {
                        Order = orders[j],
                        Product = product[Random.Next(0, 99)],
                    });
                }
            }
            ctx.SaveChanges();
        }
    }
}
