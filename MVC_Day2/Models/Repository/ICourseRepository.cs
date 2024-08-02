namespace MVC_Day2.Models.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetByDeptId(int deptId);
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course obj);
        void Update(Course obj);
        void Delete(int id);
        void Save();


    }
}