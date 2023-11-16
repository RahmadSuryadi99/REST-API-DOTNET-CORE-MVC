using CRUD.DataAccess.Models;
using CRUD.Provider.UserProv;
using CRUD.Repository.UserRepo;
using CRUD.ViewModel;
using Mapster;
using MapsterMapper;

namespace CRUD.Provider.UserProv
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public JsonResultVM DeleteUserById(int id)
        {
            var user = _userRepository.GetSingle(id);
            bool isSucces = _userRepository.Delete(id);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di hapus" : "data Gagal di hapus",
                ReturnObject = user
            };
        }

        public List<UserVM> GetAllUser()
        {
            var model = (from a in _userRepository.GetAll()
                         select new UserVM
                         {
                             Id = a.Id,
                             Alamat = a.Alamat,
                             Nama = a.Nama,
                             TglLahir = a.TglLahir,
                         }
                         ).ToList();
            return model;
        }

        public UserVM GetUserById(int id)
        {

            var oldUser = _userRepository.GetSingle(id);
            UserVM user = oldUser.Adapt<UserVM>();

            return user;
        }

        public JsonResultVM SaveNewUser(UserVM user)
        {
            User newUser = user.Adapt<User>();
            bool isSucces = _userRepository.Insert(newUser);

            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di tambahkan" : "data Gagal di tambahkan",
                ReturnObject = newUser
            };
        }


        public JsonResultVM UpdateUser(UserVM user)
        {
            User newUser = user.Adapt<User>();
            bool isSucces = _userRepository.Update(newUser);
            return new JsonResultVM
            {
                Success = isSucces,
                Message = isSucces ? "data berhasil di update" : "data Gagal di update",
                ReturnObject = newUser
            };

        }
        public bool IsPrime(int candidate)
        {
            if (candidate == 1)
            {
                return false;
            }
            return true;
            //throw new NotImplementedException("Not fully implemented.");
        }

      
    }
}