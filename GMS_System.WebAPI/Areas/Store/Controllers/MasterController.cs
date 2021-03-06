﻿using System;
using System.Collections.Generic;
using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Model.StoreModal;
using GMS_System.Services;
using GMS_System.Services.StoreServices;
using GMS_System.WebAPI.Filters;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public class MasterController : ControllerBase
    {
        #region variable declaration
        private IConfiguration configuration;
        private readonly string connectioSting;
        private readonly string radisCacheServerAddress;
        #endregion

        #region Constructor
        public MasterController(IConfiguration iConfig)
        {
            configuration = iConfig;
            connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            radisCacheServerAddress = configuration.GetValue<string>("radishCache");
        }
        #endregion

        /// <summary>
        /// Get Store User List
        /// </summary>
        [HttpPost]
        [Route("getStoreDepartmentList")]
        public ResponseModel getStoreDepartmentList()
        {
            List<StoreDepartmentModel> objDepartmentList = new List<StoreDepartmentModel>();
            ResponseModel objResponseModel = new ResponseModel();
            int StatusCode = 0;
            string statusMessage = "";
            try
            {
                string _token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(radisCacheServerAddress, SecurityService.DecryptStringAES(_token));

                MasterCaller newMasterBrand = new MasterCaller();

                objDepartmentList = newMasterBrand.GetStoreDepartmentList(new StoreDepartmentService(connectioSting), authenticate.TenantId);

                StatusCode =
                objDepartmentList.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)StatusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = StatusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objDepartmentList;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Store User List
        /// </summary>
        [HttpPost]
        [Route("getStoreUserList")]
        public ResponseModel getStoreUserList()
        {
            List<StoreUser> objUserList = new List<StoreUser>();

            ResponseModel objResponseModel = new ResponseModel();
            int StatusCode = 0;
            string statusMessage = "";
            try
            {
                ////Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                MasterCaller newMasterBrand = new MasterCaller();

                objUserList = newMasterBrand.GetStoreUserList(new MasterService(connectioSting), authenticate.TenantId, authenticate.UserMasterID);

                StatusCode =
                objUserList.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)StatusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = StatusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objUserList;


            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }


        /// <summary>
        /// Get Store User List
        /// </summary>
        [HttpPost]
        [Route("getStoreFunctionList")]
        public ResponseModel getStoreFunctionList()
        {
            List<StoreFunctionModel> objUserList = new List<StoreFunctionModel>();

            ResponseModel objResponseModel = new ResponseModel();
            int StatusCode = 0;
            string statusMessage = "";
            try
            {
                ////Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                MasterCaller newMasterBrand = new MasterCaller();

                objUserList = newMasterBrand.GetStoreFunctionList(new MasterService(connectioSting), authenticate.TenantId, authenticate.UserMasterID);

                StatusCode =
                objUserList.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)StatusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = StatusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objUserList;


            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }
    }
}
