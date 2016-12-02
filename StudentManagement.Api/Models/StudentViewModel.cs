using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}