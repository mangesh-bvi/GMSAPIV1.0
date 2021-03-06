﻿using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace GMS_System.Services
{
    public class StoreService : IStore
    {
        #region variable
        public static string Xpath = "//NewDataSet//Table1";
        CustomResponse ApiResponse = null;
        string apiResponse = string.Empty;
        string apisecurityToken = string.Empty;
        string apiURL = string.Empty;

        #endregion
        #region Cunstructor
        MySqlConnection conn = new MySqlConnection();
        public StoreService(string _connectionString)
        {
            conn.ConnectionString = _connectionString;
            apisecurityToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJQcm9ncmFtQ29kZSI6IkJhdGEiLCJVc2VySUQiOiIzIiwiQXBwSUQiOiI3IiwiRGF5IjoiMjgiLCJNb250aCI6IjMiLCJZZWFyIjoiMjAyMSIsIlJvbGUiOiJBZG1pbiIsImlzcyI6IkF1dGhTZWN1cml0eUlzc3VlciIsImF1ZCI6IkF1dGhTZWN1cml0eUF1ZGllbmNlIn0.0XeF7V5LWfQn0NlSlG7Rb-Qq1hUCtUYRDg6dMGIMvg0";
            apiURL = "http://searchapi.ercx.co/api/Search/";
        }

        /// <summary>
        ///Attach Store
        /// <param name="AttachStore"></param>
        /// <param name="TicketId"></param>
        /// <param name="CreatedBy"></param>
        /// </summary>
        public int AttachStore(string StoreId, int TicketId, int CreatedBy)
        {
            int Success = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_BulkTicketStoreattachMapping", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Ticket_Id", TicketId);
                cmd.Parameters.AddWithValue("@StoreIds", StoreId);
                cmd.Parameters.AddWithValue("@Created_By", CreatedBy);
                cmd.CommandType = CommandType.StoredProcedure;
                Success = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return Success;
        }

        /// <summary>
        /// Create Store
        /// </summary>
        /// <param name="StoreMaster"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int CreateStore(StoreMaster storeMaster, int TenantID, int UserID)
        {

            int storeId = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_InsertStore", conn);
                cmd.Connection = conn;
                //cmd.Parameters.AddWithValue("@Brand_ID", storeMaster.BrandID);
                cmd.Parameters.AddWithValue("@Store_Code", storeMaster.StoreCode);
                cmd.Parameters.AddWithValue("@Store_Name", string.IsNullOrEmpty(storeMaster.StoreName) ? "" : storeMaster.StoreName);
                cmd.Parameters.AddWithValue("@State_ID", storeMaster.StateID);
                cmd.Parameters.AddWithValue("@City_ID", storeMaster.CityID);
                cmd.Parameters.AddWithValue("@Pincode_ID", storeMaster.Pincode);
                cmd.Parameters.AddWithValue("@Store_Address", storeMaster.Address);
                cmd.Parameters.AddWithValue("@Region_ID", storeMaster.RegionID);
                cmd.Parameters.AddWithValue("@Zone_ID", storeMaster.ZoneID);
                cmd.Parameters.AddWithValue("@StoreType_ID", storeMaster.StoreTypeID);
                cmd.Parameters.AddWithValue("@StoreEmail_ID", storeMaster.StoreEmailID);
                cmd.Parameters.AddWithValue("@StorePhone_No", storeMaster.StorePhoneNo);
                cmd.Parameters.AddWithValue("@Is_Active", storeMaster.IsActive);
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@User_ID", UserID);
                cmd.Parameters.AddWithValue("@BrandIDs", storeMaster.BrandIDs);
                cmd.CommandType = CommandType.StoredProcedure;
                storeId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return storeId;
        }


        /// <summary>
        /// Delete Store 
        /// </summary>
        /// <param name="StoreID"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int DeleteStore(int StoreID, int TenantID, int UserID)
        {

            int success = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_DeleteStore", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Store_ID", StoreID);
                cmd.Parameters.AddWithValue("@tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@User_ID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                success = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return success;
        }

        /// <summary>
        /// Edit Store
        /// </summary>
        /// <param name="storeMaster"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int EditStore(StoreMaster storeMaster, int TenantID, int UserID)
        {
            int Success = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_UpdateStore", conn);
                cmd.Connection = conn;
                //cmd.Parameters.AddWithValue("@Brand_ID", storeMaster.BrandID);
                cmd.Parameters.AddWithValue("@Store_Code", storeMaster.StoreCode);
                cmd.Parameters.AddWithValue("@Store_Name", storeMaster.StoreName);
                cmd.Parameters.AddWithValue("@State_ID", storeMaster.StateID);
                cmd.Parameters.AddWithValue("@City_ID", storeMaster.CityID);
                cmd.Parameters.AddWithValue("@Pincode_ID", storeMaster.PincodeID);
                cmd.Parameters.AddWithValue("@Store_Address", storeMaster.Address);
                cmd.Parameters.AddWithValue("@Region_ID", storeMaster.RegionID);
                cmd.Parameters.AddWithValue("@Zone_ID", storeMaster.ZoneID);
                cmd.Parameters.AddWithValue("@StoreType_ID", storeMaster.StoreTypeID);
                cmd.Parameters.AddWithValue("@StoreEmail_ID", storeMaster.StoreEmailID);
                cmd.Parameters.AddWithValue("@StorePhone_No", storeMaster.StorePhoneNo);
                cmd.Parameters.AddWithValue("@Is_Active", storeMaster.IsActive);
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@User_ID", UserID);
                cmd.Parameters.AddWithValue("@Store_ID", storeMaster.StoreID);
                cmd.Parameters.AddWithValue("@BrandIDs", storeMaster.BrandIDs);
                cmd.CommandType = CommandType.StoredProcedure;
                Success = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }


            return Success;
        }

        /// <summary>
        /// get StoreDetail By Storecode OR Pincode
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="tenantID"></param>
        public List<StoreMaster> getStoreDetailByStorecodenPincode(string searchText, int tenantID)
        {
            List<StoreMaster> storeMaster = new List<StoreMaster>();
            MySqlCommand cmd = new MySqlCommand();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                MySqlCommand cmd1 = new MySqlCommand("SP_getStoreSDetialwithStorenamenPincode", conn);
                cmd1.Parameters.AddWithValue("@searchText", searchText);
                cmd1.Parameters.AddWithValue("@Tenant_Id", tenantID);
                cmd1.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                da.SelectCommand = cmd1;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            StoreMaster store = new StoreMaster();
                            store.StoreCode = ds.Tables[0].Rows[i]["StoreCode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreCode"]);
                            store.StoreName = ds.Tables[0].Rows[i]["StoreName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreName"]);
                            store.Pincode = ds.Tables[0].Rows[i]["PincodeID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["PincodeID"]);
                            store.StoreEmailID = ds.Tables[0].Rows[i]["StoreEmailID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreEmailID"]);
                            store.Address = ds.Tables[0].Rows[i]["Address"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                            store.StoreID = Convert.ToInt32(ds.Tables[0].Rows[i]["StoreID"]);
                            //store.StoreVisitDate= ds.Tables[0].Rows[i]["StoreVisitDate"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreVisitDate"]);
                            //store.Purpose= ds.Tables[0].Rows[i]["Purpose"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["Purpose"]);
                            storeMaster.Add(store);
                        }
                    }
                    else
                    {
                        storeMaster = GetStoreDetaisFromAPI(searchText);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return storeMaster;
        }



        /// <summary>
        /// Get list of the Stores details from LPASS API
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<StoreMaster> GetStoreDetaisFromAPI(string searchText)
        {
            List<StoreMaster> storeMaster = new List<StoreMaster>();
            CustomStoreSearch objStore = new CustomStoreSearch();
            List<CustomStoreDetails> objStoreDetails = new List<CustomStoreDetails>();
            try
            {
                objStore.programCode = "bata";
                objStore.storeAddressPin = searchText;

                objStore.securityToken = apisecurityToken;
                objStore.userID = 3;
                objStore.appID = 7;

                string apiReq = JsonConvert.SerializeObject(objStore);
                apiResponse = CommonService.SendApiRequest(apiURL + "StoreDetails", apiReq);

                if (!string.IsNullOrEmpty(apiResponse))
                {
                    ApiResponse = JsonConvert.DeserializeObject<CustomResponse>(apiResponse);

                    if (ApiResponse != null)
                    {

                        objStoreDetails = JsonConvert.DeserializeObject<List<CustomStoreDetails>>(Convert.ToString((ApiResponse.Responce)));

                        if (objStoreDetails.Count > 0)
                        {
                            for (int k = 0; k < objStoreDetails.Count; k++)
                            {
                                StoreMaster store = new StoreMaster();
                                store.StoreCode = objStoreDetails[k].StoreCode;
                                store.StoreName = objStoreDetails[k].StoreCode;// no store name provided in the api response hence mapped storecode mapped as per req
                                store.Pincode = objStoreDetails[k].StorePinCode;
                                store.StoreEmailID = objStoreDetails[k].StoreEmailId;
                                store.Address = objStoreDetails[k].StoreAddress;
                                store.StoreID = 0;
                                store.LpassStoreID = objStoreDetails[k].StoreId;


                                storeMaster.Add(store);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return storeMaster;
        }


        /// <summary>
        /// Get list of the Stores
        /// </summary>
        /// <param name="searchText"></param>
        ///  <param name="tenantID"></param>
        /// <returns></returns>
        public List<StoreMaster> getStores(string searchText, int tenantID)
        {
            List<StoreMaster> storeMaster = new List<StoreMaster>();
            MySqlCommand cmd = new MySqlCommand();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                MySqlCommand cmd1 = new MySqlCommand("SP_getStores", conn);
                cmd1.Parameters.AddWithValue("@Tenant_Id", tenantID);
                cmd1.Parameters.AddWithValue("@searchText", searchText);
                cmd1.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                da.SelectCommand = cmd1;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        StoreMaster store = new StoreMaster();
                        store.StoreID = Convert.ToInt32(ds.Tables[0].Rows[i]["StoreID"]);
                        store.StoreName = Convert.ToString(ds.Tables[0].Rows[i]["StoreName"]);
                        store.Address = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);

                        storeMaster.Add(store);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return storeMaster;
        }

        /// <summary>
        /// Search Store
        /// <param name="StateID"></param>
        /// <param name="PinCode"></param>
        /// <param name="Area"></param>
        ///  <param name="IsCountry"></param>
        /// </summary>
        public List<StoreMaster> SearchStore(int StateID, int PinCode, string Area, bool IsCountry)
        {
            List<StoreMaster> storeMaster = new List<StoreMaster>();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_SearchStore", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@State_ID", StateID);
                cmd.Parameters.AddWithValue("@Pin_Code", PinCode);
                cmd.Parameters.AddWithValue("@Store_Area", Area);
                cmd.Parameters.AddWithValue("@Is_Country", IsCountry);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        StoreMaster store = new StoreMaster();
                        store.StoreID = Convert.ToInt32(ds.Tables[0].Rows[i]["StoreID"]);
                        store.StoreName = Convert.ToString(ds.Tables[0].Rows[i]["StoreName"]);
                        store.StoreCode = Convert.ToString(ds.Tables[0].Rows[i]["StoreCode"]);
                        store.StorePhoneNo = Convert.ToString(ds.Tables[0].Rows[i]["StoreCode"]);
                        //store.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[i][""]);
                        storeMaster.Add(store);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return storeMaster;
        }

        /// <summary>
        /// Get list of Stores
        /// </summary>
        /// <param name="TenantID">Id of the Tenant</param>
        /// <returns></returns>
        public List<CustomStoreList> StoreList(int TenantID)
        {
            List<CustomStoreList> storeMaster = new List<CustomStoreList>();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetStoreList", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Tenant_Id", TenantID);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomStoreList store = new CustomStoreList();
                        store.StoreID = ds.Tables[0].Rows[i]["StoreID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["StoreID"]);
                        store.StoreName = ds.Tables[0].Rows[i]["StoreName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreName"]);
                        store.StoreCode = ds.Tables[0].Rows[i]["StoreCode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreCode"]);
                        //store.BranName = Convert.ToString(ds.Tables[0].Rows[i]["BrandName"]);
                        store.CityName = ds.Tables[0].Rows[i]["CityName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CityName"]);
                        store.StateName = ds.Tables[0].Rows[i]["StateName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StateName"]);
                        store.strPinCode = ds.Tables[0].Rows[i]["PincodeID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["PincodeID"]);
                        store.Status = ds.Tables[0].Rows[i]["StoreStatus"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreStatus"]);

                        store.Address = ds.Tables[0].Rows[i]["Address"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                        store.PhoneNumber = ds.Tables[0].Rows[i]["StorePhoneNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StorePhoneNo"]);
                        store.Email = ds.Tables[0].Rows[i]["StoreEmailID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreEmailID"]);

                        store.CityID = ds.Tables[0].Rows[i]["CityID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["CityID"]);
                        store.StateID = ds.Tables[0].Rows[i]["StateID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["StateID"]);
                        store.RegionID = ds.Tables[0].Rows[i]["RegionID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["RegionID"]);
                        store.ZoneID = ds.Tables[0].Rows[i]["ZoneID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["ZoneID"]);
                        store.StoreTypeID = ds.Tables[0].Rows[i]["StoreTypeID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["StoreTypeID"]);
                        store.StatusID = Convert.ToBoolean(ds.Tables[0].Rows[i]["StatusID"]);
                        store.BrandIDs = ds.Tables[0].Rows[i]["BrandIDs"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["BrandIDs"]);
                        store.BrandNames = ds.Tables[0].Rows[i]["BrandNames"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["BrandNames"]);
                        store.Brand_Names = ds.Tables[0].Rows[i]["Brand_Names"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Brand_Names"]);

                        storeMaster.Add(store);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return storeMaster;
        }

        /// <summary>
        /// Get list of Stores
        /// </summary>
        /// <param name="TicketId">Id of the Ticket</param>
        /// <returns></returns>
        public List<StoreMaster> getSelectedStoreByTicketId(int TicketId)
        {
            List<StoreMaster> storeMaster = new List<StoreMaster>();
            DataSet ds = new DataSet();
            string GMT = " GMT+0530 (" + TimeZoneInfo.Local.StandardName + ")";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetSelectedStoresByTicketID", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Ticket_ID", TicketId);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        StoreMaster store = new StoreMaster();
                        store.StoreCode = ds.Tables[0].Rows[i]["StoreCode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreCode"]);
                        store.StoreName = ds.Tables[0].Rows[i]["StoreName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreName"]);
                        store.Pincode = ds.Tables[0].Rows[i]["Pincode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Pincode"]);
                        store.StoreEmailID = ds.Tables[0].Rows[i]["StoreEmailID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreEmailID"]);
                        store.Address = ds.Tables[0].Rows[i]["Address"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                        store.StoreID = Convert.ToInt32(ds.Tables[0].Rows[i]["StoreID"]);
                        store.StoreVisitDate = ds.Tables[0].Rows[i]["StoreVisitDate"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StoreVisitDate"]) + GMT;
                        store.Purpose = ds.Tables[0].Rows[i]["Purpose"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["Purpose"]);
                        storeMaster.Add(store);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return storeMaster;
        }

        /// <summary>
        /// Bulk Upload Store
        /// <param name="TenantID"></param>
        /// <param name="CreatedBy"></param>
        /// <param name="DataSetCSV"></param>
        /// </summary>

        public List<string> BulkUploadStore(int TenantID, int CreatedBy, DataSet DataSetCSV)
        {

            XmlDocument xmlDoc = new XmlDocument();
            List<string> csvLst = new List<string>();
            string SuccesFile = string.Empty; string ErroFile = string.Empty;
            DataSet Bulkds = new DataSet();
            try
            {
                if (DataSetCSV != null && DataSetCSV.Tables.Count > 0)
                {
                    if (DataSetCSV.Tables[0] != null && DataSetCSV.Tables[0].Rows.Count > 0)
                    {

                        xmlDoc.LoadXml(DataSetCSV.GetXml());

                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SP_BulkUploadStore", conn);
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@_xml_content", xmlDoc.InnerXml);
                        cmd.Parameters.AddWithValue("@_node", Xpath);
                        //cmd.Parameters.AddWithValue("@_StoreFor", RoleFor);
                        cmd.Parameters.AddWithValue("@_tenantID", TenantID);
                        cmd.Parameters.AddWithValue("@_createdBy", CreatedBy);
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(Bulkds);

                        if (Bulkds != null && Bulkds.Tables[0] != null && Bulkds.Tables[1] != null)
                        {

                            //for success file
                            SuccesFile = Bulkds.Tables[0].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[0]) : string.Empty;
                            csvLst.Add(SuccesFile);

                            //for error file
                            ErroFile = Bulkds.Tables[1].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[1]) : string.Empty;
                            csvLst.Add(ErroFile);

                        }
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (DataSetCSV != null)
                {
                    DataSetCSV.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return csvLst;
        }


        /// <summary>
        /// Create Campaign Script
        /// <param name="CampaignScript"></param>
        /// </summary>
        public int CreateCampaignScript(CampaignScript campaignScript)
        {
            int result = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_CreateCampaignScript", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tenant_ID", campaignScript.TenantID);
                cmd.Parameters.AddWithValue("@User_ID", campaignScript.CreatedBy);
                cmd.Parameters.AddWithValue("@Campaign_Name", campaignScript.CampaignName);
                cmd.Parameters.AddWithValue("@Script_Details", campaignScript.ScriptDetails);

                result = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Update Claim Attachment Setting
        /// <param name="ClaimAttechment"></param>
        /// </summary>
        public int UpdateClaimAttechmentSetting(ClaimAttechment claimAttechment)
        {
            int result = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_UpdateClaimAttechment", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tenant_ID", claimAttechment.TenantID);
                cmd.Parameters.AddWithValue("@Max_Size", claimAttechment.MaximumSize);
                cmd.Parameters.AddWithValue("@File_Format", claimAttechment.FileFormat);

                result = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }


        /// <summary>
        /// Bulk Upload User 
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name="CreatedBy"></param>
        /// <param name="UserFor"></param>
        /// <param name="DataSetCSV"></param>
        public List<string> BulkUploadUser(int TenantID, int CreatedBy, int UserFor, DataSet DataSetCSV)
        {
            XmlDocument xmlDoc = new XmlDocument();
            DataSet Bulkds = new DataSet();
            List<string> csvLst = new List<string>();
            MySqlCommand cmd = null;
            string SuccesFile = string.Empty; string ErroFile = string.Empty;
            try
            {
                if (DataSetCSV != null && DataSetCSV.Tables.Count > 0)
                {
                    if (DataSetCSV.Tables[0] != null && DataSetCSV.Tables[0].Rows.Count > 0)
                    {

                        //check if user ulpoad or brandcategory mapping
                        xmlDoc.LoadXml(DataSetCSV.GetXml());
                        conn.Open();


                        string[] dtColumns = Array.ConvertAll(DataSetCSV.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray(), d => d.ToLower());

                        if (dtColumns.Contains("username"))
                        {
                            cmd = new MySqlCommand("SP_BulkUploadStoreUser", conn);
                            cmd.Parameters.AddWithValue("@_tenantID", TenantID);
                            cmd.Parameters.AddWithValue("@_UserFor", UserFor);

                        }
                        else
                        {
                            cmd = new MySqlCommand("SP_BulkUploadStoreBrandCategoryMapping", conn);
                        }

                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@_xml_content", xmlDoc.InnerXml);
                        cmd.Parameters.AddWithValue("@_node", Xpath);
                        cmd.Parameters.AddWithValue("@_createdBy", CreatedBy);
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(Bulkds);

                        if (Bulkds != null && Bulkds.Tables[0] != null && Bulkds.Tables[1] != null)
                        {

                            //for success file
                            SuccesFile = Bulkds.Tables[0].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[0]) : string.Empty;
                            csvLst.Add(SuccesFile);

                            //for error file
                            ErroFile = Bulkds.Tables[1].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[1]) : string.Empty;
                            csvLst.Add(ErroFile);

                        }
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (DataSetCSV != null)
                {
                    DataSetCSV.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return csvLst;
        }
        #endregion
    }
}