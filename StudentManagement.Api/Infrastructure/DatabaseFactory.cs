using StudentManagement.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private StudentManagementApiContext _studentApiContext;

        public StudentManagementApiContext Get()
        {
            //return _studentApiContext ?? (_studentApiContext = new StudentManagementApiContext());

            if (_studentApiContext != null)
            {
                return _studentApiContext;
            }
            else
            {
                _studentApiContext = new StudentManagementApiContext();
                return _studentApiContext;
            }

            //_dbContext = new ModelContext();

            //return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_studentApiContext != null)
                _studentApiContext.Dispose();
        }


    }
}