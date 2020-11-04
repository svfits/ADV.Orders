using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.OrdersProducts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using ADV.Orders.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ADV.OrdersProducts.Mapping;

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
                ctx.Orders.Add(new Order()
                {
                    DateCreate = DateTime.Now.AddDays(i * (-1)),
                    OrderName = "Order №" + i,
                    Status = i % 2 == 0 ? Status.Complete : Status.Inprogress,
                    Product = product,
                });
            }

            ctx.SaveChanges();

            var _mapper = new Mapper(new MapperConfiguration(c => { c.AddProfile<Mappings>(); }));
            service = new ServiceHome(ctx, _mapper);
        }

        [TestMethod()]
        public void GetDatailsOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOrdersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetProductsTest()
        {
            Assert.Fail();
        }
    }
}