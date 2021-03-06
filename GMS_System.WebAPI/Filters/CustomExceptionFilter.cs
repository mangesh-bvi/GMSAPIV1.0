﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GMS_System.Model;
using GMS_System.Services;
using Microsoft.AspNetCore.Authorization;
using GMS_System.WebAPI.Provider;
using GMS_System.Interface;
using GMS_System.CustomModel;
using Microsoft.AspNetCore.Routing;

namespace GMS_System.WebAPI.Filters
{
    //[Route("api/[controller]")]
   // [ApiController]
    //[Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public class CustomExceptionFilter : IExceptionFilter
    {
        #region variable declaration
        private IConfiguration configuration;
        private readonly string _connectioSting;
        private readonly string _ErconnectioSting;
        private readonly string _radisCacheServerAddress;
        #endregion
        public CustomExceptionFilter(IConfiguration _iConfig)
        {
            configuration = _iConfig;
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            _ErconnectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessErMasterMySqlProvider");
            _radisCacheServerAddress = configuration.GetValue<string>("radishCache");
        }
        public void OnException(ExceptionContext context)
        {
            var controllerName = (string)context.RouteData.Values["controller"];
            var actionName = (string)context.RouteData.Values["action"];
            string _token = Convert.ToString(context.HttpContext.Request.Headers["X-Authorized-Token"]);
            Authenticate authenticate = new Authenticate();
            authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(_token));

            var exceptionType = context.Exception.GetType();
            context.ExceptionHandled = true;
            ErrorLogCaller errorLogCaller = new ErrorLogCaller();
            ErrorLog errorLogs = new ErrorLog
            {
                ActionName = actionName,
                ControllerName = controllerName,
                TenantID = authenticate.TenantId,
                UserID = authenticate.UserMasterID,
                Exceptions = context.Exception.StackTrace,
                MessageException = context.Exception.Message,
                IPAddress = Convert.ToString(context.HttpContext.Connection.RemoteIpAddress)
            };
            int result = errorLogCaller.AddErrorLog(new ErrorLogging(_ErconnectioSting), errorLogs);
            context.Result = new RedirectToRouteResult(
             new RouteValueDictionary
             {
                    { "controller", "ErrorLog" },
                    { "action", "ReturnException" }
             });
        }
    }
}
