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
using StudentManagement.Api.Repository;

namespace StudentManagement.Api.Controllers
{
    public class GradesController : BaseApiController
    {
        private StudentManagementApiContext db = new StudentManagementApiContext();

        // GET: api/Grades
        //public IQueryable<Grades> GetGrades()
        //{
        //    return db.Grades;
        //}

        public async Task<IHttpActionResult> GetGrades()
        {
            //GradeRepository objGradeRepository = new GradeRepository();
            List<Grades> lstGrades = ApplicationService.GradeRepository.GetAllGrades();

            if (lstGrades != null)
            {
                return Ok(lstGrades);
            }
            else
            {
                return NotFound();
            }
        }

        //// GET: api/Grades/5
        //[ResponseType(typeof(Grades))]
        //public async Task<IHttpActionResult> GetGrades(int id)
        //{
        //    Grades grades = await db.Grades.FindAsync(id);
        //    if (grades == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(grades);
        //}

        //// PUT: api/Grades/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutGrades(int id, Grades grades)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != grades.GradeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(grades).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GradesExists(id))
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

        //// POST: api/Grades
        //[ResponseType(typeof(Grades))]
        //public async Task<IHttpActionResult> PostGrades(Grades grades)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Grades.Add(grades);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = grades.GradeId }, grades);
        //}

        //// DELETE: api/Grades/5
        //[ResponseType(typeof(Grades))]
        //public async Task<IHttpActionResult> DeleteGrades(int id)
        //{
        //    Grades grades = await db.Grades.FindAsync(id);
        //    if (grades == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Grades.Remove(grades);
        //    await db.SaveChangesAsync();

        //    return Ok(grades);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GradesExists(int id)
        //{
        //    return db.Grades.Count(e => e.GradeId == id) > 0;
        //}
    }
}