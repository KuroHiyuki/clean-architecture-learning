﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Application.Common.Errors
{
    public class EmailExistHandler : Exception, IExceptionService
    {
        public HttpStatusCode statusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists.";
    }
}
