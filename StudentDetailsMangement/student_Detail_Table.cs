//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDetailsMangement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class student_Detail_Table
    {
        [Key]
        public int Student_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public int Age { get; set; }
        public string Favorite_Subject { get; set; }
        public string Intersted_Course { get; set; }
        public int Maths_Mark { get; set; }
        public int Chemistry_Mark { get; set; }
        public int Computer_Science_Mark { get; set; }
        public bool Is_Deleted { get; set; }
        public System.DateTime Create_Time_Stamp { get; set; }
        public System.DateTime Update_Time_stamp { get; set; }
    }
}
