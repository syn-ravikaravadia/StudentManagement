using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Models
{
    [Table("Student", Schema="dbo")]
    public class Student : BaseEntity
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int GradeId { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}