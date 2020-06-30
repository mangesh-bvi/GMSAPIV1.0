using GMS_System.CustomModel;
using System.Collections.Generic;
using System.Data;

namespace GMS_System.Interface
{
    public interface IItem
    {
        List<string> ItemBulkUpload(int TenantID, int CreatedBy, int CategoryFor, DataSet DataSetCSV);

        List<ItemModel> GetItemList(int TenantId);
    }
}
