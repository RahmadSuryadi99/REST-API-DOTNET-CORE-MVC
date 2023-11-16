using CRUD.DataAccess.Models;
using CRUD.Provider.CartProv;
using CRUD.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CartController : Controller
    {
        private readonly ICartProvider _cartProvider;
        public CartController(ICartProvider cartProvider) { _cartProvider = cartProvider; }


        [HttpGet]
        [Route("all")]
        public List<Cart> Carts()
        {
            return _cartProvider.GetAllCart();
        }

        [HttpGet]
        [Route("{id}")]
        public Cart GetById(int id)
        {
            return _cartProvider.GetCartById(id);
        }
        [HttpGet]
        [Route("searchByQueryParam/")]
        public Cart GetByIdQuary([FromQuery] int id, string nama)
        {
            return _cartProvider.GetCartById(id);
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public void DeleteById(int id)
        {
            _cartProvider.DeleteCartById(id);
        }

        [HttpPost]
        [Route("add")]
        public JsonResultVM Insert(Cart model)
        {
            return _cartProvider.SaveNewCart(model);
        }

        [HttpPut]
        [Route("Update")]
        public JsonResultVM Update(Cart model)
        {
            return _cartProvider.UpdateCart(model);
        }
    }
}
