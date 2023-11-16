using CRUD.DataAccess.Models;
using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.CartProv
{
    public class CartProvider : ICartProvider
    {
        public JsonResultVM DeleteCartById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAllCart()
        {
            throw new NotImplementedException();
        }

        public Cart GetCartById(int id)
        {
            throw new NotImplementedException();
        }

        public JsonResultVM SaveNewCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public JsonResultVM UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
