﻿using GMS_System.Interface;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public partial class StoreCampaignCaller
    {
       

        public StoreCampaignModel3 GetStoreCampignSetting(IStoreCampaign Campaign, int TenantId, int UserId, string ProgramCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetStoreCampignSetting( TenantId,  UserId,  ProgramCode);

        }

        public int UpdateStoreCampaignSetting(IStoreCampaign Campaign, StoreCampaignSettingModel CampaignModel)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.UpdateStoreCampaignSetting(CampaignModel);

        }

        public int UpdateCampaignMaxClickTimer(IStoreCampaign Campaign, StoreCampaignSettingTimer storeCampaignSettingTimer, int ModifiedBy)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.UpdateCampaignMaxClickTimer(storeCampaignSettingTimer, ModifiedBy);

        }

        public StoreBroadcastConfiguration GetBroadcastConfiguration(IStoreCampaign Campaign, int tenantId, int userId, string programCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetBroadcastConfiguration(tenantId, userId, programCode);
        }

        public StoreAppointmentConfiguration GetAppointmentConfiguration(IStoreCampaign Campaign, int tenantId, int userId, string programCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetAppointmentConfiguration(tenantId, userId, programCode);
        }

        public int UpdateBroadcastConfiguration(IStoreCampaign Campaign, StoreBroadcastConfiguration storeBroadcastConfiguration, int modifiedBy)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.UpdateBroadcastConfiguration(storeBroadcastConfiguration, modifiedBy);
        }

        public int UpdateAppointmentConfiguration(IStoreCampaign Campaign, StoreAppointmentConfiguration storeAppointmentConfiguration, int modifiedBy)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.UpdateAppointmentConfiguration(storeAppointmentConfiguration, modifiedBy);
        }

        public List<Languages> GetLanguageDetails(IStoreCampaign Campaign, int tenantId, int userId, string programCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetLanguageDetails(tenantId, userId, programCode);
        }

        public int InsertLanguageDetails(IStoreCampaign Campaign, int tenantId, int userId, string programCode, int languageID)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.InsertLanguageDetails(tenantId, userId, programCode, languageID);
        }

        public List<SelectedLanguages> GetSelectedLanguageDetails(IStoreCampaign Campaign, int tenantId, int userId, string programCode)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.GetSelectedLanguageDetails(tenantId, userId, programCode);
        }

        public int DeleteSelectedLanguage(IStoreCampaign Campaign, int tenantId, int userId, string programCode, int selectedLanguageID, bool isActive)
        {
            _CampaignRepository = Campaign;
            return _CampaignRepository.DeleteSelectedLanguage(tenantId, userId, programCode, selectedLanguageID, isActive);
        }
    }
}
