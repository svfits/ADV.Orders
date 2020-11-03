using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADV.Orders.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            ///Тут конечно можно использовать любую БД
            services.AddDbContext<DataContextApp>(options => options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        /// <summary>
        /// Добавление данных для работы API
        /// </summary>
        /// <param name="serviceProvider"></param>
        private void AddDataForAPI(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<DataContextApp>();

            var product = new List<Product>();
            for (int i = 0; i < 7; i++)
            {
                product.Add(new Product()
                {
                    Price = 100,
                    ProductName = "ProductName #" + i,
                    Qty = i,
                });
            }

            for (int i = 0; i < 10; i++)
            {
                db.Orders.Add(new Order()
                {
                    DateCreate = DateTime.Now.AddDays(i * (-1)),
                    NumberOrder = "Order №" + i,
                    Status = i % 2 == 0 ? Status.Complete : Status.Inprogress,
                    Product = product,
                });
            }

            db.SaveChanges();
        }
    }
}
