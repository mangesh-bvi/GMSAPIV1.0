using GMS_System.Model;

namespace GMS_System.Interface
{
    public interface INotification
    {
        NotificationModel GetNotification(int TenantID, int UserID);

        int ReadNotification(int TenantID, int UserID, int TicketID, int IsFollowUp); 

    }
}
