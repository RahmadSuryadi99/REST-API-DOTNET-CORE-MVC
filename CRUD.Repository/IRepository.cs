

namespace CRUD.Repository
{
    public interface IRepository<Model,Id>
    {
        public IQueryable<Model> GetAll();
        public Model GetSingle(Id id);
        public bool Insert(Model model);
        public bool Update(Model model);
        public bool Delete(Id id);
    }
}
