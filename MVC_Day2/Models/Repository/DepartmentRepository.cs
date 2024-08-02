namespace MVC_Day2.Models.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        //CRUD
        ITIContext context;
        public DepartmentRepository(ITIContext _context)//ask==>register
        {
            context = _context;
        }
       
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id) 
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department department) 
        {
            context.Add(department);
        }
        public void Update(Department department) 
        {
            context.Update(department);
        }
        public void Delete(int id) 
        {
            Department obj = GetById(id);
            context.Remove(obj); //context.Departments.Remove(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }


    }
}
