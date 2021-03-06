﻿using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Services;
using GMS_System.WebAPI.Filters;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    public class StoreClaimController : ControllerBase
    {
        #region variable declaration
        private IConfiguration configuration;
        private readonly string _radisCacheServerAddress;
        private readonly string _connectionSting;
        private readonly string _ClaimProductImage;
        private readonly string rootPath;
        #endregion

        #region Constructor
        public StoreClaimController(IConfiguration _iConfig)
        {
            configuration = _iConfig;
            _connectionSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            _radisCacheServerAddress = configuration.GetValue<string>("radishCache");
            _ClaimProductImage = configuration.GetValue<string>("RaiseClaimProductImage");
            rootPath = configuration.GetValue<string>("APIURL");
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Raise Claim
        /// </summary>
        /// <param name="">IFormFile</param>
        /// <param name="">storeClaimMaster</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RaiseClaim")]
        public ResponseModel RaiseClaim(IFormFile File)
        {
            StoreClaimMaster storeClaimMaster = new StoreClaimMaster();
            OrderMaster orderDetails = new OrderMaster();
            List<OrderItem> OrderItemDetails = new List<OrderItem>();
            var files = Request.Form.Files;
            string timeStamp = DateTime.Now.ToString("ddmmyyyyhhssfff");
            string fileName = "";
            string finalAttchment = "";
            string ImagePath = string.Empty;

            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    fileName += files[i].FileName.Replace(".", timeStamp + ".") + ",";
                }
                finalAttchment = fileName.TrimEnd(',');
            }
            var Keys = Request.Form;
            storeClaimMaster = JsonConvert.DeserializeObject<StoreClaimMaster>(Keys["storeClaimMaster"]);
            // get order details from form
            orderDetails = JsonConvert.DeserializeObject<OrderMaster>(Keys["orderDetails"]);
            OrderItemDetails = JsonConvert.DeserializeObject<List<OrderItem>>(Keys["orderItemDetails"]);

            //var exePath = Path.GetDirectoryName(System.Reflection
            //        .Assembly.GetExecutingAssembly().CodeBase);
            //Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            //var appRoot = appPathMatcher.Match(exePath).Value;
            // string folderpath = rootPath + _ClaimProductImage;
            string Folderpath = Directory.GetCurrentDirectory();
            string[] filesName = finalAttchment.Split(",");


            ImagePath = Path.Combine(Folderpath, _ClaimProductImage);

            if (!Directory.Exists(ImagePath))
            {
                Directory.CreateDirectory(ImagePath);
            }

            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";

            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                #region check orderdetails and item details 

                if (orderDetails != null)
                {

                    if (orderDetails.OrderMasterID.Equals(0))
                    {

                        string OrderNumber = string.Empty;
                        string OrderItemsIds = string.Empty;
                        OrderMaster objorderMaster = null;

                        OrderCaller ordercaller = new OrderCaller();
                        //call insert order
                        orderDetails.CreatedBy = authenticate.UserMasterID;
                        OrderNumber = ordercaller.addOrder(new OrderService(_connectionSting), orderDetails, authenticate.TenantId);
                        if (!string.IsNullOrEmpty(OrderNumber))
                        {
                            objorderMaster = ordercaller.getOrderDetailsByNumber(new OrderService(_connectionSting), OrderNumber, authenticate.TenantId);


                            if (objorderMaster != null)
                            {
                                if (OrderItemDetails != null)
                                {
                                    foreach (var item in OrderItemDetails)
                                    {
                                        item.OrderMasterID = objorderMaster.OrderMasterID;
                                        item.InvoiceDate = orderDetails.InvoiceDate;
                                    }

                                    OrderItemsIds = ordercaller.AddOrderItem(new OrderService(_connectionSting), OrderItemDetails, authenticate.TenantId, authenticate.UserMasterID);

                                }
                                else
                                {
                                    OrderItemsIds = Convert.ToString(objorderMaster.OrderMasterID) + "|0|1";
                                    //OrderItemsIds = Convert.ToString(objorderMaster.OrderMasterID) + "|1";
                                }

                            }

                            storeClaimMaster.OrderMasterID = objorderMaster.OrderMasterID;
                            storeClaimMaster.OrderItemID = OrderItemsIds;
                        }

                    }


                }
                #endregion

                StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
                storeClaimMaster.TenantID = authenticate.TenantId;
                storeClaimMaster.CreatedBy = authenticate.UserMasterID;
                int result = storeClaimCaller.InsertRaiseClaim(new StoreClaimService(_connectionSting), storeClaimMaster, finalAttchment);
                if (result > 0)
                {

                    if (files.Count > 0)
                    {
                        //string[] filesName = finalAttchment.Split(",");
                        for (int i = 0; i < files.Count; i++)
                        {
                            try
                            {
                                using (var ms = new MemoryStream())
                                {
                                    files[i].CopyTo(ms);
                                    var fileBytes = ms.ToArray();
                                    MemoryStream msfile = new MemoryStream(fileBytes);
                                    FileStream docFile = new FileStream(Path.Combine(ImagePath, filesName[i]), FileMode.Create, FileAccess.Write);
                                    msfile.WriteTo(docFile);
                                    docFile.Close();
                                    ms.Close();
                                    msfile.Close();
                                    string s = Convert.ToBase64String(fileBytes);
                                    byte[] a = Convert.FromBase64String(s);
                                    // act on the Base64 data

                                }
                                //using (var ms = new MemoryStream())
                                //{
                                //    files[i].CopyTo(ms);
                                //    var fileBytes = ms.ToArray();
                                //    MemoryStream msfile = new MemoryStream(fileBytes);
                                //    FileStream docFile = new FileStream(folderpath + "/" + filesName[i], FileMode.Create, FileAccess.Write);
                                //    msfile.WriteTo(docFile);
                                //    docFile.Close();
                                //    ms.Close();
                                //    msfile.Close();
                                //    string s = Convert.ToBase64String(fileBytes);
                                //    byte[] a = Convert.FromBase64String(s);
                                //    // act on the Base64 data

                                //}
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
                statusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = result;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Add Store Claim Comment
        /// </summary>
        /// <param name="claimID"></param>
        /// <param name="comment"></param>
        /// <param name="oldAssignID"></param>
        /// <param name="newAssignID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddStoreClaimComment")]
        public ResponseModel AddStoreClaimComment(int claimID, string comment, int oldAssignID, int newAssignID, bool iSTicketingComment)
        {
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                int result = storeClaimCaller.AddClaimComment(new StoreClaimService(_connectionSting), claimID, comment, authenticate.UserMasterID, oldAssignID, newAssignID, iSTicketingComment);
                statusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;

            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Claim Comment By ClaimID
        /// </summary>
        /// <param name="claimID"></param>
        [HttpPost]
        [Route("GetClaimCommentByClaimID")]
        public ResponseModel GetClaimCommentByClaimID(int claimID)
        {
            List<UserComment> objClaimComment = new List<UserComment>();
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                objClaimComment = storeClaimCaller.GetClaimComment(new StoreClaimService(_connectionSting), claimID);
                statusCode =
                   objClaimComment.Count == 0 ?
                           (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objClaimComment;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Claim List
        /// </summary>
        /// <param name="tab_For"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetClaimList")]
        public ResponseModel GetClaimList(int tab_For)
        {
            List<CustomClaimList> objClaimMaster = new List<CustomClaimList>();
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                objClaimMaster = storeClaimCaller.GetClaimList(new StoreClaimService(_connectionSting), tab_For, authenticate.TenantId, authenticate.UserMasterID);
                statusCode =
                   objClaimMaster.Count == 0 ?
                           (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objClaimMaster;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Claim By ID
        /// </summary>
        /// <param name="ClaimID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetClaimByID")]
        public ResponseModel GetClaimByID(int ClaimID)
        {
            CustomClaimByID objClaimMaster = new CustomClaimByID();
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                string url = configuration.GetValue<string>("APIURL") + _ClaimProductImage;
                objClaimMaster = storeClaimCaller.GetClaimByID(new StoreClaimService(_connectionSting), ClaimID, authenticate.TenantId, authenticate.UserMasterID, url);
                statusCode =
                   objClaimMaster == null ?
                           (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objClaimMaster;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Store Claim Comment By Approvel
        /// </summary>
        /// <param name="claimID"></param>
        /// <param name="comment"></param>
        /// <param name="iSRejectComment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("StoreClaimCommentByApprovel")]
        public ResponseModel StoreClaimCommentByApprovel(int claimID, string comment, bool iSRejectComment)
        {
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                int result = storeClaimCaller.AddClaimCommentByApprovel(new StoreClaimService(_connectionSting), claimID, comment, authenticate.UserMasterID, iSRejectComment);
                statusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;

            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Claim Comment For Approvel
        /// </summary>
        /// <param name="claimID"></param>
        [HttpPost]
        [Route("GetClaimCommentForApprovel")]
        public ResponseModel GetClaimCommentForApprovel(int claimID)
        {
            List<CommentByApprovel> objClaimComment = new List<CommentByApprovel>();
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));
                objClaimComment = storeClaimCaller.GetClaimCommentForApprovel(new StoreClaimService(_connectionSting), claimID);
                statusCode =
                   objClaimComment.Count == 0 ?
                           (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objClaimComment;
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Claim Approve Or Reject
        /// </summary>
        /// <param name="claimID"></param>
        /// <param name="finalClaimAsked"></param>
        /// <param name="IsApprove"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IsClaimApprove")]
        public ResponseModel IsClaimApprove(int claimID, double finalClaimAsked, bool IsApprove)
        {
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                int result = storeClaimCaller.ClaimApprove(new StoreClaimService(_connectionSting), claimID, finalClaimAsked, IsApprove, authenticate.UserMasterID, authenticate.TenantId);
                statusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;

            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Claim Re Assign
        /// </summary>
        /// <param name=""></param>
        ///    <param name="claimID"></param>
        ///   <param name="assigneeID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ClaimReAssign")]
        public ResponseModel ClaimReAssign(int claimID, int assigneeID)
        {
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                int result = storeClaimCaller.AssignClaim(new StoreClaimService(_connectionSting), claimID, assigneeID, authenticate.UserMasterID, authenticate.TenantId);
                statusCode =
                result == 0 ?
                       (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;

            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        /// <summary>
        /// Get Order and Customer Detail By TicketID
        /// </summary>
        /// <param name="ticketID"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOrderwithCustomerDetailByTicketID")]
        public ResponseModel GetOrderandCustomerDetailByTicketID(int ticketID)
        {
            List<CustomOrderwithCustomerDetails> objorderMaster = new List<CustomOrderwithCustomerDetails>();
            StoreClaimCaller storeClaimCaller = new StoreClaimCaller();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                objorderMaster = storeClaimCaller.GetOrderDetailByticketID(new StoreClaimService(_connectionSting), ticketID, authenticate.TenantId);
                statusCode =
                   objorderMaster.Count == 0 ?
                           (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;

                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);


                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objorderMaster;

            }
            catch (Exception)
            {
                throw;
            }

            return objResponseModel;
        }

        /// <summary>
        /// UserListDropdown
        /// </summary>
        /// <param name="assignID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ClaimAssignDropdown")]
        public ResponseModel ClaimAssignDropdown(int assignID)
        {
            List<CustomStoreUserList> objUserList = new List<CustomStoreUserList>();
            ResponseModel objResponseModel = new ResponseModel();
            int statusCode = 0;
            string statusMessage = "";
            try
            {
                StoreClaimCaller storeClaimCaller = new StoreClaimCaller();

                string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
                Authenticate authenticate = new Authenticate();
                authenticate = SecurityService.GetAuthenticateDataFromToken(_radisCacheServerAddress, SecurityService.DecryptStringAES(token));

                objUserList = storeClaimCaller.UserList(new StoreClaimService(_connectionSting), assignID, authenticate.TenantId);
                statusCode =
                objUserList.Count == 0 ?
                     (int)EnumMaster.StatusCode.RecordNotFound : (int)EnumMaster.StatusCode.Success;
                statusMessage = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)statusCode);
                objResponseModel.Status = true;
                objResponseModel.StatusCode = statusCode;
                objResponseModel.Message = statusMessage;
                objResponseModel.ResponseData = objUserList;
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