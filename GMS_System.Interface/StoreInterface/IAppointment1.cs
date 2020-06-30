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
        
        List<AppointmentModel> GetAppointmentList(int TenantID, int UserId, string AppDate); 

        List<AppointmentCount> GetAppointmentCount(int TenantID, int UserId);

        int UpdateAppointmentStatus(AppointmentCustomer appointmentCustomer, int TenantId);


        #region TimeSlotMaster CRUD

        int InsertUpdateTimeSlotMaster(StoreTimeSlotInsertUpdate Slot);


        int DeleteTimeSlotMaster(int SlotID, int TenantID);

        List<StoreTimeSlotMasterModel> StoreTimeSlotMasterList(int TenantID, string ProgramCode, int StoreID);

        #endregion
    }
}
