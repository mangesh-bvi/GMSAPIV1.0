﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.CustomModel
{
    public class CustomClaimMaster
    {
        public int TicketClaimID { get; set; }
        public string TaskStatus { get; set; }
        public int ClaimIssueID { get; set; }
        public string ClaimIssueType { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string RaisedBy { get; set; }
        public string CreationOn { get; set; }
        public DateTime Creation_on { get; set; }
        public string Dateformat { get; set; }
        public string AssignName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public List<ClaimCategory> claimCategory { get; set; }
        public List<CampaignScript> campaignScript { get; set; }
        public List<ClaimAttechment> claimAttechment { get; set; }
    }
    public class ClaimCategory
    {
        public string BrandName { get; set; }
        public string ClaimCategoryName { get; set; }
        public string ClaimSubCategory { get; set; }
        public string ClaimIssueType { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public int TenantID { get; set; }
    }
    public class CampaignScript
    {
        public int TenantID { get; set; }
        public string CampaignName { get; set; }
        public string ScriptDetails { get; set; }
        public int CreatedBy { get; set; }
    }
    public class ClaimAttechment
    {
        public int TenantID { get; set; }
        public int CreatedBy { get; set; }
        public string MaximumSize { get; set; }
        public string FileFormat { get; set; } 
    }
}
