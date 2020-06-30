using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IStoreDashboard
    {   
        List<StoreDashboardResponseModel> GetTaskDataForStoreDashboard(StoreDashboardModel model);



        List<StoreDashboardClaimResponseModel> GetClaimDataForStoreDashboard(StoreDashboardClaimModel model);


        LoggedInAgentModel GetLogginAccountInfo(int tenantID, int UserId, string ProfilePicPath);

    }
}
