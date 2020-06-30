using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GMS_System.Interface
{
    interface IExceptionFilter: IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
