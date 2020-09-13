using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientService _service;
        public ClientsController(ClientService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<Client> clients = _service.ListAll();
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            _service.Insert(client);
            return RedirectToAction(nameof(Index));
        }
    }
}
