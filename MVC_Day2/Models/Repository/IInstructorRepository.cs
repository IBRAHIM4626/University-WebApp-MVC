namespace MVC_Day2.Models.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetByDeptId(int deptId);
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Insert(Instructor obj);
        void Update(Instructor obj);
        void Delete(int id);
        void Save();
        List<Instructor> searchByName(string username);
    }
}