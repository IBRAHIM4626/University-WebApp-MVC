using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Day2.Models;
using MVC_Day2.ViewModels;

namespace MVC_Day2.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext context = new ITIContext();
        public TraineeController()
        {
            
        }

        public IActionResult ShowResult(int id, int crsid)
        {
            var crsresult = context.CrsResult
                .Where(x => x.TraineeId == id && x.CourseId == crsid)
                .Select(x => new TraineeResultsViewModel
                {
                    CourseName = x.Course.Name,
                    TraineeName = x.Trainee.Name,
                    Degree = x.Degree,
                    MinDegree = x.Course.MinDegree,
                    Color = x.Degree >= x.Course.MinDegree ? "green" : "red"
                }).FirstOrDefault();

            if (crsresult == null) 
            {
                return NotFound();
            }

            return View("ShowResult", crsresult);
        }
        public IActionResult ShowCourseResult(int crsId) 
        {
            var courseResult = context.CrsResult.Include(t => t.Trainee).Include(c => c.Course)
                .Where(x => x.CourseId == crsId).Select(x => new TraineeResultsViewModel
                {
                    TraineeName = x.Trainee.Name,
                    Degree = x.Degree,
                    CourseName = x.Course.Name,
                    MinDegree = x.Course.MinDegree,
                    Color = x.Degree < x.Course.MinDegree ? "red" : "green"
                }
                ).ToList();
            return View("CrsResult", courseResult);
        }
        public IActionResult SetSession(string name, int age)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Data Saved");
        }

        public IActionResult GetSession(string name, int age) 
        {
            string n = HttpContext.Session.GetString("Name");
            int a = HttpContext.Session.GetInt32("Age").Value;

            return Content($"name= {n}\t age= {a}");
        }

        public IActionResult SetCookie()
        {
         
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            //Presisitent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1); ;
            HttpContext.Response.Cookies.Append("Age", "12", options);
            return Content("Cookie SAve");

        }
        public IActionResult GetCookie()
        {
            //server need from client
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            //logic
            return Content($"name={n} \t age={a}");

        }

    }
}
