using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        Student objStudent = new Student();

        public IActionResult Index()
        {
            objStudent = new Student();
            List<Student> lst = objStudent.getData("");
            return View(lst);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.insert(emp);
                if (res)
                {
                    TempData["msg"] = "Added successfully";
                }
                else
                {
                    TempData["msg"] = "Not Added. something went wrong..!!";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditStudent(string id)
        {
            List<Student> emp = objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }

        [HttpGet]
        public IActionResult DeleteStudent(string id)
        {
            List<Student> emp = objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditStudent(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.update(emp);
                if (res)
                {
                    TempData["msg"] = "Updated successfully";
                }
                else
                {
                    TempData["msg"] = "Not Updated. something went wrong..!!";
                }
            }

            return View();
        }


        [HttpPost]
        public IActionResult DeleteStudent(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.delete(emp);
                if (res)
                {
                    TempData["msg"] = "Deleted successfully";
                }
                else
                {
                    TempData["msg"] = "Not Deleted. something went wrong..!!";
                }
            }

            return View();
        }
    }
}
