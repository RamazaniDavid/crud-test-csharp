using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Framework.Infrastructure
{
    public class ErrorHandler : IErrorHandler
    {
        public string ErrorMessage { get; set; } = "Error";
        public int StatusCode { get; set; } = 500;
        public void GetError(Exception ex)
        {
            ErrorMessage = "Error - Please contact to server administrator";
            if (ex.GetType() == typeof(DivideByZeroException))
            {
                ErrorMessage = "Divide By Zero Error";
                StatusCode = 521;
            }
            if (ex.GetType() == typeof(System.Security.Cryptography.CryptographicException))
            {
                ErrorMessage = "Cryptographic Error";
                StatusCode = 522;
            }


            if (ex.GetType() == typeof(FormatException))
            {
                ErrorMessage = "Format Error";
                StatusCode = 523;
            }
            if (ex is SqlException exception)
            {

                ErrorMessage = "DB Error";
                ErrorMessage = GetSqlServerError(exception);
            }
            if (ex.GetType() == typeof(DbUpdateConcurrencyException))
            {
                ErrorMessage = "DB Update Error";
            }
            if (ex.GetType() == typeof(DbUpdateException))
            {
                SqlException exsql = ex.InnerException as SqlException;
                ErrorMessage = GetSqlServerError(exsql);
            }

        }

        private string GetSqlServerError(SqlException exsql)
        {

            if (exsql.Number == 515)
            {
                ErrorMessage = "Some Field is Required";
                StatusCode = 530;
            }
            if (exsql.Number == 2627)
            {
                ErrorMessage = "Duplicate Error";
                StatusCode = 531;
            }
            if (exsql.Number == 547)
            {
                ErrorMessage = "";
                StatusCode = 532;
            }
            if (exsql.Number == 0 || exsql.Number == 2 || exsql.Number == -2)
            {
                ErrorMessage = "";
                StatusCode = 533;
            }
            return ErrorMessage;
        }
    }


}
