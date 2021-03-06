﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Model
{
    public class StoreCampaignModel3
    {
        //public List<StoreCampaignSettingModel> CampaignSetting { get; set; }
        public  StoreCampaignSettingTimer CampaignSettingTimer { get; set; }
    } 


    public class StoreCampaignSettingModel
    {
        public int ID { get; set; }

        public string CampaignName { get; set; }

        public string CampaignCode { get; set; }

        public string Programcode { get; set; }


        public bool SmsFlag { get; set; }

        public bool EmailFlag { get; set; }

        public bool MessengerFlag { get; set; }

        public bool BotFlag { get; set; }


        public int CreatedBy { get; set; }

         public string CreatedOnName { get; set; }

        public string CreatedOn { get; set; }


        public int ModifiedBy { get; set; }

        public string ModifiedByName { get; set; }
        public string ModifiedOn { get; set; }

    }

    public class StoreCampaignSettingTimer
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Programcode
        /// </summary>
        public string Programcode { get; set; }
        /// <summary>
        /// MaxClickAllowed
        /// </summary>
        public int MaxClickAllowed { get; set; }
        /// <summary>
        /// EnableClickAfterValue
        /// </summary>
        public int EnableClickAfterValue { get; set; }
        /// <summary>
        /// EnableClickAfterDuration
        /// </summary>
        public string EnableClickAfterDuration { get; set; }
        /// <summary>
        /// SmsFlag
        /// </summary>
        public bool SmsFlag { get; set; }
        /// <summary>
        /// EmailFlag
        /// </summary>
        public bool EmailFlag { get; set; }
        /// <summary>
        /// MessengerFlag
        /// </summary>
        public bool MessengerFlag { get; set; }
        /// <summary>
        /// BotFlag
        /// </summary>
        public bool BotFlag { get; set; }
        /// <summary>
        /// ProviderName
        /// </summary>
        public string ProviderName { get; set; } = "";

    }

    public class StoreBroadcastConfiguration
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Programcode
        /// </summary>
        public string Programcode { get; set; }
        /// <summary>
        /// MaxClickAllowed
        /// </summary>
        public int MaxClickAllowed { get; set; }
        /// <summary>
        /// EnableClickAfterValue
        /// </summary>
        public int EnableClickAfterValue { get; set; }
        /// <summary>
        /// EnableClickAfterDuration
        /// </summary>
        public string EnableClickAfterDuration { get; set; }
        /// <summary>
        /// SmsFlag
        /// </summary>
        public bool SmsFlag { get; set; }
        /// <summary>
        /// EmailFlag
        /// </summary>
        public bool EmailFlag { get; set; }
        /// <summary>
        /// WhatsappFlag
        /// </summary>
        public bool WhatsappFlag { get; set; }
        /// <summary>
        /// ProviderName
        /// </summary>
        public string ProviderName { get; set; } = "";
    }

    public class StoreAppointmentConfiguration
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Programcode
        /// </summary>
        public string Programcode { get; set; }
        /// <summary>
        /// GenerateOTP
        /// </summary>
        public bool GenerateOTP { get; set; }
        /// <summary>
        /// CardQRcode
        /// </summary>
        public bool CardQRcode { get; set; }
        /// <summary>
        /// CardBarcode
        /// </summary>
        public bool CardBarcode { get; set; }
        /// <summary>
        /// OnlyCard
        /// </summary>
        public bool OnlyCard { get; set; }
    }

    public class Languages
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
    }

    public class SelectedLanguages
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// LanguageID
        /// </summary>
        public int LanguageID { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public string CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// CreaterName
        /// </summary>
        public string CreaterName { get; set; }
    }
}
