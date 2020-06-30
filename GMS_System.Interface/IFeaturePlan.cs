using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IFeaturePlan
    {
        FeaturePlanModel GetFeaturePlanList(int TenantID);
        string AddFeature(FeaturesModel objFeatures);
        int DeleteFeature(int UserID,int FeatureID);

        int AddPlan(PlanModel plan);

        List<PlanModel> GetPlanOnEdit(int TenantID);
    }

}
