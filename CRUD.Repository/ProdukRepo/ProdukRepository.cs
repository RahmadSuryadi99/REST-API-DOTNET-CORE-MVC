using CRUD.DataAccess.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.ProdukRepo
{
    public class ProdukRepository : IProdukRepository
    {
        private readonly LatihanDbContext _context;
        
        public ProdukRepository(LatihanDbContext context)
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

        public IQueryable<Produk> GetAll()
        {
            return _context.Produks;
        }

        public Produk GetSingle(int id)
        {
            return _context.Produks.SingleOrDefault(a => a.Id == id);
        }

        public bool Insert(Produk model)
        {
            try
            {
                _context.Produks.Add(model);

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Produk model)
        {
            try
            {
                var oldData = _context.Produks.SingleOrDefault(a => a.Id == model.Id);
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
