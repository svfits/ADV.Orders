﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Model
{
    public class DataContextApp : DbContext
    {
        public DataContextApp(DbContextOptions<DataContextApp> options) : base(options)
        {

        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<OrdersProducts> OrdersProducts { get; set; }
    }
}
