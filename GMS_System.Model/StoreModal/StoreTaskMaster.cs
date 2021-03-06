﻿using System;
using System.Collections.Generic;

namespace GMS_System.Model
{
    /// <summary>
    /// Task Master 
    /// </summary>
    public class StoreTaskMaster
    {
        /// <summary>
        /// Ticketing TaskID
        /// </summary>
        public int TaskID { get; set; }
        /// <summary>
        /// Ticket ID
        /// </summary>
        public int TicketID { get; set; }
        /// <summary>
        /// Task Title
        /// </summary>
        public string TaskTitle { get; set; }
        /// <summary>
        /// Task Description
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// Department Id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Assign To ID
        /// </summary>
        public int AssignToID { get; set; }
        /// <summary>
        /// Assign To Name
        /// </summary>
        public string AssignToName { get; set; }
        /// <summary>
        ///Priority ID
        /// </summary>
        public int PriorityID { get; set; }
        /// <summary>
        /// Function ID
        /// </summary>
        public int FunctionID { get; set; }
        /// <summary>
        /// Task End Time
        /// </summary>
        public DateTime TaskEndTime { get; set; }
        /// <summary>
        /// Task Status Id
        /// </summary>
        public int TaskStatusId { get; set; }
        /// <summary>
        /// Task Status Name
        /// </summary>
        public string TaskStatusName { get; set; }
        /// <summary>
        ///Created By
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Created By Name
        /// </summary>
        public string CreatedByName { get; set; }
        /// <summary>
        /// Modified By
        /// </summary>
        public int ModifiedBy { get; set; }
        /// <summary>
        ///Modified Date
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        ///Task Comments
        /// </summary>
        public string TaskComments { get; set; }
        /// <summary>
        ///Task Comments
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        ///Task Comments
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///Task Comments
        /// </summary>
        public string StoreCode { get; set; }
        /// <summary>
        /// CanEdit
        /// </summary>
        public int CanEdit { get; set; }
        /// <summary>
        /// CanSubmit
        /// </summary>
        public int CanSubmit { get; set; }
        /// <summary>
        /// IsAssignTo
        /// </summary>
        public int IsAssignTo { get; set; }
    }

    public class TaskFilterRaisedBymeModel
    {
        public int? taskid { get; set; }
        public int? Department { get; set; }
        public string tasktitle { get; set; }
        public int? taskstatus { get; set; }
        public int? ticketID { get; set; }
        public int? functionID { get; set; }
        public string CreatedOnFrom { get; set; }
        public string CreatedOnTo { get; set; }
        public int? AssigntoId { get; set; }
        public int? createdID { get; set; }
        public string taskwithTicket { get; set; }
        public string taskwithClaim { get; set; }
        public int? claimID { get; set; }
        public int? Priority { get; set; }
        public int? userid { get; set; }
    }

    public class TaskFilterRaisedBymeResponseModel
    {
        //public int taskid { get; set; }
        //public string Department { get; set; }
        //public string storeName { get; set; }
        //public string StoreAddress { get; set; }
        //public string tasktitle { get; set; }
        //public string taskstatus { get; set; }
        //public int ticketID { get; set; }
        //public int functionID { get; set; }
        //public string CreatedOn { get; set; }
        //public string AssigntoId { get; set; }
        //public string CreatedBy { get; set; }
        //public string taskwithTicket { get; set; }
        //public string taskwithClaim { get; set; }
        //public int claimID { get; set; }
        //public string Priority { get; set; }
        //public int totalCount { get; set; }
        //public string modifedOn { get; set; }
        //public string ModifiedBy { get; set; }




