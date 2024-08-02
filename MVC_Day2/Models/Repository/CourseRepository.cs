namespace MVC_Day2.Models.Repository
{
    public class CourseRepository:ICourseRepository
    {
        //CRUD
        ITIContext context;
        public CourseRepository(ITIContext _context)//ask
        {
            context = _context;
        }
        public List<Course> GetByDeptId(int deptId)
        {
            return context.Courses.Where(c => c.DepartmentId == deptId).ToList();
        }
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(Course course)
        {
            context.Add(course);
        }
        public void Update(Course course)
        {
            context.Update(course);
        }
        public void Delete(int id)
        {
            Course course = GetById(id);
            context.Remove(course); //== context.Course.Remove(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
