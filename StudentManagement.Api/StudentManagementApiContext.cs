using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace StudentManagement.Api
{
    public class StudentManagementApiContext : DbContext
    {
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudentManagementApiContext() : base("name=StudentManagementApiContext")
        {
            //Database.SetInitializer<StudentManagementApiContext>(new MigrateDatabaseToLatestVersion<StudentManagementApiContext, Configuration>(false));
        }

        public System.Data.Entity.DbSet<StudentManagement.Api.Models.Grades> Grades { get; set; }
        public System.Data.Entity.DbSet<StudentManagement.Api.Models.Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
    }
}
