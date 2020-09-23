using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    //injeção de dependencia
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context){
            _context = context;
        }

        public List<SalesRecord> FindAll()
        {
            return _context.SalesRecord.Include(s => s.Seller).ToList();
        }

        public void Create(SalesRecord salesRecord)
        {
            _context.SalesRecord.Add(salesRecord);
            _context.SaveChanges();
        }
    }
}
