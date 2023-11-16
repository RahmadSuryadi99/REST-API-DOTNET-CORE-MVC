using CRUD.DataAccess.Models;
using CRUD.Repository.CartRepo;
using CRUD.Repository.ProdukRepo;
using CRUD.ViewModel;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.CartProv
{
    public class CartProvider : ICartProvider
    {
        private readonly IProdukRepository _produkRepository;
        private readonly ICartRepository _cartRepository;

        public CartProvider(IProdukRepository produkRepository,ICartRepository cartRepository)
        {
            _produkRepository = produkRepository;
            _cartRepository = cartRepository;
        }
        public JsonResultVM DeleteCartById(int id)
        {
            var model = _cartRepository.GetSingle(id);
            bool isSucces = _cartRepository.Delete(id);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di hapus" : "data Gagal di hapus",
                ReturnObject = model
            };
        }

        public List<Cart> GetAllCart()
        {
            var model = (from a in _cartRepository.GetAll()
                         select new Cart
                         {
                             Id = a.Id,
                             IdProduk = a.IdProduk,
                             IdUser = a.IdUser,
                             Jumlah = a.Jumlah,
                             
                         }
                     ).ToList();
            return model;
        }

        public Cart GetCartById(int id)
        {
            var oldData = _cartRepository.GetSingle(id);
            var entity = oldData.Adapt<Cart>();

            return entity;
        }

        public JsonResultVM SaveNewCart(Cart cart)
        {
            bool isSucces = _cartRepository.Insert(cart);

            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di tambahkan" : "data Gagal di tambahkan",
                ReturnObject = cart
            };
        }

        public JsonResultVM UpdateCart(Cart cart)
        {
            bool isSucces = _cartRepository.Update(cart);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di update" : "data Gagal di update",
                ReturnObject = cart
            };
        }
    }
}
