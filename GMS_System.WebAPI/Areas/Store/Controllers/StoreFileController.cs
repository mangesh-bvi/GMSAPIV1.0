using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Services;
using GMS_System.WebAPI.Filters;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public class StoreFileController : ControllerBase
    {

        #region Variable Declaration
        private IConfiguration configuration;
        private readonly string _connectioSting;
        private readonly string _radisCacheServerAddress;
        private readonly string rootPath;
        #endregion

        #region Constructor


        public StoreFileController(IConfiguration _iConfig)
        {
            configuration = _iConfig;
            rootPath = configuration.GetValue<string>("APIURL");
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            _radisCacheServerAddress = configuration.GetValue<string>("radishCache");
        }
        #endregion
        #region Custom Methods 

        /// <summary>
        ///Get Store File UploadLogs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetStoreFileUploadLogs")]
        public ResponseModel GetStoreFileUploadLogs()
        {

            ResponseModel objResponseModel = new ResponseModel();
            List<FileUploadLogs> objresponseModel = new List<FileUploadLogs>();
            int statusCode = 0;
            string statusMessage = "";
            int fileuploadFor = 0;
            try
            {
                //Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                StoreFileUploadCaller storeFileUploadCaller = new StoreFileUploadCaller();
                objresponseModel = storeFileUploadCaller.GetFileUploadLogs(new StoreFileUploadService(_connectioSting, rootPath), authenticate.TenantId, fileuploadFor);
                statusCode = objresponseModel.Count == 0 ? (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
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

        #endregion


    }
}