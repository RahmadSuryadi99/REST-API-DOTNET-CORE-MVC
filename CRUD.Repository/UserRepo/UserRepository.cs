using CRUD.DataAccess.Models;
using Mapster;

namespace CRUD.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly LatihanDbContext _context;
            
        public UserRepository(LatihanDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(a=>a.Id == id);

                _context.Users.Remove(user);
                _context.SaveChanges(); 
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<User> GetAll()
        {
            
            return _context.Users;
        }

        public User GetSingle(int id)
        {
            return _context.Users.SingleOrDefault(a => a.Id==id); 
        }

        public bool Insert(User model)
        {
            try
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Update(User model)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(a => a.Id == model.Id);
                model.Adapt(user);
                _context.SaveChanges();
                return true;
           }
            catch (Exception ex) { return false; }
        }
    }
}