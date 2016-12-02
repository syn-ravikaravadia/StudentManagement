namespace StudentManagement.Api.Migrations
{
    using StudentManagement.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGradeTable : DbMigration
    {
        public override void Up()
        {
            StudentManagementApiContext context = new StudentManagementApiContext();
            var grades = new List<Grades>{
                new Grades { GradeId = 1, Grade = "AAA", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
                new Grades { GradeId = 1, Grade = "BBB", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
                new Grades { GradeId = 1, Grade = "CCC", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now },
                new Grades { GradeId = 1, Grade = "DDD", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now }
            };

            grades.ForEach(s => context.Grades.Add(s));
            context.SaveChanges();
        }
        
        public override void Down()
        {
        }
    }
}
