﻿using GMS_System.Interface;
using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.WebAPI.Provider
{
    public partial class StoreCampaignCaller
    {
        public CampaignCustomerDetails GetCampaignCustomer(IStoreCampaign Campaign, int tenantID, int userID, CampaingCustomerFilterRequest campaingCustomerFilterRequest)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetCampaignCustomer(tenantID, userID, campaingCustomerFilterRequest);
        }

        public int UpdateCampaignStatusResponse(IStoreCampaign Campaign, CampaignResponseInput objRequest, int TenantID, int UserID)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.UpdateCampaignStatusResponse(objRequest, TenantID, UserID);
        }

        public int CampaignShareChatbot(IStoreCampaign Campaign, ShareChatbotModel objRequest, string ClientAPIURL, int TenantID, int UserID, string ProgramCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.CampaignShareChatbot(objRequest, ClientAPIURL, TenantID, UserID, ProgramCode);
        }

        public string CampaignShareMassanger(IStoreCampaign Campaign, ShareChatbotModel objRequest, int TenantID, int UserID)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.CampaignShareMassanger(objRequest, TenantID, UserID);
        }

        public int CampaignShareSMS(IStoreCampaign Campaign, ShareChatbotModel objRequest, string ClientAPIURL, string SMSsenderId, int TenantID, int UserID)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.CampaignShareSMS(objRequest, ClientAPIURL, SMSsenderId, TenantID, UserID);
        }

        public BroadcastDetails GetBroadcastConfigurationResponses(IStoreCampaign Campaign, int tenantID, int userID, string programcode, string storeCode, string campaignCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetBroadcastConfigurationResponses(tenantID, userID, programcode, storeCode, campaignCode);
        }

        public int InsertBroadCastDetails(IStoreCampaign Campaign, int tenantID, int userID, string programcode, string storeCode, string campaignCode, string channelType, string ClientAPIURL)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.InsertBroadCastDetails(tenantID, userID, programcode, storeCode, campaignCode, channelType, ClientAPIURL);
        }

    }
}
