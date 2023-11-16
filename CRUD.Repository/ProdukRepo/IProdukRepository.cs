using CRUD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.ProdukRepo
{
    public interface IProdukRepository:IRepository<Produk, int>
    {
    }
}
