﻿using GMS_System.Interface;
using GMS_System.Model;
using System.Collections.Generic;
using System.Data;

namespace GMS_System.WebAPI.Provider
{
    public class StoreDashboard
    {

        private IStoreDashboard _dashboard;

        #region _dashboard
        /// <summary>
        ///get store Dashborad Details
        /// </summary>
        public List<StoreDashboardResponseModel> getStoreDashboardTaskList(IStoreDashboard dashboard, StoreDashboardModel modelname)
        {
            _dashboard = dashboard;
            return _dashboard.GetTaskDataForStoreDashboard(modelname);
        }

        #endregion




        #region _dashboard
        /// <summary>
        ///get store Dashborad Details For Claim
        /// </summary>
        public List<StoreDashboardClaimResponseModel> getStoreDashboardClaimList(IStoreDashboard dashboard, StoreDashboardClaimModel modelname)
        {
            _dashboard = dashboard;
            return _dashboard.GetClaimDataForStoreDashboard(modelname);
        }

        public LoggedInAgentModel GetLogginAccountInfo(IStoreDashboard dashboard, int tenantID, int UserId, string ProfilePicPath)
        {
            _dashboard = dashboard;
            return _dashboard.GetLogginAccountInfo(tenantID, UserId, ProfilePicPath);

        }
        #endregion
    }
}
