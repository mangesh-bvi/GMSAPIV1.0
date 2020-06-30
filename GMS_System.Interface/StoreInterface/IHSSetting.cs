using GMS_System.CustomModel.StoreModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface.StoreInterface
{
    public interface IHSSetting
    {

        List<HSSettingModel> GetStoreAgentList(int tenantID, int BrandID, int StoreID);

        int InsertUpdateAgentDetails(HSSettingModel hSSettingModel, int tenantID);

        List<HSSettingModel> GetStoreAgentDetailsById(int tenantID, int AgentID);

    }
}
