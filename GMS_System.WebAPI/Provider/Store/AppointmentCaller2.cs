using GMS_System.Interface;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public partial class AppointmentCaller
    {
        public StoreDetails GetStoreDetailsByStoreCode(IAppointment appointment, int tenantID, int userID, string programcode, string storeCode)
        {
            _AppointmentRepository = appointment;
            return _AppointmentRepository.GetStoreDetailsByStoreCode(tenantID, userID, programcode, storeCode);
        }
    }
}
