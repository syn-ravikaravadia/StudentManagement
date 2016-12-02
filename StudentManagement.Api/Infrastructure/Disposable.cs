using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Api.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCore()
        {

        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        ~Disposable()
        {
            Dispose(false);
        }
    }
}