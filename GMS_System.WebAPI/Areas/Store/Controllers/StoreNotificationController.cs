﻿using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Services;
using GMS_System.WebAPI.Filters;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public class StoreNotificationController : ControllerBase
    {
        #region variable declaration
        private IConfiguration configuration;
        private readonly string connectioSting;
        private readonly string radisCacheServerAddress;
        #endregion
        #region Constructor
        public StoreNotificationController(IConfiguration iConfig)
        {
            configuration = iConfig;
            connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            radisCacheServerAddress = configuration.GetValue<string>("radishCache");
        }
        #endregion
        #region Custom Methods
        /// <summary>
        /// Get Notification
        /// </summary>
        /// 
        [HttpPost]
        [Route("GetStoreNotifications")]
        public ResponseModel GetStoreNotifications()
        {

            ResponseModel objResponseModel = new ResponseModel();
            ListStoreNotificationModels objresponseModel = new ListStoreNotificationModels();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                //Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                StoreNotificationCaller storeNotificationCaller = new StoreNotificationCaller();

                objresponseModel = storeNotificationCaller.GetNotification(new StoreNotificationService(connectioSting), authenticate.TenantId, authenticate.UserMasterID);
                statusCode = objresponseModel == null ? (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objresponseModel;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }

        /// <summary>
        /// ReadNotification
        /// <param name="NotificatonTypeID"></param>
        /// <param name="NotificatonType"></param> 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ReadStoreNotification")]
        public ResponseModel ReadStoreNotification(int NotificatonTypeID ,int NotificatonType )
        {
            int updatecount = 0;
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                ////Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                StoreNotificationCaller storeNotificationCaller = new StoreNotificationCaller();

                updatecount = storeNotificationCaller.ReadNotification(new StoreNotificationService(connectioSting), authenticate.TenantId, authenticate.UserMasterID, NotificatonTypeID, NotificatonType);

                statusCode = updatecount > 0 ? (int)EnumMaster.StatusCode.Success : (int)EnumMaster.StatusCode.InternalServiceNotWorking;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = updatecount;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }
        #endregion
    }
}