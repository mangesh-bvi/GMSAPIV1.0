﻿using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Model.StoreModal;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IStoreUser
    {
        //int AddStoreUserPersonaldetail(CustomStoreUserModel storeUserModel);
        //int AddStoreUserProfiledetail(CustomStoreUserModel customStoreUserModel);


        
        //int EditStoreUser(CustomStoreUserEdit customStoreUserEdit);


        int AddStoreUserPersonalDetails(StoreUserPersonalDetails personalDetails);

        int AddStoreUserProfileDetails(int tenantID,int userID, int BrandID, int storeID, int departmentId, string functionIDs, int designationID, int reporteeID, int CreatedBy);

        int AddStoreUserMappedCategory(StoreClaimCategory storeUserModel);

        int DeleteStoreUser(int tenantID, int UserId, bool IsStoreUser, int ModifiedBy);
        int AddBrandStore(int tenantID, int brandID, int storeID, int UserMasterID);
        int UpdateBrandStore(int tenantID, int brandID, int storeID, int UserMasterID,int userID);

        List<StoreUserListing> GetStoreUserList(int tenantID);

        StoreUserListing GetStoreUserOnUserID(int tenantID, int UserID);
        List<UpdateUserProfiledetailsModel> GetUserProfileDetails(int UserMasterID, string url);
        int UpdateStoreUser(StoreUserDetailsModel userdetails);
        int UpdateUserProfileDetail(UpdateUserProfiledetailsModel UpdateUserProfiledetailsModel);
        int DeleteProfilePicture(int tenantID, int userID);
        CustomChangePassword GetStoreUserCredentails(int userID, int TenantID, int IsStoreUser);


        #region Profile Mapping

        List<StoreUserDepartmentList> BindDepartmentByBrandStore(int BrandID, int storeID);

        List<DesignationMaster> BindStoreReporteeDesignation(int DesignationID, int TenantID);


        List<CustomSearchTicketAgent> BindStoreReportToUser(int DesignationID, bool IsStoreUser, int TenantID); 

        #endregion


        #region Claim Category mapping


        List<StoreClaimCategoryModel> GetClaimCategoryListByBrandID(int TenantID, string BrandIDs);

        List<StoreClaimSubCategoryModel> GetClaimSubCategoryByCategoryID(int TenantID, string CategoryIDs );

        List<StoreClaimIssueTypeModel> GetClaimIssueTypeListBySubCategoryID(int TenantID, string SubCategoryIDs);
        #endregion



    }
}
