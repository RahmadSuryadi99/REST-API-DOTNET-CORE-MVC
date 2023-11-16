using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Provider.UserProv
{
    public interface IUserProvider
    {
        public List<UserVM> GetAllUser();
        public UserVM GetUserById(int id);
        public JsonResultVM SaveNewUser(UserVM user);
        public JsonResultVM DeleteUserById(int id);
        public JsonResultVM UpdateUser(UserVM user);

        public bool IsPrime(int candidate);
    }
}
