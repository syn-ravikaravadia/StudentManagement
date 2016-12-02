namespace StudentManagement.Api.Migrations
{
    using StudentManagement.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagement.Api.StudentManagementApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManagement.Api.StudentManagementApiContext context)
        {
            //// Add grades
            //var grades = new List<Grades>{
            //    new Grades { GradeId = 1, Grade = "AAA", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
            //    new Grades { GradeId = 1, Grade = "BBB", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
            //    new Grades { GradeId = 1, Grade = "CCC", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
            //    new Grades { GradeId = 1, Grade = "DDD", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now }
            //};

            //grades.ForEach(s => context.Grades.Add(s));
            //context.SaveChanges();
        }
    }
}
