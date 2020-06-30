using GMS_System.CustomModel;
using GMS_System.CustomModel.StoreModal;
using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface.StoreInterface
{
    public interface IStoreReport
    {
        int GetStoreReportSearch(StoreReportModel searchModel, List<StoreUserListing> StoreUserList);

        string DownloadStoreReportSearch(int ReportID, int UserID, int TenantID, List<StoreUserListing> StoreUserList);

        bool CheckIfReportNameExists(int ReportID, string ReportName, int TenantID);

        int ScheduleStoreReport(ScheduleMaster scheduleMaster, int TenantID, int UserID);

        List<ReportModel> StoreReportList(int tenantID);

        int DeleteStoreReport(int tenantID, int ReportID); 


        int SaveStoreReport(StoreReportRequest ReportMaster);


        List<CampaignScriptName> GetCampaignNames();

    }
}