        /// <summary>
        /// Ticketing TaskID
        /// </summary>
        public int StoreTaskID { get; set; }
        /// <summary>
        /// TaskStatus
        /// </summary>
        public string TaskStatus { get; set; }
        /// <summary>
        /// Task Title
        /// </summary>
        public string TaskTitle { get; set; }
        /// <summary>
        /// Task Description
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// StoreCode
        /// </summary>
        public int? StoreCode { get; set; }
        /// <summary>
        ///Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Assign Name
        /// </summary>
        public string Assignto { get; set; }
        /// <summary>
        ///Duedate
        /// </summary>
        public DateTime Duedate { get; set; }
        /// <summary>
        ///Priority
        /// </summary>
        public string PriorityName { get; set; }
        /// <summary>
        /// StoreName
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// StoreAddress
        /// </summary>
        public string StoreAddress { get; set; }
        /// <summary>
        /// CreationOn
        /// </summary>
        public string CreationOn { get; set; }
        /// <summary>
        /// FunctionName
        /// </summary>
        public string FunctionName { get; set; }
        public int totalCount { get; set; }
        public string Createdago { get; set; }
        public string Assignedago { get; set; }
        public string UpdatedBy { get; set; }
        public string Updatedago { get; set; }

        public string TaskCloureDate { get; set; }
        public string ResolutionTimeRemaining { get; set; }
        public string ResolutionOverdueBy { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }

        public int TicketID { get; set; }
    }


    public class TaskFilterAssignBymeModel
    {
        public int? taskid { get; set; }
        public int? Department { get; set; }
        public string tasktitle { get; set; }
        public int? taskstatus { get; set; }
        public int? ticketID { get; set; }
        public int? functionID { get; set; }
        public string CreatedOnFrom { get; set; }
        public string CreatedOnTo { get; set; }
        public int? AssigntoId { get; set; }
        public int? createdID { get; set; }
        public string taskwithTicket { get; set; }
        public string taskwithClaim { get; set; }
        public int? claimID { get; set; }
        public int? Priority { get; set; }
        public int? userid { get; set; }
    }

    public class TaskFilterAssignBymeResponseModel
    {
        //public int taskid { get; set; }
        //public string Department { get; set; }
        //public string storeName { get; set; }
        //public string StoreAddress { get; set; }
        //public string tasktitle { get; set; }
        //public string taskstatus { get; set; }
        //public int ticketID { get; set; }
        //public int functionID { get; set; }
        //public string CreatedOn { get; set; }
        //public string AssigntoId { get; set; }
        //public string CreatedBy { get; set; }
        //public string taskwithTicket { get; set; }
        //public string taskwithClaim { get; set; }
        //public int claimID { get; set; }
        //public string Priority { get; set; }
        //public int totalCount { get; set; }
        //public string modifedOn { get; set; }
        //public string ModifiedBy { get; set; }



        /// <summary>
        /// Ticketing TaskID
        /// </summary>
        public int StoreTaskID { get; set; }
        /// <summary>
        /// TaskStatus
        /// </summary>
        public string TaskStatus { get; set; }
        /// <summary>
        /// Task Title
        /// </summary>
        public string TaskTitle { get; set; }
        /// <summary>
        /// Task Description
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// StoreCode
        /// </summary>
        public int? StoreCode { get; set; }
        /// <summary>
        ///Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Assign Name
        /// </summary>
        public string Assignto { get; set; }
        /// <summary>
        ///Duedate
        /// </summary>
        public DateTime Duedate { get; set; }
        /// <summary>
        ///Priority
        /// </summary>
        public string PriorityName { get; set; }
        /// <summary>
        /// StoreName
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// StoreAddress
        /// </summary>
        public string StoreAddress { get; set; }
        /// <summary>
        /// CreationOn
        /// </summary>
        public string CreationOn { get; set; }
        /// <summary>
        /// FunctionName
        /// </summary>
        public string FunctionName { get; set; }
        public int totalCount { get; set; }
        public string Createdago { get; set; }
        public string Assignedago { get; set; }
        public string UpdatedBy { get; set; }
        public string Updatedago { get; set; }

        public string TaskCloureDate { get; set; }
        public string ResolutionTimeRemaining { get; set; }
        public string ResolutionOverdueBy { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }

        public int TicketID { get; set; }
    }






    public class TaskFilterTicketByModel
    {
        public int? taskid { get; set; }
        public int? Department { get; set; }
        public string tasktitle { get; set; }
        public int? taskstatus { get; set; }
        public int? ticketID { get; set; }
        public int? functionID { get; set; }
        public string CreatedOnFrom { get; set; }
        public string CreatedOnTo { get; set; }
        public int? AssigntoId { get; set; }
        public int? createdID { get; set; }
        public string taskwithTicket { get; set; }
        public string taskwithClaim { get; set; }
        public int? claimID { get; set; }
        public int? Priority { get; set; }
    }

