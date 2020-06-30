using GMS_System.CustomModel;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public interface IDesignation
    {
        List<DesignationMaster> GetDesignations(int TenantID);
        List<DesignationMaster> GetReporteeDesignation(int DesignationID,int HierarchyFor, int TenantID);
        List<CustomSearchTicketAgent> GetReportToUser(int DesignationID, int IsStoreUser, int TenantID);
    }
}
