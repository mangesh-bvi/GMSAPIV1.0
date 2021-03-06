﻿using GMS_System.CustomModel;
using GMS_System.Model;
using System.Collections.Generic;
using System.Data;

namespace GMS_System.Interface
{
    /// <summary>
    /// Interface for the Category
    /// </summary>
    public partial interface ICategory
    {
        
        List<CustomCreateCategory> ClaimCategoryList(int TenantId);
        
        List<Category> GetClaimCategoryList(int TenantID, int BrandID);

        List<Category> GetClaimCategoryBySearch(int TenantID, string CategoryName);

        int AddClaimCategory(string CategoryName, int BrandID, int TenantID, int UserID);

        List<SubCategory> GetClaimSubCategoryByCategoryID(int CategoryID, int TypeId);

        List<SubCategory> GetClaimSubCategoryByCategoryOnSearch(int tenantID, int CategoryID, string searchText);

        int AddClaimSubCategory(int CategoryID, string category, int TenantID, int UserID);

        List<IssueType> GetClaimIssueTypeList(int TenantID, int SubCategoryID);

        List<IssueType> GetClaimIssueTypeOnSearch(int TenantID, int SubCategoryID, string searchText);

        int AddClaimIssueType(int SubcategoryID, string IssuetypeName, int TenantID, int UserID);

        int CreateClaimCategorybrandmapping(CustomCreateCategory customCreateCategory);

        int DeleteClaimCategory(int CategoryID, int TenantId);

        List<string> BulkUploadClaimCategory(int TenantID, int CreatedBy, int CategoryFor, DataSet DataSetCSV);

    }
}
