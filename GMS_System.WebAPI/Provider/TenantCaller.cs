using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;

namespace GMS_System.WebAPI.Provider
{
    public class TenantCaller
    {
        #region Variable

        /// <summary>
        /// tenant
        /// </summary>
        private ITenant _tenantlist;
        #endregion

        #region method
        public int InsertCompany(ITenant _tenant,  CompanyModel companyModel)
        {
            _tenantlist = _tenant;
            return _tenantlist.InsertCompany(companyModel);
        }
        public int BillingDetails_crud(ITenant _tenant, BillingDetails BillingDetails)
        {
            _tenantlist = _tenant;
            return _tenantlist.BillingDetails_crud(BillingDetails);
        }

        public int OtherDetails(ITenant _tenant, OtherDetailsModel OtherDetails)
        {
            _tenantlist = _tenant;
            return _tenantlist.OtherDetails(OtherDetails);
        }

        public int InsertPlanFeature(ITenant _tenant,string PlanName,string FeatureID,int UserMasterID,int TenantId)
        {
            _tenantlist = _tenant;
            return _tenantlist.InsertPlanFeature(PlanName, FeatureID, UserMasterID, TenantId);
        }
        public  List<GetPlanDetails> GetPlanDetails(ITenant _tenant,  int CustomPlanID, int TenantId)
        {
            _tenantlist = _tenant;
            return _tenantlist.GetPlanDetails(CustomPlanID, TenantId);
        }
        public List<CompanyTypeModel> GetCompanyType(ITenant _tenant)
        {
            _tenantlist = _tenant;
            return _tenantlist.GetCompanyType();
        }
        public int AddPlan(ITenant _tenant,TenantPlan _tenantPlan)
        {
            _tenantlist = _tenant;
            return _tenantlist.AddPlan(_tenantPlan);
        }
        public List<CompanyModel> GetRegisteredTenant(ITenant _tenant, int TenantId)
        {
            _tenantlist = _tenant;
            return _tenant.GetRegisteredTenant(TenantId);
        }
        #endregion
    }
}
