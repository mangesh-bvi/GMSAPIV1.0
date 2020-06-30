using GMS_System.CustomModel;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
   public interface ITenant
    {
        int InsertCompany(CompanyModel companyModel);
        int BillingDetails_crud(BillingDetails BillingDetails);
        int OtherDetails(OtherDetailsModel OtherDetails);
        int InsertPlanFeature(string PlanName, string FeatureID, int UserMasterID,int TenantId);
        List<GetPlanDetails> GetPlanDetails(int CustomPlanID, int TenantId);
        int AddPlan(TenantPlan tenantPlan);
        List<CompanyTypeModel> GetCompanyType();
        List<CompanyModel> GetRegisteredTenant(int TenantId);

    }
}
