using GMS_System.CustomModel;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace GMS_System.Interface
{
    public interface IPayment
    {
        int InsertChequeDetails(OfflinePaymentModel offlinePaymentModel);
    }
}
