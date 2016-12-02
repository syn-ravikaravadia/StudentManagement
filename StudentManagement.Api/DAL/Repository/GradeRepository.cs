using StudentManagement.Api.Infrastructure;
using StudentManagement.Api.IRepository;
using StudentManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Repository
{
    public class GradeRepository : BaseRepository, IGradeRepository
    {

        public GradeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public List<Grades> GetAllGrades()
        {
            List<Grades> lstGrades = new List<Grades>();

            try
            {
                lstGrades = StudentApiContext.Grades.ToList(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstGrades;
        }
    }
}