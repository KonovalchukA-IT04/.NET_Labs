using DAL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Interfaces;
using DAL.Models.Interfaces;
namespace DAL.Repositories
{
    public class Repository<T>: IRepository<T> where T : class, IModel
    {
        protected readonly TMContext _context;
        protected Repository(TMContext context)
        {
            _context = context;
        }


        public async Task<bool> Create(T e)
        {
            await _context.AddAsync(e);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> Get(int id)
        {
            return (await GetAll()).FirstOrDefault(e => e.Id == id);
        }


        public async Task<bool> Update(T e)
        {
            var dbe = await Get(e.Id);
            if (dbe == null)
            {
                return false;
            }
            _context.Update(e);
            await _context.SaveChangesAsync();
            return true;
        }


        public virtual async Task<bool> Delete(int id)
        {
            var e = await Get(id);
            if (e == null)
            {
                return false;
            }
            _context.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
