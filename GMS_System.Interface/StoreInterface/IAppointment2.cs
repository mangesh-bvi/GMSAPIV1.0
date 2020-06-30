using GMS_System.CustomModel;
using GMS_System.Model;
using GMS_System.Model.StoreModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public partial interface IAppointment
    {

        StoreDetails GetStoreDetailsByStoreCode(int tenantID, int userID, string programcode, string storeCode);
    }
}
