using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using School_project.Models;
using MySql.Data.MySqlClient;



namespace School_project.Controllers
{
    public class TeacherDataController : ApiController
    {
        //private Teacher teacher = new Teacher();
        private static readonly Teacher teacher1 = new Teacher();
        private readonly Teacher teacher = teacher1;







        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher1> ListTeachers(string SearchKey=null)
        {
            MySqlConnection Conn = teacher.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "Select *from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key)or concat(teacherfname,'',teacherlname) like lower(@key)"; 
            cmd.Parameters.AddWithValue("key","%" + SearchKey +"%");


            cmd.Prepare();
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            
            //we wish to create a list of teachers rather than a list of teacher's names

            List <Teacher1> Teachers= new List<Teacher1>();
            while (ResultSet.Read()) {
                int TeacherID = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname= (string)ResultSet["teacherlname"];
                string TeacherEmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = (decimal)ResultSet["salary"];
 
                //NewTeacher is the new object of our Teacher1 class
                    Teacher1 NewTeacher = new Teacher1();
                NewTeacher.TeacherId = TeacherID;
                NewTeacher.TeacherFname=TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = TeacherEmployeeNumber;
                NewTeacher.HireDate = TeacherHireDate;
                NewTeacher.Salary = TeacherSalary;


                Teachers.Add(NewTeacher);                
            }

            Conn.Close();

            return Teachers;


        }

        [HttpGet]


        public Teacher1 FindTeacher(int id)
        {

            Teacher1 NewTeacher = new Teacher1();

            //Establish a new commmand(query)for our database
            MySqlConnection Conn = teacher.AccessDatabase();
            Conn.Open();

            //SQL Query
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT *FROM teachers WHERE teacherid="+id;
            
            //Gather ResultSet Of querry into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access the column information by the DB COLUMN NAME as index

                int TeacherID = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string TeacherEmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = (decimal)ResultSet["salary"];


                //NewTeacher is the new object of our Teacher1 class
                
                NewTeacher.TeacherId = TeacherID;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = TeacherEmployeeNumber;
                NewTeacher.HireDate = TeacherHireDate;
                NewTeacher.Salary = TeacherSalary;







            }


            return NewTeacher;
        }

        /// <summary>
        /// POST : api/TeacherData/DeleteTeacher/3
        /// </summary>
        /// <param name="TeacherID"></param>
        [HttpPost]
        public void DeleteTeacher(int TeacherID)
        {
            MySqlConnection Conn = teacher.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();


            cmd.CommandText = "DELETE *FROM teachers WHERE teacherid=@id";
            cmd.Parameters.AddWithValue("@teacherid",TeacherID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }
        [HttpPost]
        public void AddTeacher(Teacher1 NewTeacher)
        {
            MySqlConnection Conn = teacher.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();


            cmd.CommandText = "insert into teachers(teacherfname, teacherlname, employeenumber, hiredate, salary) values(@teacherfname,@teacherlname,@employeenumber,CURRENT_DATE(),@salary)";
            
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", NewTeacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);



            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();



        }



    }
        

    }

