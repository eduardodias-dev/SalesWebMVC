using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.Include(x => x.Department).ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);

                await _context.SaveChangesAsync();
            }catch(DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because it has sales records.");
            }
        }

        public async Task<Seller> DetailsAsync(int id)
        {
            return await FindByIdAsync(id);
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Seller.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DBConcurrencyException("Concurrency exception.");
            }
        }
    }
}
