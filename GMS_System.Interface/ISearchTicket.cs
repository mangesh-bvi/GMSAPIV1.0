﻿using GMS_System.CustomModel;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    /// <summary>
    /// Interface for the Ticket Search
    /// </summary>
    public interface ISearchTicket
    {
        List<SearchResponse> SearchTickets(SearchRequest searchparams);

        List<TicketStatusModel> TicketStatusCount(SearchRequest searchparams);

        List<SearchResponse> GetTicketsOnLoad(int HeaderStatus_ID,int Tenant_ID,int AssignTo_ID);

        List<SearchResponse> GetTicketsOnSearch(SearchModel searchModel);

        TicketSaveSearch GetTicketsOnSavedSearch(int TenantID,int UserID,int SearchParamID);
    }
}
