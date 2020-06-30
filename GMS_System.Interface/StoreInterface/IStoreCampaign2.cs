using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public partial interface IStoreCampaign
    {
        List<StoreCampaignModel2> GetStoreCampaign(int tenantID, int userID, string campaignName, string statusId);

        StoresCampaignStatusResponse GetCustomerpopupDetailsList(string mobileNumber, string programCode, string campaignID, int tenantID, int userID, string ClientAPIURL);

        List<StoreCampaignLogo> GetCampaignDetailsLogo(int tenantID, int userID);
    }
}
