using CRUD.DataAccess.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.CartRepo
{
    public class CartRepository : ICartRepository
    {
        private readonly LatihanDbContext _context;

        public CartRepository(LatihanDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Produks.SingleOrDefault(p => p.Id == id);
                _context.Produks.Remove(entity);

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Cart> GetAll()
        {
            return _context.Carts;
        }

        public Cart GetSingle(int id)
        {
            return _context.Carts.SingleOrDefault(a => a.Id == id);
        }

        public bool Insert(Cart model)
        {
            try
            {
                _context.Carts.Add(model);

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Cart model)
        {
            try
            {
                var oldData = _context.Carts.SingleOrDefault(a => a.Id == model.Id);
                model.Adapt(oldData);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
