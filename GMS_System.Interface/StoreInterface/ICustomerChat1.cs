﻿using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public partial interface ICustomerChat
    {     
        List<CustomerChatMaster> OngoingChat(int userMasterID,int tenantID, string Search, int StoreManagerID);

        List<CustomerChatMaster> NewChat(int userMasterID, int tenantID);

        int MarkAsReadOnGoingChat(int chatID); 

        int UpdateCustomerChatIdStatus(int chatID, int tenantID);

        List<AppointmentDetails> ScheduleVisit(AppointmentMaster appointmentMaster);

        List<CustomerChatHistory> CustomerChatHistory(int chatID);

        int GetChatCount(int tenantID, int UserMasterID);

        List<DateofSchedule> GetTimeSlot(int storeID,int userMasterID, int tenantID);

        int SendMessageToCustomerForVisit(AppointmentMaster appointmentMaster, string ClientAPIURL, int CreatedBy);
    }
}
