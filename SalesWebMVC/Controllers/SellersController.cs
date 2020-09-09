using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        //injeção de dependência
        private readonly SellerService _sellerService;

        //Como esta classe está inserida como parte do escopo, o sellerService já é instanciado com o context;
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            List<Seller> list = _sellerService.FindAll();
            return View(list);
        }
    }
}
