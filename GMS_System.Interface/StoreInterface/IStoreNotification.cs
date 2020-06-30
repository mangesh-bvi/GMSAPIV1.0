using GMS_System.CustomModel;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IStoreNotification
    {
        ListStoreNotificationModels GetNotification(int TenantID, int UserID);

        int ReadNotification(int TenantID, int UserID, int NotificatonTypeID, int NotificatonType);
    } 
}
