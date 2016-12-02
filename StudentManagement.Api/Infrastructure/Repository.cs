using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Infrastructure
{
    public abstract class Repository<T> where T : class
    {

        private StudentManagementApiContext _studentManagementApiContext;
        protected IDatabaseFactory DatabaseFactory { get; private set; }


        protected StudentManagementApiContext StudentApiContext
        {
            get { return _studentManagementApiContext ?? (_studentManagementApiContext = DatabaseFactory.Get()); }
        }

        //protected BaseRepository(IDatabaseFactory databaseFactory)
        //{
        //    DatabaseFactory = databaseFactory;
        //}

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            DbSet = StudentApiContext.Set<T>();
        }

        
        protected IDbSet<T> DbSet { get; private set; }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _studentManagementApiContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Detach(T entity)
        {
            _studentManagementApiContext.Entry(entity).State = EntityState.Detached;
        }
    }
}