using System;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using System.Collections.Generic;
using System.Data;


namespace GMS_System.WebAPI.Provider
{
    public class PaymentCaller
    {
        #region Variable
        private IPayment _PaymentList;
        #endregion


        #region Method

        public int InsertChequeDetails(IPayment _payment, OfflinePaymentModel offlinePaymentModel)
        {
            _PaymentList = _payment;
            return _PaymentList.InsertChequeDetails(offlinePaymentModel);
        }

        #endregion
    }
}
