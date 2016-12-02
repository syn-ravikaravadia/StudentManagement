using StudentManagement.Api.Infrastructure;
using StudentManagement.Api.Repository;
using StudentManagement.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagement.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Private Variable

        private ApplicationService _applicationService;

        #endregion

        #region Constructor

        public BaseApiController()
        {
            Dispose();
        }
        #endregion


        #region Destructor

        ~BaseApiController()
        {
            Dispose();
        }

        #endregion

        
        #region Property

        protected ApplicationService ApplicationService
        {
            get
            {
                if (_applicationService == null)
                {
                    var databaseFactory = new DatabaseFactory();

                    _applicationService = new ApplicationService(new GradeRepository(databaseFactory),
                                                                 new StudentRepository(databaseFactory));
                }
                return _applicationService;
            }
        }

        #endregion
    }
}
