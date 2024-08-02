using Microsoft.AspNetCore.Mvc;
using MVC_Day2.Models;
using MVC_Day2.Models.Repository;
using MVC_Day2.ViewModels;

namespace MVC_Day2.Controllers
{
    public class InstructorController : Controller
    {
        //ITIContext context = new ITIContext();
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;
        ICourseRepository courseRepository;
        public InstructorController(IInstructorRepository instructorRepo ,IDepartmentRepository departmentRepo, ICourseRepository courseRepo)
        {
            this.instructorRepository = instructorRepo;
            this.departmentRepository = departmentRepo;
            this.courseRepository = courseRepo;
        }

        public IActionResult GetCoursesByDept(int deptId)//id
        {
            List<Course> coursesList = courseRepository.GetByDeptId(deptId);
            return Json(coursesList);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var insWithListVM = new AddInstructorWithDeptListAnd_CourseListViewModel();
            insWithListVM.DeptList = departmentRepository.GetAll();
            insWithListVM.CourseList = courseRepository.GetAll();
            return View("Add", insWithListVM); //Model Null
        }

        [HttpPost] //request not to carry out in url
        public IActionResult SaveAdd(AddInstructorWithDeptListAnd_CourseListViewModel newInsVM)
        {
            var newInstructor = new Instructor
            {
                Name = newInsVM.Name,
                ImageUrl = newInsVM.ImageUrl,
                Salary = newInsVM.Salary,
                Address = newInsVM?.Address,
                CrsId = newInsVM.CrsId,
                DepartmentId = newInsVM.DepartmentId
            };
            
            if (newInstructor.Name != null && newInstructor.ImageUrl !=null && newInstructor.Salary >= 6000 &&
                newInstructor.Address != null && newInstructor.DepartmentId!=0 && newInstructor.CrsId !=0) 
            {
                instructorRepository.Insert(newInstructor);
                instructorRepository.Save();
                return RedirectToAction("Index"); // as /Instructor/Index
            }
            newInsVM.DeptList = departmentRepository.GetAll(); //get deparment list from database
            newInsVM.CourseList = courseRepository.GetAll();

            //if any data is null again ==> add data
            return View("Add", newInsVM); //View Add, Model Instructor
        }

        public IActionResult Index()
        {
            List<Instructor> InsListModel = instructorRepository.GetAll();
            return View("AllIns", InsListModel);
        }

        public IActionResult Edit(int id)
        {
            Instructor insModel = instructorRepository.GetById(id);
            var InsVM = new AddInstructorWithDeptListAnd_CourseListViewModel();
            InsVM.Id = insModel.Id;
            InsVM.Name = insModel.Name;
            InsVM.Salary = insModel.Salary;
            InsVM.Address = insModel.Address;
            InsVM.ImageUrl = insModel.ImageUrl;
            InsVM.DepartmentId = insModel.DepartmentId;
            InsVM.DeptList = departmentRepository.GetAll();
            InsVM.CrsId = insModel.CrsId;
            InsVM.CourseList = courseRepository.GetAll();

            if (InsVM == null)
            {
                return NotFound();
            }
            return View("Edit", InsVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(AddInstructorWithDeptListAnd_CourseListViewModel insFromReq) 
        {
            if(insFromReq.Name != null && insFromReq.ImageUrl != null && insFromReq.Salary > 6000 &&
                insFromReq.Address != null)
            {
                Instructor insModel = instructorRepository.GetById(insFromReq.Id);
                insModel.Name = insFromReq.Name;
                insModel.Salary = insFromReq.Salary;
                insModel.Address = insFromReq.Address;
                insModel.ImageUrl = insFromReq.ImageUrl;
                insModel.DepartmentId = insFromReq.DepartmentId;
                insModel.CrsId= insFromReq.CrsId;

                //context.Update(insFromReq); //Must Id with value 
                instructorRepository.Save();
                return RedirectToAction("Index");
            }

            insFromReq.DeptList = departmentRepository.GetAll(); //get deparment list from database
            insFromReq.CourseList = courseRepository.GetAll();
            return View("Edit", insFromReq);
        }

        public IActionResult Details(int id) 
        {
            //string msg = "Hello";
            //int no = 30;
            //string localDate = DateTime.Now.ToShortDateString();
            //string color = "red";
            //List<string> branchList = new List<string>();
            //branchList.Add("Smart");
            //branchList.Add("Menofia");
            //branchList.Add("Mansoura");
            //branchList.Add("Alex");

            //ViewData["Message"] = msg;
            //ViewData["Branch"] = branchList;
            //ViewData["clr"] = color;
            //ViewData["no"] = no;
            //ViewData["date"] = localDate;

            //ViewBag.NewId="33"; //ViewData["NewId"] =33
            //ViewBag.clr = "blue";

            Instructor instructorModel = instructorRepository.GetById(id);
            if (instructorModel == null) 
            {
                return NotFound();
            }
            return View("instDetails", instructorModel);
        }
        public IActionResult Delete(int id)
        {
            Instructor insModel = instructorRepository.GetById(id);
            if (insModel.Name != null)
            {
                instructorRepository.Delete(id);
                instructorRepository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult search(string username)
        {
            return View("AllIns", instructorRepository.searchByName(username));
        }


    }
}