    public class TaskFilterTicketByResponseModel
    {
        //public int taskid { get; set; }
        //public string Department { get; set; }
        //public string storeName { get; set; }
        //public string StoreAddress { get; set; }
        //public string tasktitle { get; set; }
        //public string taskstatus { get; set; }
        //public int ticketID { get; set; }
        //public int functionID { get; set; }
        //public string CreatedOn { get; set; }
        //public string AssigntoId { get; set; }
        //public string CreatedBy { get; set; }
        //public string taskwithTicket { get; set; }
        //public string taskwithClaim { get; set; }
        //public int claimID { get; set; }
        //public string Priority { get; set; }
        //public int totalCount { get; set; }
        //public string modifedOn { get; set; }
        //public string ModifiedBy { get; set; }


        /// <summary>
        /// Ticketing TaskID
        /// </summary>
        public int StoreTaskID { get; set; }
        /// <summary>
        /// TaskStatus
        /// </summary>
        public string TaskStatus { get; set; }
        /// <summary>
        /// Task Title
        /// </summary>
        public string TaskTitle { get; set; }
        /// <summary>
        /// Task Description
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// StoreCode
        /// </summary>
        public int? StoreCode { get; set; }
        /// <summary>
        ///Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Assign Name
        /// </summary>
        public string Assignto { get; set; }
        /// <summary>
        ///Duedate
        /// </summary>
        public DateTime Duedate { get; set; }
        /// <summary>
        ///Priority
        /// </summary>
        public string PriorityName { get; set; }
        /// <summary>
        /// StoreName
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// StoreAddress
        /// </summary>
        public string StoreAddress { get; set; }
        /// <summary>
        /// CreationOn
        /// </summary>
        public string CreationOn { get; set; }
        /// <summary>
        /// FunctionName
        /// </summary>
        public string FunctionName { get; set; }
        public int totalCount { get; set; }
        public string Createdago { get; set; }
        public string Assignedago { get; set; }
        public string UpdatedBy { get; set; }
        public string Updatedago { get; set; }

        public string TaskCloureDate { get; set; }
        public string ResolutionTimeRemaining { get; set; }
        public string ResolutionOverdueBy { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }

        public int TicketID { get; set; }
    }


    public class StoreTaskComment
    {
        public int TaskID { get; set; }
        public string Comment { get; set; }
        public int TaskFor { get; set; }
    }

    public class TaskCommentModel
    {
        public int TaskCommentID { get; set; }
        public int TaskID { get; set; }
        public string Comment { get; set; }
        public int CommentBy { get; set; }
        public string CommentedDate { get; set; }
        public string CommentByName { get; set; }
        public string CommentedDiff { get; set; }
        public int IsCommentOnAssign { get; set; }
        public int NewAgentID { get; set; }
        public string NewAgentName { get; set; }
        public int OldAgentID { get; set; }
        public string OldAgentName { get; set; }
    }

