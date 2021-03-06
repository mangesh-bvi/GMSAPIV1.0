﻿using GMS_System.Interface;
using GMS_System.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public class NotificationCaller 
    {
        #region Variable declaration

        private INotification _Notification;

        #endregion

        /// <summary>
        /// Get AlertList
        // / </summary>
        public NotificationModel GetNotification(INotification Notification, int TenantID, int UserID )
        {
            _Notification = Notification;
            return _Notification.GetNotification( TenantID,  UserID); 

        }

        /// <summary>
        /// Update is Read on Notification Read
        // / </summary>
        public int ReadNotification(INotification Notification, int TenantID, int UserID, int  TicketID, int IsFollowUp)
        {
            _Notification = Notification;
            return _Notification.ReadNotification(TenantID, UserID, TicketID, IsFollowUp);

        }
    }
}
