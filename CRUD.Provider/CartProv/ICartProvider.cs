using CRUD.DataAccess.Models;
using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.CartProv
{
    public interface ICartProvider
    {
        public List<Cart> GetAllCart();
        public Cart GetCartById(int id);
        public JsonResultVM SaveNewCart(Cart cart);
        public JsonResultVM DeleteCartById(int id);
        public JsonResultVM UpdateCart(Cart cart);
    }
}
