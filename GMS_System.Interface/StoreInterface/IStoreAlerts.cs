using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GMS_System.Interface
{
   public interface IStoreAlerts
    {
        int InsertStoreAlert(AlertInsertModel alertModel);
       
        int UpdateStoreAlert(int tenantId, int ModifiedBy, AlertUpdateModel alertModel);

        int DeleteStoreAlert(int tenantID, int AlertID);

        List<AlertModel> GetStoreAlertList(int tenantId, int alertID);

        List<AlertList> BindStoreAlerts(int tenantID);

        int BulkStoreUploadAlert(int TenantID, int CreatedBy, DataSet DataSetCSV);

        string ValidateStoreAlert(int AlertID, int TenantID);
    }
}
