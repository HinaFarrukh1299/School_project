using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_project.Models;
using System.Diagnostics;

namespace School_project.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get : Teacher/List
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string SearchKey=null  ) { 

            TeacherDataController Controller = new TeacherDataController();
           IEnumerable<Teacher1> Teachers= Controller.ListTeachers(SearchKey);
        
        return View(Teachers);
        
        }
        ///Get: Teacher/Show
        
        public ActionResult Show(int id) {
            TeacherDataController controller= new TeacherDataController();
            Teacher1 NewTeacher=controller.FindTeacher(id);
            
        
        return  View(NewTeacher);
        
        }

        //POST  : /Teacher/DeleteComfirm/id
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher1 NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);

        }
        public ActionResult DeleteTeacher(int id)
        {
            TeacherDataController controller=new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //Get: /Teacher/New

        public ActionResult New()
        {
            return View();
        }

        //POST: Teacher/Create
        [HttpPost]
       
        public ActionResult Create(string TeacherFname,string TeacherLname,string TeacherEmployeeNumber,DateTime TeacherHireDate, decimal TeacherSalary) {
            //identify that this method is running
            //identify the inputs provided from the form


            Debug.WriteLine("i have accessed the create method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(TeacherEmployeeNumber);
            Debug.WriteLine(TeacherHireDate);
            Debug.WriteLine(TeacherSalary);

            Teacher1 NewTeacher= new Teacher1();
            NewTeacher.TeacherFname=TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = TeacherEmployeeNumber;
            NewTeacher.HireDate = TeacherHireDate;
            NewTeacher.Salary = TeacherSalary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);



            return RedirectToAction("List");
        }


    }
}