using Microsoft.AspNetCore.Mvc;
using MVC_Day2.Models;
using MVC_Day2.Models.Repository;
using MVC_Day2.ViewModels;

namespace MVC_Day2.Controllers
{
    public class CourseController : Controller
    {

        //ITIContext context = new ITIContext();

        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        //Controller has one Constructor(Inject | ask) 
        public CourseController(ICourseRepository courseRepo, IDepartmentRepository deptRepo)
        {
            courseRepository = courseRepo;// new CourseRepository();
            departmentRepository = deptRepo;// new DepartmentRepository();
        }


        //Course/GetCrsCardPartial/1 (part of page) partial request using ajax
        public IActionResult GetCrsCardPartial(int id) 
        {
            Course courseModel = courseRepository.GetById(id);
            if (courseModel == null) {return NotFound();}

            return PartialView("_CrsCardPartial",courseModel);
        }

        public IActionResult CheckMinDegree(int mindegree, int degree)
        {
            if (mindegree < degree)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult CheckHours(int hours)
        {
            if (hours % 3 == 0)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Index()
        {

            List<Course> courseListModel = courseRepository.GetAll();
            return View("AllCourses", courseListModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCoursewithDeptListViewModel courseVM = new AddCoursewithDeptListViewModel();
            courseVM.DeptList = departmentRepository.GetAll();
            //ViewBag.DeptList = context.Departments.ToList();
            return View("AddCourse", courseVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(AddCoursewithDeptListViewModel newCourseFromRequest)
        {
            Course newCourse = new Course
            {
                Name = newCourseFromRequest.Name,
                Degree = newCourseFromRequest.Degree,
                MinDegree = newCourseFromRequest.MinDegree,
                Hours = newCourseFromRequest.Hours,
                DepartmentId = newCourseFromRequest.DepartmentId
            };

            if (ModelState.IsValid == true)
            {
                try
                {
                    //context.Add(newCourse);
                    //context.SaveChanges();
                    courseRepository.Insert(newCourse);
                    courseRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ayhaga", ex.Message + " " + ex.InnerException?.Message);
                }
            }

            newCourseFromRequest.DeptList = departmentRepository.GetAll().ToList();
            return View("AddCourse", newCourseFromRequest);
        }

        //Course/Edit/Id=1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course courseModel = courseRepository.GetById(id);
            var courseVM = new AddCoursewithDeptListViewModel()
            {
                Name = courseModel.Name,
                Degree = courseModel.Degree,
                MinDegree = courseModel.MinDegree,
                Hours = courseModel.Hours,
                DepartmentId = courseModel.DepartmentId,
                DeptList = departmentRepository.GetAll()
            };

            if (courseVM == null)
            {
                return NotFound();
            }

            return View("Edit", courseVM);
        }

        //Course/SaveEdit/Object Request
        [HttpPost]
        public IActionResult SaveEdit(AddCoursewithDeptListViewModel CrsFromReq)
        {
            if (ModelState.IsValid == true)
            {
                Course courseModel = courseRepository.GetById(CrsFromReq.Id);

                courseModel.Name = CrsFromReq.Name;
                courseModel.Degree = CrsFromReq.Degree;
                courseModel.MinDegree = CrsFromReq.MinDegree;
                courseModel.Hours = CrsFromReq.Hours;
                courseModel.DepartmentId = CrsFromReq.DepartmentId;

                courseRepository.Save();
                return RedirectToAction("Index");
            }

            CrsFromReq.DeptList = departmentRepository.GetAll();
            return View("Edit", CrsFromReq);

        }

        public IActionResult Delete(int id)
        {
            Course courseModel = courseRepository.GetById(id);
            if (courseModel.Name != null)
            {
                courseRepository.Delete(id);
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Details(int id)
        {
            Course courseModel = courseRepository.GetById(id);
            if (courseModel == null)
            { return NotFound(); }

            return View("Details", courseModel);
        }

    }
}
