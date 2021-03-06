﻿using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Services;
using GMS_System.WebAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace GMS_System.WebAPI.Areas.Store.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    //[Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
    //[Authorize(AuthenticationSchemes = PermissionModuleConst.ModuleAuthenticationDefaultScheme)]
    public class StoreAccountController : ControllerBase
    {
        #region Variable
        private IConfiguration configuration;
        private readonly string _connectioSting;
        private readonly string _ErconnectioSting;
        private readonly string _radisCacheServerAddress;
        private readonly string BulkUpload;
        private readonly string UploadFiles;
        #endregion

        #region Constructor
        public StoreAccountController(IConfiguration _iConfig)
        {
            configuration = _iConfig;
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessMySqlProvider");
            _ErconnectioSting = configuration.GetValue<string>("ConnectionStrings:DataAccessErMasterMySqlProvider");
            _radisCacheServerAddress = configuration.GetValue<string>("radishCache");
            BulkUpload = configuration.GetValue<string>("BulkUpload");
            UploadFiles = configuration.GetValue<string>("Uploadfiles");
        }
        #endregion
        #region Custom Methos 

        #region Forgot password screen
        /// <summary>
        /// Forgot password screen
        /// </summary>
        /// <returns></returns>
        //Send mail for Forgot Password
        [HttpPost]
        [Route("ForgetPassword")]
        [AllowAnonymous]
        public ResponseModel ForgetPassword(string EmailId)
        {
            ResponseModel objResponseModel = new ResponseModel();

            try
            {
                string X_Authorized_Programcode = Convert.ToString(Request.Headers["X-Authorized-Programcode"]);
                string X_Authorized_Domainname = Convert.ToString(Request.Headers["X-Authorized-Domainname"]);
                string _data = "";
                if (X_Authorized_Programcode != null)
                {
                    X_Authorized_Programcode = SecurityService.DecryptStringAES(X_Authorized_Programcode);

                    RedisCacheService cacheService = new RedisCacheService(_radisCacheServerAddress);
                    if (cacheService.Exists("Con" + X_Authorized_Programcode))
                    {
                        _data = cacheService.Get("Con" + X_Authorized_Programcode);
                        _data = JsonConvert.DeserializeObject<string>(_data);
                    }
                }

                if (X_Authorized_Domainname != null)
                {
                    X_Authorized_Domainname = SecurityService.DecryptStringAES(X_Authorized_Domainname);
                }
                    /////Validate User
                    StoreSecurityCaller securityCaller = new StoreSecurityCaller();
                Authenticate authenticate = securityCaller.validateUserEmailId(new StoreSecurityService(_data, _radisCacheServerAddress), EmailId);
                if (authenticate.UserMasterID > 0)
                {
                    MasterCaller masterCaller = new MasterCaller();
                    SMTPDetails sMTPDetails = masterCaller.GetSMTPDetails(new MasterServices(_data), authenticate.TenantId);

                    EmailProgramCode emailProgramCode = new EmailProgramCode();
                    emailProgramCode.EmailID = EmailId;
                    emailProgramCode.ProgramCode= X_Authorized_Programcode;
                    string jsonData = JsonConvert.SerializeObject(emailProgramCode);


                    CommonService commonService = new CommonService();
                    string encryptedEmailId = commonService.Encrypt(jsonData);
                    // string url = configuration.GetValue<string>("websiteURL") + "/storeUserforgotPassword?Id:" + encryptedEmailId;
                    string url = X_Authorized_Domainname.TrimEnd('/') + "/storeUserforgotPassword?Id:" + encryptedEmailId;
                    // string body = "Hello, This is Demo Mail for testing purpose. <br/>" + url;

                    string content = "";
                    string subject = "";

                    securityCaller.GetForgetPassowrdMailContent(new StoreSecurityService(_data), authenticate.TenantId, url, EmailId, out content, out subject);

                    bool isUpdate = securityCaller.sendMail(new StoreSecurityService(_data), sMTPDetails, EmailId, subject, content, authenticate.TenantId);

                    if (isUpdate)
                    {
                        objResponseModel.Status = true;
                        objResponseModel.StatusCode = (int)EnumMaster.StatusCode.Success;
                        objResponseModel.Message = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)(int)EnumMaster.StatusCode.Success);
                        objResponseModel.ResponseData = "Mail sent successfully";
                    }
                    else
                    {
                        objResponseModel.Status = false;
                        objResponseModel.StatusCode = (int)EnumMaster.StatusCode.InternalServerError;
                        objResponseModel.Message = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)(int)EnumMaster.StatusCode.InternalServerError);
                        objResponseModel.ResponseData = "Mail sent failure";
                    }
                }
                else
                {
                    objResponseModel.Status = false;
                    objResponseModel.StatusCode = (int)EnumMaster.StatusCode.RecordNotFound;
                    objResponseModel.Message = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)(int)EnumMaster.StatusCode.RecordNotFound);
                    objResponseModel.ResponseData = "Sorry User does not exist or active";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }
        #endregion
        #region Update Password 
        /// <summary>
        /// Update Password
        /// </summary>
        /// <param name="cipherEmailId">Email Id in encrypted text</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePassword")]
        [AllowAnonymous]
        public ResponseModel UpdatePassword(string cipherEmailId, string Password)
        {
            ResponseModel objResponseModel = new ResponseModel();

            try
            {
                StoreSecurityCaller newSecurityCaller = new StoreSecurityCaller();

                CommonService commonService = new CommonService();

                EmailProgramCode bsObj= new EmailProgramCode();
                string encryptedEmailId = commonService.Decrypt(cipherEmailId);
                if(encryptedEmailId !=null)
                {
                     bsObj = JsonConvert.DeserializeObject<EmailProgramCode>(encryptedEmailId);
                }

                string _data = "";
                if (bsObj.ProgramCode != null)
                {
                   // bsObj.ProgramCode = SecurityService.DecryptStringAES(bsObj.ProgramCode);

                    RedisCacheService cacheService = new RedisCacheService(_radisCacheServerAddress);
                    if (cacheService.Exists("Con" + bsObj.ProgramCode))
                    {
                        _data = cacheService.Get("Con" + bsObj.ProgramCode);
                        _data = JsonConvert.DeserializeObject<string>(_data);
                    }
                }
                bool isUpdate = newSecurityCaller.UpdatePassword(new StoreSecurityService(_data), bsObj.EmailID, Password);

                if (isUpdate)
                {
                    objResponseModel.Status = true;
                    objResponseModel.StatusCode = (int)EnumMaster.StatusCode.Success;
                    objResponseModel.Message = CommonFunction.GetEnumDescription((EnumMaster.StatusCode)(int)EnumMaster.StatusCode.Success);
                    objResponseModel.ResponseData = "Update password successfully";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objResponseModel;
        }

        #endregion

        #region Authenticate User
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("authenticateUser")]
        [HttpPost]
        public ResponseModel AuthenticateUser()
        {
            string X_Authorized_Programcode = Convert.ToString(Request.Headers["X-Authorized-Programcode"]);
            string X_Authorized_userId = Convert.ToString(Request.Headers["X-Authorized-userId"]);
            string X_Authorized_password = Convert.ToString(Request.Headers["X-Authorized-password"]);
            string X_Authorized_Domainname = Convert.ToString(Request.Headers["X-Authorized-Domainname"]);

            ResponseModel resp = new ResponseModel();

            try
            {
                StoreSecurityCaller newSecurityCaller = new StoreSecurityCaller();
                AccountModal account = new AccountModal();
                string programCode = X_Authorized_Programcode.Replace(' ', '+');
                string domainName = X_Authorized_Domainname.Replace(' ', '+');
                string userId = X_Authorized_userId.Replace(' ', '+');
                string password = X_Authorized_password.Replace(' ', '+');

                string _data = "";
                if (X_Authorized_Programcode != null)
                {
                    X_Authorized_Programcode = SecurityService.DecryptStringAES(X_Authorized_Programcode);

                    RedisCacheService cacheService = new RedisCacheService(_radisCacheServerAddress);
                    if (cacheService.Exists("Con" + X_Authorized_Programcode))
                    {
                        _data = cacheService.Get("Con" + X_Authorized_Programcode);
                        _data = JsonConvert.DeserializeObject<string>(_data);
                    }
                }

                if (!string.IsNullOrEmpty(programCode) && !string.IsNullOrEmpty(domainName) && !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password))
                {
                    account = newSecurityCaller.validateUser(new StoreSecurityService(_data, _radisCacheServerAddress), programCode, domainName, userId, password);

                    if (!string.IsNullOrEmpty(account.Token))
                    {
                        account.IsActive = true;
                        resp.Status = true;
                        resp.StatusCode = (int)EnumMaster.StatusCode.Success;
                        resp.ResponseData = account;
                        resp.Message = "Valid Login";
                    }
                    else
                    {
                        account.IsActive = false;
                        resp.Status = true;
                        resp.StatusCode = (int)EnumMaster.StatusCode.Success;
                        resp.ResponseData = account;
                        resp.Message = "In-Valid Login";
                    }
                }
                else
                {
                    resp.Status = false;
                    resp.ResponseData = account;
                    resp.Message = "Invalid Login";

                }
            }
            catch (Exception)
            {
                throw;
            }
            return resp;
        }
        /// <summary>
        /// Logout Store User
        /// </summary>
        /// <returns></returns>
        [Route("Logout")]
        [HttpPost]
        public ResponseModel Logout()
        {
            ResponseModel resp = new ResponseModel();

            string token = Convert.ToString(Request.Headers["X-Authorized-Token"]);
            token = SecurityService.DecryptStringAES(token);

            RedisCacheService radisCacheService = new RedisCacheService(_radisCacheServerAddress);
            if (!radisCacheService.Exists(token))
            {
                radisCacheService.Remove(token);
            }

            StoreSecurityCaller newSecurityCaller = new StoreSecurityCaller();
            newSecurityCaller.Logout(new StoreSecurityService(_connectioSting), token);

            resp.Status = true;
            resp.StatusCode = (int)EnumMaster.StatusCode.Success;
            resp.ResponseData = null;
            resp.Message = "Logout Successfully!";

            return resp;
        }
        /// <summary>
        /// Validate Program code 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("validateprogramcode")]
        [HttpGet]
        public ResponseModel Validateprogramcode()
        {
            string X_Authorized_Programcode = Convert.ToString(Request.Headers["X-Authorized-Programcode"]);
            string X_Authorized_Domainname = Convert.ToString(Request.Headers["X-Authorized-Domainname"]);
            
            ResponseModel resp = new ResponseModel();
            try
            {
                //CreateFile("1 "+ X_Authorized_Programcode);
                StoreSecurityCaller newSecurityCaller = new StoreSecurityCaller();
                string programCode = X_Authorized_Programcode.Replace(' ', '+');
                string domainName = X_Authorized_Domainname.Replace(' ', '+');
                //CreateFile("2 " + X_Authorized_Domainname);
                if (!string.IsNullOrEmpty(programCode) && !string.IsNullOrEmpty(domainName))
                {
                    //CreateFile("3 " + _ErconnectioSting);
                    bool isValid = newSecurityCaller.validateProgramCode(new StoreSecurityService(_ErconnectioSting, _radisCacheServerAddress), programCode, domainName);
                    //CreateFile("4 isValid");
                    if (isValid)
                    {
                        resp.Status = true;
                        resp.StatusCode = (int)EnumMaster.StatusCode.Success;
                        resp.ResponseData = "";
                        resp.Message = "Valid Program code";
                    }
                    else
                    {
                        resp.Status = true;
                        resp.StatusCode = (int)EnumMaster.StatusCode.RecordNotFound;
                        resp.ResponseData = "";
                        resp.Message = "In-Valid Program code";
                    }
                }
                else
                {
                    resp.Status = false;
                    resp.ResponseData = "";
                    resp.Message = "In-valid Program code";
                }
            }
            catch (Exception ex)
            {
                //CreateFile(ex.ToString());
                throw;
            }
            return resp;
        }

        public void CreateFile(string contenttoprint)
        {
            string FilesPath = string.Empty;
            try
            {
                string Folderpath = Directory.GetCurrentDirectory();
                FilesPath = Path.Combine(Folderpath, BulkUpload, UploadFiles);

                if (!Directory.Exists(FilesPath))
                {
                    Directory.CreateDirectory(FilesPath);
                }

                string fileName = FilesPath + "/File_"+ DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")+".txt";
                //DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")

                CommonService.SaveFile(fileName, contenttoprint);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #endregion
    }
}