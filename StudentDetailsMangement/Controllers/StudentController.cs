using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentDetailsMangement.Models;

namespace StudentDetailsMangement.Controllers
{
    public class StudentController : Controller
    {
        //StudentDBContainer studentDb = new StudentDBContainer();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StaffLogin()
        {
            return View();
        }
        //StaffLoginDetail staff = new StaffLoginDetail();
        [HttpPost]
        public ActionResult StaffLogin(StaffLoginDetail staffLoginDetail)
        {
            if (staffLoginDetail.UserName == "Sudhakar" && staffLoginDetail.Password == "pass123")
            {
                TempData["LoginAlert"] = "Login Successfully";
                return RedirectToAction("ViewStudentDetails");
            }
            else if (staffLoginDetail.UserName != "Sudhakar" || staffLoginDetail.Password != "pass123")
            {
                TempData["LoginAlert"] = "Enter Correct Detail";
                return RedirectToAction("StaffLogin");
            }
            return View();

        }
      
        //StudentDBContainer studentDb = new StudentDBContainer(); //database
        public ActionResult AddStudentDetails()
        {
            return View("AddEditStudentDetails", new StudentDetails());
        }
        public ActionResult EditStudentDetails(int id)
        {
            StudentDetails studentDetails = new StudentDetails();
            using (var studentDb = new StudentDBContainer())
            {
                var DbstudentDetail = studentDb.student_Detail_Table.Where(x => x.Student_Id == id && x.Is_Deleted == false).SingleOrDefault(); //Check condition in datatbase table
                if (DbstudentDetail != null)
                {
                    studentDetails.StudentId = DbstudentDetail.Student_Id;
                    studentDetails.FirstName = DbstudentDetail.First_Name;
                    studentDetails.LastName = DbstudentDetail.Last_Name;
                    studentDetails.DateOfBirth = DbstudentDetail.Date_of_Birth;
                    studentDetails.Age = DbstudentDetail.Age;
                    studentDetails.FavoriteSubject = DbstudentDetail.Favorite_Subject;
                    studentDetails.InterstedCourse = DbstudentDetail.Intersted_Course;
                    studentDetails.MathsMark = DbstudentDetail.Maths_Mark;
                    studentDetails.ChemistryMark = DbstudentDetail.Chemistry_Mark;
                    studentDetails.ComputerScienceMark = DbstudentDetail.Computer_Science_Mark;
 
                }
            }
            return View("AddEditStudentDetails", studentDetails);
        }

        #region Create Student Detail
        [HttpPost]
        public ActionResult AddEditStudentDetails(StudentDetails studentDetails)
        {
            using (var studentDb = new StudentDBContainer())
                if (ModelState.IsValid)
            //if (studentDetails != null)
            {
                if (studentDetails.StudentId == 0)
                   
                    {
                    student_Detail_Table studentDetailTable = new student_Detail_Table();//table properties are inintialized
                    studentDetailTable.First_Name = studentDetails.FirstName;
                    studentDetailTable.Last_Name = studentDetails.LastName;
                    studentDetailTable.Date_of_Birth = studentDetails.DateOfBirth;
                    studentDetailTable.Age = studentDetails.Age;
                    studentDetailTable.Favorite_Subject = studentDetails.FavoriteSubject;
                    studentDetailTable.Intersted_Course = studentDetails.InterstedCourse;
                    studentDetailTable.Maths_Mark = studentDetails.MathsMark;
                    studentDetailTable.Chemistry_Mark = studentDetails.ChemistryMark;
                    studentDetailTable.Computer_Science_Mark = studentDetails.ComputerScienceMark;
                    //Must three columns
                    studentDetailTable.Is_Deleted = false;
                    studentDetailTable.Create_Time_Stamp = DateTime.Now;
                    studentDetailTable.Update_Time_stamp = DateTime.Now;
                    studentDb.student_Detail_Table.Add(studentDetailTable);
                    studentDb.SaveChanges();
                    TempData["CreateAlert"] = "Student Detail Added sucessfully";
                    return RedirectToAction("ViewStudentDetails");
                    
                }
                else
                {
                    int id = studentDetails.StudentId;
                    var studentDetailTable = studentDb.student_Detail_Table.Where(x => x.Student_Id == id && x.Is_Deleted == false).SingleOrDefault();        
                    //studentDetailTable.Student_Id = studentDetails.StudentId;
                    studentDetailTable.First_Name = studentDetails.FirstName;
                    studentDetailTable.Last_Name = studentDetails.LastName;
                    studentDetailTable.Date_of_Birth = studentDetails.DateOfBirth;
                    studentDetailTable.Age = studentDetails.Age;
                    studentDetailTable.Favorite_Subject = studentDetails.FavoriteSubject;
                    studentDetailTable.Intersted_Course = studentDetails.InterstedCourse;
                    studentDetailTable.Maths_Mark = studentDetails.MathsMark;
                    studentDetailTable.Chemistry_Mark = studentDetails.ChemistryMark;
                    studentDetailTable.Computer_Science_Mark = studentDetails.ComputerScienceMark;
                    //Must three column                
                    studentDetailTable.Update_Time_stamp = DateTime.Now;
             
                    studentDb.SaveChanges();
                }
               
                //return RedirectToAction("ViewStudentDetails");
            }

            return RedirectToAction("ViewStudentDetails");
        }

#endregion
       
        #region Delete
        public ActionResult DeleteStudentDetails(int id)
        {
            using (var studentDb = new StudentDBContainer())
            {
                var studentDetailTable = studentDb.student_Detail_Table.Where(x => x.Student_Id == id && x.Is_Deleted == false).SingleOrDefault();
                if (studentDetailTable != null)
                {
                    studentDetailTable.Is_Deleted = true;
                    studentDb.SaveChanges();
                    TempData["DeleteAlert"] = "Student Detail is deleted";
                }
                return RedirectToAction("ViewStudentDetails");
            }
        }

        #endregion

        #region Student List
        public ActionResult ViewStudentDetails()
        {

            List<StudentDetails> studentDetailList = new List<StudentDetails>();
            using (var studentDb = new StudentDBContainer())
            {
                var studentDetailTable = studentDb.student_Detail_Table.Where(x => x.Is_Deleted == false).ToList();
                if (studentDetailTable != null)
                {
                    foreach (var item in studentDetailTable)
                    {
                        StudentDetails studentDetails = new StudentDetails();
                        studentDetails.StudentId = item.Student_Id;
                        studentDetails.FirstName = item.First_Name;
                        studentDetails.LastName = item.Last_Name;
                        studentDetails.DateOfBirth = item.Date_of_Birth ;
                        studentDetails.Age = item.Age;
                        studentDetails.FavoriteSubject = item.Favorite_Subject;
                        studentDetails.InterstedCourse= item.Intersted_Course;
                        studentDetails.MathsMark= item.Maths_Mark;
                        studentDetails.ChemistryMark= item.Chemistry_Mark;
                        studentDetails.ComputerScienceMark= item.Computer_Science_Mark;
                        studentDetailList.Add(studentDetails);
                    }
                }
            }
            return View(studentDetailList);
           
        }


        #endregion

    }
}