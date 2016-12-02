using StudentManagement.Api.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web;

namespace StudentManagement.Api.Service
{
    public partial class ApplicationService
    {
        public IStudentRepository StudentRepository;
        public IGradeRepository GradeRepository;

        [Inject]
        public ApplicationService(IGradeRepository _gradeRepository, IStudentRepository _studentRepository)
        {
            GradeRepository = _gradeRepository;
            StudentRepository = _studentRepository;
        }
    }
}