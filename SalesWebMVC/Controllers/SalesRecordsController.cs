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
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var sales = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(sales);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var sellers = await _sellerService.FindAllAsync();
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
