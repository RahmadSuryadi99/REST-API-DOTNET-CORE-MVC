using CRUD.DataAccess.Models;
using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.UserRepo
{
    public interface IUserRepository : IRepository<User,int>
    {

    }
}
