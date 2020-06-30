using GMS_System.Model;
using GMS_System.Model.StoreModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface.StoreInterface
{
    public interface IMaster
    {
        List<StoreUser> GetStoreUserList(int TenantId, int UserID);

        List<StoreFunctionModel> GetStoreFunctionList(int TenantId, int UserID);
    }
}
