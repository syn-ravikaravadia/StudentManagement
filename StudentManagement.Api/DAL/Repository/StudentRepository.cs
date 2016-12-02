using StudentManagement.Api.Infrastructure;
//using StudentManagement.Api.DAL;
using StudentManagement.Api.IRepository;
using StudentManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Repository
{
    //BaseRepository
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        // Save student
        public Student SaveStudentProfile(StudentViewModel studentViewModel)
        {
            Student student = new Student();

            try
            {
                if (studentViewModel != null)
                {
                    DateTime dtCurrentDate = DateTime.Now;
                    student.FirstName = studentViewModel.FirstName;
                    student.LastName = studentViewModel.LastName;
                    student.GradeId = studentViewModel.GradeId;
                    student.BirthDate = studentViewModel.BirthDate.AddDays(1);
                    student.CreatedOn = dtCurrentDate;
                    student.ModifiedOn = dtCurrentDate;

                    StudentApiContext.Students.Add(student);
                    StudentApiContext.SaveChanges();
                }   
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return student;
        }

        // Get all students
        public List<StudentViewModel> GetAllStudents()
        {
            List<StudentViewModel> lstResult = new List<StudentViewModel>();
            List<Student> lstStudent;
            List<Grades> lstGrades;

            try
            {
                lstStudent = StudentApiContext.Students.ToList();
                lstGrades = StudentApiContext.Grades.ToList();

                if(lstStudent != null && lstStudent.Count > 0 && lstGrades != null && lstGrades.Count > 0)
                {
                    lstResult = (from student in lstStudent
                                 join grades in lstGrades on student.GradeId equals grades.GradeId
                                 select new StudentViewModel()
                                 {
                                     StudentId = student.StudentId,
                                     FirstName = student.FirstName,
                                     LastName = student.LastName,
                                     GradeId = grades.GradeId,
                                     GradeName = grades.Grade
                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return lstResult;
        }

        // Get student details
        public Student GetStudentDetails(int studentId)
        {
            Student objStudent = new Student();
            try
            {
                objStudent = StudentApiContext.Students.Find(studentId);
                objStudent.BirthDate = objStudent.BirthDate.AddDays(-1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objStudent;
        }

        // Delete student
        public bool DeleteStudent(int studentId)
        {
            bool isSuccess = false;
            try
            {
                Student student = StudentApiContext.Students.Find(studentId);

                if (student != null)
                {
                    StudentApiContext.Students.Remove(student);
                    StudentApiContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }

        public bool UpdateStudentProfile(Student student)
        {
            bool isSuccess = false;
            try
            {
                Student objStudent = GetStudentDetails(student.StudentId);
                Detach(objStudent);
                //StudentApiContext.Entry(objStu5dent).State = EntityState.Detached;

                if (student != null)
                {
                    //objStudent = student;
                    student.ModifiedOn = DateTime.Now;
                    student.CreatedOn = objStudent.CreatedOn;
                    student.BirthDate = student.BirthDate.AddDays(1);

                    //StudentApiContext.Entry(student).State = EntityState.Modified;
                    Update(student);
                    StudentApiContext.SaveChanges();
                    
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }
    }
}