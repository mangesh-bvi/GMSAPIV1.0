﻿using GMS_System.Interface.StoreInterface;
using GMS_System.Model;
using GMS_System.Model.StoreModal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GMS_System.Services.StoreServices
{
    public class MasterService: IMaster
    {
        #region Constructor
        MySqlConnection conn = new MySqlConnection();
        public MasterService(string _connectionString)
        {
            conn.ConnectionString = _connectionString;
        }

        #endregion

        public List<StoreUser> GetStoreUserList(int TenantID, int UserID)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            List<StoreUser> users = new List<StoreUser>();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                MySqlCommand cmd1 = new MySqlCommand("SP_GetStoreUserFullName", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd1.Parameters.AddWithValue("@User_ID", UserID);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd1;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        StoreUser user = new StoreUser();
                        user.UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                        user.FullName = Convert.ToString(ds.Tables[0].Rows[i]["FullName"]);
                        user.ReporteeID = Convert.ToInt32(ds.Tables[0].Rows[i]["ReporteeID"]);
                        user.RoleID = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleID"]);
                        user.RoleName = Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]);

                        users.Add(user);
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
            }

            return users;
        }

        public List<StoreFunctionModel> GetStoreFunctionList(int TenantID, int UserID)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            List<StoreFunctionModel> users = new List<StoreFunctionModel>();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                MySqlCommand cmd1 = new MySqlCommand("SP_GetStoreUserFullName", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd1.Parameters.AddWithValue("@User_ID", UserID);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd1;
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        StoreFunctionModel user = new StoreFunctionModel();
                        user.FunctionID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                        user.FuncationName = Convert.ToString(ds.Tables[0].Rows[i]["FullName"]);
                        user.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"]);

                        users.Add(user);
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
            }

            return users;
        }
    }
}
