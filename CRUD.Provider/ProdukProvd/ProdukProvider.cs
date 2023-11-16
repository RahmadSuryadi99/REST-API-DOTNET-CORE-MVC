using CRUD.DataAccess.Models;
using CRUD.Repository.ProdukRepo;
using CRUD.ViewModel;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.ProdukProvd
{
    public class ProdukProvider : IProdukProvider
    {
        private readonly IProdukRepository _produkRepository;

        public ProdukProvider(IProdukRepository produkRepository)
        {
            _produkRepository = produkRepository;
        }

        public JsonResultVM DeleteProdukById(int id)
        {
            var produk = _produkRepository.GetSingle(id);
            bool isSucces = _produkRepository.Delete(id);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di hapus" : "data Gagal di hapus",
                ReturnObject = produk
            };
        }

        public List<ProdukVM> GetAllProduk()
        {
            var model = (from a in _produkRepository.GetAll()
                         select new ProdukVM
                         {
                             Id = a.Id,
                             Nama = a.Nama,
                             Category = a.Category,
                             Deskripsi = a.Deskripsi,
                             Harga = a.Harga
                         }
                      ).ToList();
            return model;
        }

        public ProdukVM GetProdukById(int id)
        {
            var oldProduk = _produkRepository.GetSingle(id);
            ProdukVM produk = oldProduk.Adapt<ProdukVM>();

            return produk;
        }

        public JsonResultVM SaveNewProduk(ProdukVM produk)
        {
            Produk newProduk = produk.Adapt<Produk>();
            bool isSucces = _produkRepository.Insert(newProduk);

            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di tambahkan" : "data Gagal di tambahkan",
                ReturnObject = newProduk
            };
        }

        public JsonResultVM UpdateProduk(ProdukVM produk)
        {
            Produk newProduk = produk.Adapt<Produk>();
            bool isSucces = _produkRepository.Update(newProduk);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di update" : "data Gagal di update",
                ReturnObject = newProduk
            };

        }
    }
}
