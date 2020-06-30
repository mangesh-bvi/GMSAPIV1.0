using GMS_System.CustomModel;
using GMS_System.Interface;
using System.Collections.Generic;

namespace GMS_System.WebAPI.Provider
{
    public class StoreNotificationCaller
    {

        #region Variable declaration

        private IStoreNotification _Notification;

        #endregion

        /// <summary>
        /// Get AlertList
        // / </summary>
        public ListStoreNotificationModels GetNotification(IStoreNotification Notification, int TenantID, int UserID)
        {
            _Notification = Notification;
            return _Notification.GetNotification(TenantID, UserID);
        }

        /// <summary>
        /// Update is Read on Notification Read
        // / </summary>
        public int ReadNotification(IStoreNotification Notification, int TenantID, int UserID, int NotificatonTypeID, int NotificatonType)
        {
            _Notification = Notification;
            return _Notification.ReadNotification(TenantID, UserID, NotificatonTypeID, NotificatonType);

        }
    }
}
