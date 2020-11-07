using ADV.OrdersProducts.Mapping;
using ADV.OrdersProducts.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADV.OrdersProducts.Service.Tests
{
    [TestClass()]
    public class ServiceHomeTests
    {
        ServiceHome service;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<DataContextApp>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var ctx = new DataContextApp(options);

            for (int i = 0; i < 100; i++)
            {
                ctx.Products.Add(new Product()
                {
                    Price = i * 10,
                    ProductName = "ProductName #" + i,
                    Qty = i,

                });
                ctx.SaveChanges();
            }

            for (int i = 0; i < 10; i++)
            {
                ctx.Orders.Add(new Order()
                {
                    DateCreate = DateTime.Now.AddDays(i * (-1)),
                    OrderName = "Order №" + i,
                    Status = i % 2 == 0 ? Status.Complete : Status.Inprogress,
                });
            }
            ctx.SaveChanges();

            var orders = ctx.Orders.ToList();
            var product = ctx.Products.ToList();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ctx.Add(new OrdersProducts.Model.OrdersProducts()
                    {
                        Order = orders[i],
                        Product = product[j],
                    });
                    ctx.SaveChanges();
                }
            }

            var _mapper = new Mapper(new MapperConfiguration(c => { c.AddProfile<Mappings>(); }));
            service = new ServiceHome(ctx, _mapper);
        }

        [DataRow(1)]
        [DataRow(6)]
        [DataRow(4)]
        [TestMethod()]
        public void GetDatailsOrderAsyncTest(int IdOrder)
        {
            var datailOrder = service.GetDatailsOrderAsync(IdOrder).Result;

            Assert.IsNotNull(datailOrder);
        }

        [TestMethod()]
        public void GetOrdersAsyncTest()
        {
            var orders = service.GetOrdersAsync().Result;

            Assert.IsTrue(orders.Count > 0);
        }

        [DataRow(1)]
        [DataRow(6)]
        [DataRow(4)]
        [TestMethod()]
        public void GetProductsAsyncTest(int IdOrder)
        {
            var products = service.GetProductsAsync(IdOrder).Result;

            Assert.IsTrue(products.Count > 0);
        }
    }
}