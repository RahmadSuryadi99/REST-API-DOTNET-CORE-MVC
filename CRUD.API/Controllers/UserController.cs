using CRUD.Provider.UserProv;
using CRUD.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;
        public UserController(IUserProvider userProvider) { _userProvider = userProvider; }


        [HttpGet]
        [Authorize]
        [Route("all")]
        public List<UserVM> Users()
        {
            return _userProvider.GetAllUser();
        }

        [HttpGet]
        [Route("{id}")]
        public UserVM GetById(int id)
        {
            return _userProvider.GetUserById(id);
        }
        [HttpGet]
        [Route("")]
        public UserVM GetByIdQuary([FromQuery] int id, string nama)
        {
            return _userProvider.GetUserById(id);
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public void DeleteById(int id)
        {
            _userProvider.DeleteUserById(id);
        }

        [HttpPost]
        [Route("add")]
        public JsonResultVM Insert(UserVM model)
        {
            return _userProvider.SaveNewUser(model);
        }

        [HttpPut]
        [Route("Update")]
        public JsonResultVM Update(UserVM model)
        {
            return _userProvider.UpdateUser(model);
        }


    }
}
