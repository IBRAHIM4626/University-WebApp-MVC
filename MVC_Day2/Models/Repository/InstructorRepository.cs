namespace MVC_Day2.Models.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        ITIContext context;
        public InstructorRepository(ITIContext _context)//ask | inject
        {
            context = _context;
        }
        public List<Instructor> GetByDeptId(int deptId)
        {
            return context.Instructors.Where(i => i.DepartmentId == deptId).ToList();
        }
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(i => i.Id == id);
        }
        public void Insert(Instructor obj)
        {
            context.Add(obj);
        }
        public void Update(Instructor obj) 
        {
            context.Update(obj);
        }
        public void Delete(int id) 
        {
            Instructor instructor = GetById(id);
            context.Instructors.Remove(instructor);
        }
        public void Save() 
        {
            context.SaveChanges();
        }
        public List<Instructor> searchByName(string username)
        {
            List<Instructor> instructors = context.Instructors.Where(i => i.Name.Contains(username)).ToList();
            return instructors;
        }
    }
}
