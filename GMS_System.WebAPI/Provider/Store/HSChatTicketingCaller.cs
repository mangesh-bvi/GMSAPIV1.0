﻿using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.WebAPI.Provider
{
    public class HSChatTicketingCaller
    {
        #region Variable
        public IHSChatTicketing hSChatTicketing;
        #endregion
        /// <summary>
        /// Get Chat Tickets
        /// </summary>
        /// <param name="statusID"></param>
        /// <param name="tenantID"></param>
        /// <param name="userMasterID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public List<CustomGetChatTickets> GetTicketsOnLoad(IHSChatTicketing _hSChatTicketing, int statusID, int tenantID, int userMasterID,string programCode)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetTicketsOnLoad(statusID, tenantID, userMasterID, programCode);
        }
        /// <summary>
        /// Get Chat Ticket Status Count
        /// </summary>
        /// <param name="tenantID"></param>
        /// <param name="userID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public List<TicketStatusModel> GetStatusCount(IHSChatTicketing _hSChatTicketing,int tenantID,int userID,string programCode)
        {
            hSChatTicketing = _hSChatTicketing;
             
            return hSChatTicketing.TicketStatusCount(tenantID, userID, programCode);
        }
        /// <summary>
        /// Get CategoryList
        /// </summary>
        /// <param name="tenantID"></param>
        /// <param name="userID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public List<Category> GetCategoryList(IHSChatTicketing _hSChatTicketing, int tenantID,int userID,string programCode)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetCategoryList(tenantID, userID, programCode);
        }
        /// <summary>
        /// Get SubCategoryBy CategoryID
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public List<SubCategory> GetChatSubCategoryByCategoryID(IHSChatTicketing _hSChatTicketing, int categoryID)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetSubCategoryByCategoryID(categoryID);
        }
        /// <summary>
        /// Get IssueType List
        /// </summary>
        ///  <param name="tenantID"></param>
        /// <param name="subCategoryID"></param>
        /// <returns></returns>
        public List<IssueType> GetIssueTypeList(IHSChatTicketing _hSChatTicketing, int tenantID, int subCategoryID)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetIssueTypeList(tenantID, subCategoryID);
        }
        /// <summary>
        /// Get Chat Tickets By ID
        /// </summary>
        /// <param name="ticketID"></param>
        /// <param name="tenantID"></param>
        /// <param name="userMasterID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public GetChatTicketsByID GetTicketsByID(IHSChatTicketing _hSChatTicketing, int ticketID, int tenantID, int userMasterID, string programCode)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetChatTicketsByID(ticketID, tenantID, userMasterID, programCode);
        }
        /// <summary>
        /// Add Chat Ticket Notes
        /// </summary>
        /// <param name="ticketID"></param>
        /// <param name="comment"></param>
        /// <param name="userID"></param>
        /// <param name="tenantID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public int AddChatTicketNotes(IHSChatTicketing _hSChatTicketing, int ticketID, string comment, int userID, int tenantID,string programCode)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.AddChatTicketNotes(ticketID, comment, userID, tenantID, programCode);
        }
        /// <summary>
        /// Get Chat Ticket Notes
        /// </summary>
        /// <param name="ticketID"></param>
        public List<ChatTicketNotes> GetChatticketNotes(IHSChatTicketing _hSChatTicketing, int ticketID)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetChatticketNotes(ticketID);
        }
        /// <summary>
        /// Update Chat Ticket Status
        /// </summary>
        /// <param name="ticketID"></param>
        /// <param name="statusID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int SubmitChatTicket(IHSChatTicketing _hSChatTicketing, int ticketID,int statusID,int userID)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.SubmitChatTicket(ticketID,statusID, userID);
        }
        /// <summary>
        /// Get tickets On View Search click
        /// </summary>
        /// <param name="searchparams"></param>
        /// <returns></returns>
        public List<CustomGetChatTickets> GetChatTicketsOnSearch(IHSChatTicketing _hSChatTicketing, ChatTicketSearch searchModel)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetTicketsOnSearch(searchModel);
        }
        /// <summary>
        /// Get Chat Ticket History
        /// </summary>
        /// <param name="ticketID"></param>
        /// <returns></returns>
        public List<CustomTicketHistory> GetChatTickethistory(IHSChatTicketing _hSChatTicketing, int ticketID)
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.GetChatTickethistory(ticketID);
        }
        /// <summary>
        /// Create Chat Ticket
        /// </summary>
        /// <param name="searchparams"></param>
        /// <returns></returns>
        public int CreateChatTicket(IHSChatTicketing _hSChatTicketing, CreateChatTickets createChatTickets )
        {
            hSChatTicketing = _hSChatTicketing;
            return hSChatTicketing.CreateChatTicket(createChatTickets);
        }
    }
}
