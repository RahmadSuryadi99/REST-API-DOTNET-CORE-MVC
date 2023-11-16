using CRUD.DataAccess.Models;
using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.ProdukProvd
{
    public interface IProdukProvider 
    {
        public List<ProdukVM> GetAllProduk();
        public ProdukVM GetProdukById(int id);
        public JsonResultVM SaveNewProduk(ProdukVM produk);
        public JsonResultVM DeleteProdukById(int id);
        public JsonResultVM UpdateProduk(ProdukVM produk);

    }
}
