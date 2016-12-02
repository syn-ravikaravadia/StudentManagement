using StudentManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.IRepository
{
    public interface IGradeRepository
    {
        List<Grades> GetAllGrades();
    }
}