﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Framework.Infrastructure.Filters
{
    public class AddHeaderAttribute : Attribute,IAsyncResultFilter
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(_name, new string[] { _value });

            await next();
        }
    }
}
