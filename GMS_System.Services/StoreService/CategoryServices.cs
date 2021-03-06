﻿using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace GMS_System.Services
{
    public partial class CategoryServices : ICategory
    {
        
        /// <summary>
        /// Claim Category List
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public List<CustomCreateCategory> ClaimCategoryList(int TenantId)
        {
            DataSet ds = new DataSet();
            List<CustomCreateCategory> listCategoryMapping = new List<CustomCreateCategory>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_ClaimCategoryList", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomCreateCategory CreateCategory = new CustomCreateCategory
                        {
                            BrandCategoryMappingID = ds.Tables[0].Rows[i]["BrandCategoryMappingID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["BrandCategoryMappingID"]),
                            BraindID = ds.Tables[0].Rows[i]["BrandID"] == DBNull.Value ? "0" : Convert.ToString(ds.Tables[0].Rows[i]["BrandID"]),
                            BrandName = ds.Tables[0].Rows[i]["BrandName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["BrandName"]),
                            CategoryID = ds.Tables[0].Rows[i]["CategoryID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"]),
                            CategoryName = ds.Tables[0].Rows[i]["CategoryName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CategoryName"]),
                            SubCategoryID = ds.Tables[0].Rows[i]["SubCategoryID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"]),
                            SubCategoryName = ds.Tables[0].Rows[i]["SubCategoryName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["SubCategoryName"]),
                            IssueTypeID = ds.Tables[0].Rows[i]["IssueTypeID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["IssueTypeID"]),
                            IssueTypeName = ds.Tables[0].Rows[i]["IssueTypeName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["IssueTypeName"]),
                            StatusName = ds.Tables[0].Rows[i]["IsActive"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["IsActive"]),
                            Status = ds.Tables[0].Rows[i]["IsActive"] == DBNull.Value ? false : Convert.ToString(ds.Tables[0].Rows[i]["IsActive"]).Equals("Active") ? true : false
                        };
                        listCategoryMapping.Add(CreateCategory);
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
            return listCategoryMapping;
        }

     
        /// <summary>
        /// Get Claim Category List
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name="BrandID"></param>
        /// <returns></returns>
        public List<Category> GetClaimCategoryList(int TenantID, int BrandID)
        {

            DataSet ds = new DataSet();
            List<Category> categoryList = new List<Category>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimCategoryList", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Tenant_Id", TenantID);
                cmd.Parameters.AddWithValue("@Brand_ID", BrandID);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Category category = new Category
                            {
                                CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"]),
                                CategoryName = Convert.ToString(ds.Tables[0].Rows[i]["CategoryName"]),
                                IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"])
                            };

                            categoryList.Add(category);
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
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return categoryList;
        }

        /// <summary>
        /// Get ClaimCategory By Search
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public List<Category> GetClaimCategoryBySearch(int TenantID, string CategoryName)
        {

            DataSet ds = new DataSet();
            List<Category> categoryList = new List<Category>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimCategoryBySearch", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Tenant_Id", TenantID);
                cmd.Parameters.AddWithValue("@_CategoryName", CategoryName);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Category category = new Category
                            {
                                CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"]),
                                CategoryName = Convert.ToString(ds.Tables[0].Rows[i]["CategoryName"]),
                                IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"])
                            };

                            categoryList.Add(category);
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
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return categoryList;
        }


        /// <summary>
        /// Add Claim Category
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="BrandID"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int AddClaimCategory(string CategoryName, int BrandID, int TenantID, int UserID)
        {
            int Success = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_InsertClaimCategory", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@Category_Name", CategoryName);
                cmd.Parameters.AddWithValue("@Brand_ID", BrandID);
                cmd.Parameters.AddWithValue("@Created_By", UserID);
                
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
        /// Get Sub Category By Category ID
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public List<SubCategory> GetClaimSubCategoryByCategoryID(int CategoryID, int TypeId)
        {

            DataSet ds = new DataSet();
            List<SubCategory> objSubCategory = new List<SubCategory>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimSubCategoriesByCategoryId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("@Type_Id", TypeId);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SubCategory SubCat = new SubCategory
                        {
                            SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"]),
                            CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"]),
                            SubCategoryName = Convert.ToString(ds.Tables[0].Rows[i]["SubCategoryName"]),
                            IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"])
                        };

                        objSubCategory.Add(SubCat);
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
            return objSubCategory;
        }

        /// <summary>
        /// GetClaimSubCategoryByCategoryOnSearch
        /// </summary>
        /// <param name="tenantID"></param>
        /// <param name="CategoryID"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<SubCategory> GetClaimSubCategoryByCategoryOnSearch(int tenantID, int CategoryID, string searchText)
        {
            DataSet ds = new DataSet();
            List<SubCategory> objSubCategory = new List<SubCategory>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimSubCategoryByCategoryIdOnSearch", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@tenant_ID", tenantID);
                cmd.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("@search_Text", searchText);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SubCategory SubCat = new SubCategory
                        {
                            SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"]),
                            CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"]),
                            SubCategoryName = Convert.ToString(ds.Tables[0].Rows[i]["SubCategoryName"]),
                            IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"])
                        };

                        objSubCategory.Add(SubCat);
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
            return objSubCategory;
        }

        /// <summary>
        /// Add Claim Sub Category
        /// </summary>
        /// <param name="CategoryID">ID of the category </param>
        /// <param name="SubCategoryName">Name of the Sub-category</param>
        /// <param name="TenantID">Id of the Tenant</param>
        /// <param name="UserID">Id of the User</param>
        /// <returns></returns>
        public int AddClaimSubCategory(int CategoryID, string SubCategoryName, int TenantID, int UserID)
        {
            int subCategoryId = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_InsertClaimSubCategory", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategory_Name", SubCategoryName);
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@Created_By", UserID);
                subCategoryId = Convert.ToInt32(cmd.ExecuteScalar());
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

            return subCategoryId;
        }


        /// <summary>
        /// Get Claim Issue Type List
        /// </summary>
        /// <param name="TenantID">Tenant Id</param>
        /// <param name="SubCategoryID">SubCategory ID</param>
        /// <returns></returns>
        public List<IssueType> GetClaimIssueTypeList(int TenantID, int SubCategoryID)
        {
            DataSet ds = new DataSet();
            List<IssueType> objIssueType = new List<IssueType>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimIssueTypeList", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategoryID);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IssueType issueType = new IssueType
                        {
                            IssueTypeID = Convert.ToInt32(ds.Tables[0].Rows[i]["IssueTypeID"]),
                            TenantID = Convert.ToInt32(ds.Tables[0].Rows[i]["TenantID"]),
                            IssueTypeName = Convert.ToString(ds.Tables[0].Rows[i]["IssueTypeName"]),
                            SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"]),
                            IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"])
                        };
                        objIssueType.Add(issueType);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return objIssueType;
        }

        /// <summary>
        /// GetClaimIssueTypeOnSearch
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name="SubCategoryID"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<IssueType> GetClaimIssueTypeOnSearch(int TenantID, int SubCategoryID, string searchText)
        {
            DataSet ds = new DataSet();
            List<IssueType> objIssueType = new List<IssueType>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_GetClaimIssueTypeOnSearch", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategoryID);
                cmd.Parameters.AddWithValue("@search_Text", searchText);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IssueType issueType = new IssueType
                        {
                            IssueTypeID = Convert.ToInt32(ds.Tables[0].Rows[i]["IssueTypeID"]),
                            IssueTypeName = Convert.ToString(ds.Tables[0].Rows[i]["IssueTypeName"]),
                            SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"])
                        };
                        //brand.CreatedByName = Convert.ToString(ds.Tables[0].Rows[i]["dd"]);

                        objIssueType.Add(issueType);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return objIssueType;
        }


        /// <summary>
        /// Add Claim Issue Type
        /// </summary>
        /// <param name="SubcategoryID"></param>
        /// <param name="IssuetypeName"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int AddClaimIssueType(int SubcategoryID, string IssuetypeName, int TenantID, int UserID)
        {
            int Success = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_InsertClaimIssueType", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubcategoryID);
                cmd.Parameters.AddWithValue("@Issuetype_Name", IssuetypeName);
                cmd.Parameters.AddWithValue("@Tenant_ID", TenantID);
                cmd.Parameters.AddWithValue("@Created_By", UserID);
                Success = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
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
        /// Create Category BrandMapping/update /soft delete 
        /// </summary>
        /// <param name="CustomCreateCategory"></param>
        /// <returns></returns>
        public int CreateClaimCategorybrandmapping(CustomCreateCategory customCreateCategory)
        {
            int Success = 0;
            if (customCreateCategory.BrandCategoryMappingID == 0)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SP_CreateClaimCategoryBrandMapping", conn)
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Braind_ID", customCreateCategory.BraindID);
                    cmd.Parameters.AddWithValue("@Category_ID", customCreateCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@SubCategory_ID", customCreateCategory.SubCategoryID);
                    cmd.Parameters.AddWithValue("@IssueType_ID", customCreateCategory.IssueTypeID);
                    cmd.Parameters.AddWithValue("@Is_Active", customCreateCategory.Status);
                    cmd.Parameters.AddWithValue("@Created_By", customCreateCategory.CreatedBy);
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
            }
            if (customCreateCategory.BrandCategoryMappingID > 0)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SP_UpdateClaimCategoryBrandMapping", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@BrandCategoryMapping_ID", customCreateCategory.BrandCategoryMappingID);
                    cmd.Parameters.AddWithValue("@Braind_ID", customCreateCategory.BraindID);
                    cmd.Parameters.AddWithValue("@Category_ID", customCreateCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@SubCategory_ID", customCreateCategory.SubCategoryID);
                    cmd.Parameters.AddWithValue("@IssueType_ID", customCreateCategory.IssueTypeID);
                    cmd.Parameters.AddWithValue("@Is_Active", customCreateCategory.Status);
                    cmd.Parameters.AddWithValue("@Created_By", customCreateCategory.CreatedBy);
                    cmd.Parameters.AddWithValue("@Delete_flag", customCreateCategory.Deleteflag);
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

            }
            return Success;
        }


        /// <summary>
        /// Delete Claim Category
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public int DeleteClaimCategory(int CategoryID, int TenantId)
        {
            int k = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("SP_DeleteClaimCategory", conn);
                cmd1.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd1.Parameters.AddWithValue("@Tenant_ID", TenantId);
                cmd1.CommandType = CommandType.StoredProcedure;
                k = Convert.ToInt32(cmd1.ExecuteNonQuery());
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

            return k;
        }

        /// <summary>
        /// Bulk Upload Claim Category
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name="CreatedBy"></param>
        /// <param name="CategoryFor"></param>
        /// <param name="DataSetCSV"></param>
        /// <returns></returns>
        public List<string> BulkUploadClaimCategory(int TenantID, int CreatedBy, int CategoryFor, DataSet DataSetCSV)
        {
            XmlDocument xmlDoc = new XmlDocument();
            DataSet Bulkds = new DataSet();
            List<string> csvLst = new List<string>();
            string SuccessFile = string.Empty; string ErrorFile = string.Empty;
            try
            {
                if (DataSetCSV != null && DataSetCSV.Tables.Count > 0)
                {
                    if (DataSetCSV.Tables[0] != null && DataSetCSV.Tables[0].Rows.Count > 0)
                    {

                        xmlDoc.LoadXml(DataSetCSV.GetXml());
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SP_ClaimCategoryBulkUpload", conn);

                        cmd.Parameters.AddWithValue("@_xml_content", xmlDoc.InnerXml);
                        cmd.Parameters.AddWithValue("@_node", Xpath);
                        cmd.Parameters.AddWithValue("@_tenantID", TenantID);
                        cmd.Parameters.AddWithValue("@Created_By", CreatedBy);
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter
                        {
                            SelectCommand = cmd
                        };
                        da.Fill(Bulkds);

                        if (Bulkds != null && Bulkds.Tables[0] != null && Bulkds.Tables[1] != null)
                        {
                            //for success file
                            SuccessFile = Bulkds.Tables[0].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[0]) : string.Empty;
                            csvLst.Add(SuccessFile);

                            //for error file
                            ErrorFile = Bulkds.Tables[1].Rows.Count > 0 ? CommonService.DataTableToCsv(Bulkds.Tables[1]) : string.Empty;
                            csvLst.Add(ErrorFile);
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

    }
}
