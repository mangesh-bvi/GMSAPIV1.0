﻿using GMS_System.CustomModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GMS_System.Interface
{
    public interface IModulesSetting
    {
        AttachmentSettingResponseModel GetStoreAttachmentSettings(int TenantId, int CreatedBy);

        int ModifyStoreAttachmentSettings(int TenantId, int CreatedBy, AttachmentSettingsRequest AttachmentSettings);

        List<CampaignScriptDetails> GetCampaignScript(int TenantId, int CampaignID);

        List<CampaignScriptName> GetCampaignName(int TenantId);

        string ValidateCampaignNameExit(int CampaignNameID, int TenantID);

        int InsertCampaignScript(int TenantId, int CreatedBy, CampaignScriptRequest Campaignscript);

        int UpdateCampaignScript(int TenantId, int CreatedBy, CampaignScriptRequest Campaignscript);

        int DeleteCampaignScript(int TenantId, int CreatedBy, int CampaignID);

        List<string> CampaignBulkUpload(int TenantID, int CreatedBy, int CategoryFor, DataSet DataSetCSV);
    }
}
