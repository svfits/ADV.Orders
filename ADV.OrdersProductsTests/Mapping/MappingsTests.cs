using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADV.OrdersProducts.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ADV.OrdersProducts.Mapping.Tests
{
    [TestClass()]
    public class MappingsTests
    {
        [TestMethod()]
        public void MappingsTest()
        {
            var cfg = new MapperConfiguration(expression => expression.AddProfile<Mappings>());
            cfg.AssertConfigurationIsValid();
        }
    }
}