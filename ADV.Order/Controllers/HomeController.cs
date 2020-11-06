using ADV.Orders.Models;
using ADV.OrdersProducts.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.Orders.Controllers
{
    public class HomeController : Controller
    {
        readonly IServicesHome _servicesHome;
        private readonly IMapper _mapper;

        public HomeController(IServicesHome servicesHome, IMapper mapper)
        {
            _servicesHome = servicesHome;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _servicesHome.GetOrdersAsync();
            ViewBag.Orders = orders;
            ViewBag.DatailOrder = await _servicesHome.GetDatailsOrderAsync(orders.FirstOrDefault().Id);
            ViewBag.Product = await _servicesHome.GetProductsAsync(orders.FirstOrDefault().Id);

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
