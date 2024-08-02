namespace MVC_Day2.Models.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department department);
        void Update(Department department);
        void Delete(int id);
        void Save();
    }
}