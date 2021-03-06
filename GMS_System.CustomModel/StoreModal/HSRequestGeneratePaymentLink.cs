﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.CustomModel
{
    public class HSRequestGeneratePaymentLink
    {
        public string programCode { get; set; }
        public string storeCode  { get; set; }
        public string billDateTime { get; set; }
        public string terminalId { get; set; }
        public string merchantTxnID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public decimal amount { get; set; }
    }

    public class HSResponseGeneratePaymentLink
    {
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public string tokenId { get; set; }
        public string status { get; set; }
    }
    public class HSRequestGenerateToken
    {
        public string ClientID { get; set; } = "9090";
        public string ClientSecret { get; set; } = "090";
        public string GrantType { get; set; } = "pop";
        public string Scope { get; set; } = "lkl";
    }

    public class HSResponseGenerateToken
    {
        public string access_Token { get; set; }
        public int expires_In { get; set; }
        public string token_Type { get; set; }
    }

    public class SentPaymentLink
    {
        public string InvoiceNumber { get; set; }
        public string StoreCode { get; set; }
        public int SentPaymentLinkCount { get; set; }
    }

    public class HSRequestResendPaymentLink
    {
        public string tokenId { get; set; }
        public string programCode { get; set; }    
        public string storeCode { get; set; }
        public string billDateTime { get; set; }
        public string terminalId { get; set; }
        public string merchantTxnID { get; set; }
        public string mobile { get; set; }
        public string reason { get; set; }
    }
}
