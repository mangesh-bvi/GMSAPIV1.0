﻿using GMS_System.Model;
using GMS_System.Model.StoreModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public partial interface ICustomerChat
    {

        List<CustomerChatMessages> GetChatMessageDetails(int tenantId, int ChatID, int ForRecentChat);

        int SaveChatMessages(CustomerChatModel ChatMessageDetails);

        List<CustomItemSearchResponseModel>  ChatItemDetailsSearch(int TenantID, string Programcode, string ClientAPIURL,string SearchText);

        int SaveCustomerChatMessageReply(CustomerChatReplyModel ChatReply); 


        List<CustomerChatSuggestionModel>  GetChatSuggestions(string SearchText);

        int SendRecommendationsToCustomer(int TenantID, string Programcode, int CustomerID, string MobileNo, string ClientAPIURL, int CreatedBy);

        int SendMessageToCustomer(int ChatID, string MobileNo,string ProgramCode,string Message, string WhatsAppMessage, string ImageURL, string ClientAPIURL,int CreatedBy, int InsertChat);


    }
}
