﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Model.StoreModal;
using GMS_System.Services;
using GMS_System.WebAPI.Filters;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public partial class AppointmentController : ControllerBase
    {
        #region variable declaration
        private IConfiguration configuration;
        private readonly string _connectioSting;
        private readonly string _radisCacheServerAddress;
        #endregion

        #region Cunstructor
        public AppointmentController(IConfiguration _iConfig)
        {
            configuration = _iConfig;
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            _radisCacheServerAddress = configuration.GetValue<string>("radishCache");
        }
        #endregion

        #region Custom Methods 
        [HttpPost]
        [Route("GetAppointmentList")]
        public ResponseModel GetAppointmentList(string AppDate)
        {
            List<AppointmentModel> objAppointmentList = new List<AppointmentModel>();
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

                objAppointmentList = newAppointment.GetAppointmentList(new AppointmentServices(_connectioSting), authenticate.TenantId,authenticate.UserMasterID, AppDate);

                statusCode =
                objAppointmentList.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objAppointmentList;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }

        [HttpPost]
        [Route("GetAppointmentCount")]
        public ResponseModel GetAppointmentCount()
        {
            List<AppointmentCount> objAppointmentCount = new List<AppointmentCount>();
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

                objAppointmentCount = newAppointment.GetAppointmentCountList(new AppointmentServices(_connectioSting), authenticate.TenantId, authenticate.UserMasterID);

                statusCode =
                objAppointmentCount.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);

                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objAppointmentCount;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;



        }

        [HttpPost]
        [Route("UpdateAppointmentStatus")]
        public ResponseModel UpdateAppointmentStatus([FromBody]AppointmentCustomer appointment)
        {
            AppointmentCaller newAppointment = new AppointmentCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int StatusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                int result = newAppointment.updateAppoinment(new AppointmentServices(_connectioSting), appointment, authenticate.TenantId);
                StatusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)StatusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = StatusCode;
                objResponseModel.Message = statusMessage;

            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }



        #region TimeSlotMaster CRUD


        /// <summary>
        /// Insert/ Update HSTimeSlotMaster
        /// </summary>
        /// <param name="StoreTimeSlotInsertUpdate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertUpdateTimeSlotMaster")]
        public ResponseModel InsertUpdateTimeSlotMaster([FromBody]StoreTimeSlotInsertUpdate Slot)
        {
            List<AlreadyScheduleDetail> alreadyScheduleDetails = new List<AlreadyScheduleDetail>();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0; int ResultCount = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                Slot.TenantId = authenticate.TenantId;
                Slot.ProgramCode = authenticate.ProgramCode;
                Slot.CreatedBy = authenticate.UserMasterID;
                Slot.ModifyBy= authenticate.UserMasterID;

                AppointmentCaller newAppointment = new AppointmentCaller();

                ResultCount = newAppointment.InsertUpdateTimeSlotMaster(new AppointmentServices(_connectioSting), Slot);

                statusCode =  ResultCount .Equals(0) ? (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = ResultCount;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }


        /// <summary>
        /// Delete HSTimeSlotMaster
        /// </summary>
        /// <param name="SlotID"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("DeleteTimeSlotMaster")]
        public ResponseModel DeleteTimeSlotMaster(int SlotID)
        {
            List<AlreadyScheduleDetail> alreadyScheduleDetails = new List<AlreadyScheduleDetail>();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0; int ResultCount = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                AppointmentCaller newAppointment = new AppointmentCaller();

                ResultCount = newAppointment.DeleteTimeSlotMaster(new AppointmentServices(_connectioSting), SlotID,authenticate.TenantId);

                statusCode = ResultCount.Equals(0) ? (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = ResultCount;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }


        /// <summary>
        /// Get HSTimeSlotMaster List
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("GetStoreTimeSlotMasterList")]
        public ResponseModel GetStoreTimeSlotMasterList(int StoreID=0)
        {
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            List<StoreTimeSlotMasterModel> TimeSlotList = new List<StoreTimeSlotMasterModel>();
           string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]); 
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                AppointmentCaller newAppointment = new AppointmentCaller();

                TimeSlotList = newAppointment.GetStoreTimeSlotMasterList(new AppointmentServices(_connectioSting), authenticate.TenantId,authenticate.ProgramCode, StoreID);

                statusCode = TimeSlotList.Count.Equals(0) ? (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = TimeSlotList;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }


        #endregion 

        #endregion
    }
}