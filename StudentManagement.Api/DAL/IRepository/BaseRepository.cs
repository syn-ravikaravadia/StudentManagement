using StudentManagement.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Repository
{
    public class BaseRepository
    {
        private StudentManagementApiContext _studentManagementApiContext;
        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected StudentManagementApiContext StudentApiContext
        {
            get { return _studentManagementApiContext ?? (_studentManagementApiContext = DatabaseFactory.Get()); }
        }
    }
}