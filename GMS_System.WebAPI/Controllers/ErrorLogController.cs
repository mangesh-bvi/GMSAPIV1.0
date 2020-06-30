﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.CustomModel;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMS_System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        [HttpGet]
        [Route("ReturnException")]
        public ResponseModel ReturnException()
        {
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            statusCode = (int)EnumMaster.StatusCode.InternalServerError;
            statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
            objResponseModel.Status = true;
            objResponseModel.StatusCode = statusCode;
            objResponseModel.Message = statusMessage;
            objResponseModel.ResponseData = null;
            return objResponseModel;
        }
    }
}