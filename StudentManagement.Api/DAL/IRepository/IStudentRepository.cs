using StudentManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.IRepository
{
    public interface IStudentRepository
    {
        Student SaveStudentProfile(StudentViewModel student);
        List<StudentViewModel> GetAllStudents();
        Student GetStudentDetails(int studentId);
        bool DeleteStudent(int studentId);
        bool UpdateStudentProfile(Student student);
    }
}