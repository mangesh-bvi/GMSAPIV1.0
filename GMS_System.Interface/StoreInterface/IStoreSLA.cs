using GMS_System.Model;
using GMS_System.Model.StoreModal;
using System.Collections.Generic;
using System.Data;

namespace GMS_System.Interface.StoreInterface
{
    public interface IStoreSLA
    {
         List<FunctionList> BindFunctionList(int tenantID, string SearchText);

        int InsertStoreSLA(StoreSLAModel SLA);

        int UpdateStoreSLA(StoreSLAModel SLA);

        //bool UpdateStoreSLADetails(SLADetail sLADetail, int TenantID, int UserID);

        int DeleteStoreSLA(int tenantID, int SLAID);

        List<StoreSLAResponseModel> StoreSLAList(int tenantID);

        StoreSLAResponseModel GetStoreSLADetail(int TenantID, int SLAID);

        List<string> StoreBulkUploadSLA(int TenantID, int CreatedBy, DataSet DataSetCSV);
    }
}
