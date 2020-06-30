using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IStorePriority
    {

        List<Priority> GetPriorityList(int tenantID);
        int AddPriority(string PriorityName, int status, int tenantID, int UserID);
        int UpdatePriority(int PriorityID, string PriorityName, int status, int tenantID, int UserID);
        int DeletePriority(int PriorityID, int tenantID, int UserID);
        List<Priority> PriorityList(int tenantID);
        bool UpdatePriorityOrder(int TenantID, int selectedPriorityID, int currentPriorityID);
        string ValidatePriority(string priorityName, int tenantID);
    }
}
