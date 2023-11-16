using CRUD.Provider.ProdukProvd;
using CRUD.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ProdukController : Controller
    {
        private readonly IProdukProvider _produkProvider;
        public ProdukController(IProdukProvider produkProvider) { _produkProvider = produkProvider; }


        [HttpGet]
        [Route("all")]
        public List<ProdukVM> Produks()
        {
            return _produkProvider.GetAllProduk();
        }

        [HttpGet]
        [Route("{id}")]
        public ProdukVM GetById(int id)
        {
            return _produkProvider.GetProdukById(id);
        }
        [HttpGet]
        [Route("")]
        public ProdukVM GetByIdQuary([FromQuery] int id, string nama)
        {
            return _produkProvider.GetProdukById(id);
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public void DeleteById(int id)
        {
            _produkProvider.DeleteProdukById(id);
        }

        [HttpPost]
        [Route("add")]
        public JsonResultVM Insert(ProdukVM model)
        {
            return _produkProvider.SaveNewProduk(model);
        }

        [HttpPut]
        [Route("Update")]
        public JsonResultVM Update(ProdukVM model)
        {
            return _produkProvider.UpdateProduk(model);
        }

    }
}
