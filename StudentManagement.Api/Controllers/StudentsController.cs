using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StudentManagement.Api.Models;
using StudentManagement.Api;

namespace StudentManagement.Api.Controllers
{
    public class StudentsController : BaseApiController
    {
        StudentManagementApiContext db = new StudentManagementApiContext();
        // GET: api/Students
        public async Task<IHttpActionResult> GetStudents()
        {
            List<StudentViewModel> lstStudents = ApplicationService.StudentRepository.GetAllStudents();

            if (lstStudents != null)
            {
                return Ok(lstStudents);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Students
        [Route("api/students/savestudent/")]
        [HttpPost]
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(StudentViewModel student)
        {
            Student savedStudent = new Student();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            savedStudent = ApplicationService.StudentRepository.SaveStudentProfile(student);

            if (savedStudent.StudentId == 0)
            {
                return NotFound();
            }

            return Ok(savedStudent);
        }

        // GET: api/Students/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student student = ApplicationService.StudentRepository.GetStudentDetails(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            bool isSuccess = ApplicationService.StudentRepository.DeleteStudent(id);

            return Ok(isSuccess);
        }

        // POST: api/Students/5
        [Route("api/students/updatestudent/")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            bool isSuccess;

            isSuccess = ApplicationService.StudentRepository.UpdateStudentProfile(student);

            return Ok(isSuccess);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        ////PUT: api/Students/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutStudent(int id, Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != student.StudentId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(student).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
    }
}