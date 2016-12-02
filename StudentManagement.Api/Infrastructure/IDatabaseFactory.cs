using StudentManagement.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Api.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        StudentManagementApiContext Get();
    }
}
