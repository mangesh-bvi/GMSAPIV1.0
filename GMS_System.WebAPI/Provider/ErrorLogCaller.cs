using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public class ErrorLogCaller
    {
        #region Variable
        public IErrorLogging _IErrorLogging;
        #endregion

        public int AddErrorLog(IErrorLogging errorLogging, ErrorLog errorLog)
        {
            _IErrorLogging = errorLogging;
            return _IErrorLogging.InsertErrorLog(errorLog);
        }
    }
}
