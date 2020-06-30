using GMS_System.CustomModel;
using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface IGraph
    {
        List<User> GetUserList(int TenantID, int UserID);
        GraphModal GetGraphCountData(int TenantID, int UserID, GraphCountDataRequest GraphCountData);
        GraphData GetGraphData(int TenantID, int UserID, GraphCountDataRequest GraphCountData);
    }
}
