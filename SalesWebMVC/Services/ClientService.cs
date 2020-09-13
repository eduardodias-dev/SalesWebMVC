using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class ClientService
    {
        private readonly SalesWebMVCContext _context;
        public ClientService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Client> ListAll()
        {
            return _context.Client.ToList();
        }

        public void Insert(Client obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
