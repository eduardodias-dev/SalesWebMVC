using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {

        //injeção de dependência
        private readonly SalesRecordService _salesRecordService;
        private readonly SellerService _sellerService;
        public SalesRecordsController(SalesRecordService salesRecordsService, SellerService sellerService)
        {
            _salesRecordService = salesRecordsService;
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            List<SalesRecord> sales = _salesRecordService.FindAll();
            return View(sales);
        }

        public IActionResult Create()
        {
            var sellers = _sellerService.FindAll();
            SalesRecord sale = new SalesRecord();
            SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel { Sellers = sellers, SalesRecord = sale };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesRecord salesRecord)
        {
            _salesRecordService.Create(salesRecord);

            return RedirectToAction(nameof(Index));
        }
    }
}
