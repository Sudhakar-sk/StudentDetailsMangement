using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentDetailsMangement.Models
{
    public class StudentDetails
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int Age { get; set; }
        public string FavoriteSubject { get; set; }
        public string InterstedCourse { get; set; }
        public int MathsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int ComputerScienceMark { get; set; }
    }
}