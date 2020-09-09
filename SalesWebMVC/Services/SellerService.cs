using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //Injeção de dependência
        private readonly SalesWebMVCContext _context;

        //Ao colocar o context como parâmetro do construtor, o Startup da aplicação irá inserir o context para todos os que estiverem como AddScoped
        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
