using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School_project.Models;

namespace School_project.Models
{
    public class Teacher1
    {
        //The following properties define a teacher
        //The naming convention is to use capital letters for naming properties of an object
       //These are called fields of our Teacher1 class
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;
    }
}