    public class CustomTaskHistory
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string DateandTime { get; set; }
    }

    public class StoreCampaign
    {
        public int CampaignTypeID { get; set; }
        public string CampaignName { get; set; }
        public string CampaignScript { get; set; }
        public string CampaignScriptLess { get; set; }
        public int ContactCount { get; set; }
        public string CampaignEndDate { get; set; }
        public List<StoreCampaignCustomer> StoreCampaignCustomerList { get; set; }
    }

    public class StoreCampaignCustomer
    {
        public int CampaignCustomerID { get; set; }
        public int CustomerID { get; set; }
        public string CampaignTypeDate { get; set; }
        public int CampaignTypeID { get; set; }
        public int CampaignStatus { get; set; }
        public int Response { get; set; }
        public string CallReScheduledTo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmailId { get; set; }
        public string DOB { get; set; }
        public int NoOfTimesNotContacted { get; set; }
        public List<CampaignResponse> CampaignResponseList { get; set; }
    }

    public class CampaignStatusResponse
    {
        public List<CampaignStatus> CampaignStatusList { get; set; }
        public List<CampaignResponse> CampaignResponseList { get; set; }
    }

    public class CampaignStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int StatusNameID { get; set; }
    }

    public class CampaignResponse
    {
        public int ResponseID { get; set; }
        public string Response { get; set; }
        public int StatusNameID { get; set; }
    }

    public class StoreCampaignCustomerRequest
    {
        public int CampaignCustomerID { get; set; }
        public int StatusNameID { get; set; }
        public int ResponseID { get; set; }
        public string CallReScheduledTo { get; set; }
        public DateTime? CallReScheduledToDate { get; set; }
    }

    public class TaskTicketDetails
    {
        /// <summary>
        /// Ticket Id
        /// </summary>
        public int TicketID { get; set; }
        /// <summary>
        /// Ticket Title
        /// </summary>
        public string TicketTitle { get; set; }
        /// <summary>
        /// Ticket Description
        /// </summary>
        public string Ticketdescription { get; set; }
        /// <summary>
        /// Ticket Notes
        /// </summary>
        public string Ticketnotes { get; set; }
        /// <summary>
        /// Brand Id
        /// </summary>
        public int BrandID { get; set; }
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Subcategory Id
        /// </summary>
        public int SubCategoryID { get; set; }
        /// <summary>
        /// Sub Category Name
        /// </summary>
        public string SubCategoryName { get; set; }
        /// <summary>
        /// Issue Type Id
        /// </summary>
        public int IssueTypeID { get; set; }
        /// <summary>
        /// Issue Type Name
        /// </summary>
        public string IssueTypeName { get; set; }
        /// <summary>
        /// Priority Id
        /// </summary>
        public int PriortyID { get; set; }
        /// <summary>
        /// Priorty Name
        /// </summary>
        public string PriortyName { get; set; }
        /// <summary>
        /// Customer Id
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// CustomerPhoneNumber
        /// </summary>
        public string CustomerPhoneNumber { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// AltNumber
        /// </summary>
        public string AltNumber { get; set; }
        /// <summary>
        /// CustomerEmailId
        /// </summary>
        public string CustomerEmailId { get; set; }
        /// <summary>
        /// UpdateDate
        /// </summary>
        public string UpdateDate { get; set; }       
        /// <summary>
        /// TargetClouredate
        /// </summary>
        public string TicketAssignDate { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// ChannelOfPurchaseID
        /// </summary>
        public int ChannelOfPurchaseID { get; set; }
        /// <summary>
        /// AssignedID
        /// </summary>
        public int AssignedID { get; set; }
        /// <summary>
        /// TicketActionID
        /// </summary>
        public int TicketActionTypeID { get; set; }
        /// <summary>
        /// OrderMasterID
        /// </summary>
        public int OrderMasterID { get; set; }
        /// <summary>
        /// Created By
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Updated By
        /// </summary>
        public int UpdatedBy { get; set; }
        /// <summary>
        /// Updated Date
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// StoreID
        /// </summary>
        public string StoreID { get; set; }
        /// <summary>
        /// StoreNames
        /// </summary>
        public string StoreNames { get; set; }
        /// <summary>
        /// ProductID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// ProductNames
        /// </summary>
        public string ProductNames { get; set; }
        /// <summary>
        /// User Email ID
        /// </summary>
        public string UserEmailID { get; set; }
        /// <summary>
        /// Order Item ID
        /// </summary>
        public string OrderItemID { get; set; }
    }

    public class StoreTaskWithTicket
    {
        public StoreTaskMaster StoreTaskMasterDetails { get; set; }
        public TaskTicketDetails TaskTicketDetails { get; set; }
    }

    public class StoreTaskProcressBar
    {
        public int Progress { get; set; }
        public string ProgressIn { get; set; }
        public string RemainingTime { get; set; }
        public string ClosureTaskDate { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }

    public class AssignTaskModel
    {
        public string TaskID { get; set; }
        public int AgentID { get; set; }
        public string CommentOnAssign { get; set; }
        public int IsCommentOnAssign { get; set; }
        public int OldAgentID { get; set; }
    }

}
