﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADV.Orders.Models;
using ADV.OrdersProducts.Interfaces;
using AutoMapper;

namespace ADV.Orders.Controllers
{
    public class HomeController : Controller
    {
        IServicesHome _servicesHome;
        private readonly IMapper _mapper;

        public HomeController(IServicesHome servicesHome, IMapper mapper)
        {
            _servicesHome = servicesHome;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
