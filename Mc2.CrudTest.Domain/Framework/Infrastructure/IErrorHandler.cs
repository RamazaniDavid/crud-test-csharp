using System;

namespace Mc2.CrudTest.Framework.Infrastructure
{
    public interface IErrorHandler
    {
        string ErrorMessage { get; set; }
        int StatusCode { get; set; }

        void GetError(Exception ex);
    }
}