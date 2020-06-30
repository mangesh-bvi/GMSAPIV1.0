using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Services;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public partial class AppointmentController : ControllerBase
    {
        /// <summary>
        /// GetStoreDetailsByStoreCode
        /// </summary>
        /// <param name="storeCode"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetStoreDetailsByStoreCode")]
        public ResponseModel GetStoreDetailsByStoreCode(string storeCode)
        {
            StoreDetails storeDetails = new StoreDetails();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                ////Get token (Double encrypted) and get the tenant id 
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                AppointmentCaller newAppointment = new AppointmentCaller();

                storeDetails = newAppointment.GetStoreDetailsByStoreCode(new AppointmentServices(_connectioSting), authenticate.TenantId, authenticate.UserMasterID, authenticate.ProgramCode, storeCode);

                statusCode =
                string.IsNullOrEmpty(storeDetails.StoreName) ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = storeDetails;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }
    }
}