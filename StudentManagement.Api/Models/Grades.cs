using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Models
{
    [Table("Grade", Schema = "dbo")]
    public class Grades : BaseEntity
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [StringLength(3, MinimumLength = 3)]
        public string Grade { get; set; }
    }
}