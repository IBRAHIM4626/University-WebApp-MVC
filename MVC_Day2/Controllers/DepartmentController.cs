using Microsoft.AspNetCore.Mvc;
using MVC_Day2.Models;
using MVC_Day2.Models.Repository;
using MVC_Day2.ViewModels;

namespace MVC_Day2.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository DeptRepository;
        ICourseRepository CourseRepository;
        public DepartmentController(IDepartmentRepository deptRepo, ICourseRepository courseRepo)
        {
            DeptRepository = deptRepo;// new DepartmentRepository();
            CourseRepository = courseRepo;// new CourseRepository();
        }
        public IActionResult ShowDeptCrs()
        {
            List<Department> DeptListModel = DeptRepository.GetAll();
            return View("ShowDeptCrs", DeptListModel);
        }

        //Department/GetCoursesByDept?deptId=1 --> if name is id --> /Department/GetCoursesByDept/1
        public IActionResult GetCoursesByDept(int deptId)//id
        {
            //return list all courses in this department that equals deptId
            //List<Course> courseList = context.Courses.Where(c => c.DepartmentId == deptId).ToList();
            List<Course> courseList = CourseRepository.GetByDeptId(deptId);
            return Json(courseList);
        }


        public IActionResult Add()
        {
            Department DeptModel = new Department();//////
            return View("Add", DeptModel);
        }
        [HttpPost]
        public IActionResult SaveAdd(Department newDept)
        {

            if (newDept.Name != null && newDept.ManagerName != null)
            {
                DeptRepository.Insert(newDept);
                DeptRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add", newDept);//View Add,Model DEpartment

        }

        public IActionResult Index()
        {
            List<Department> DeptListModel = DeptRepository.GetAll();
            return View("Index", DeptListModel);
        }
        public IActionResult Details(int id) 
        {
            Department departmentModel = DeptRepository.GetById(id);
            if (departmentModel == null) { return NotFound(); }
            return View("Details",departmentModel);
        }
    }
}
