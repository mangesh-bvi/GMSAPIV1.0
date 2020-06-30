using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GMS_System.Interface
{
    public interface ICRMRole
    {
        int InsertUpdateCRMRole(int CRMRoleID, int tenantID, string RoleName, bool RoleisActive, int createdBy, string ModulesEnabled, string ModulesDisabled);

      
        int DeleteCRMRole(int tenantID, int CRMRoleID);

        List<CRMRoleModel> GetCRMRoleList(int tenantID);
        List<CRMRoleModel> GetCRMRoleDropdown(int tenantID);
        CRMRoleModel GetCRMRoleByUserID(int tenantID, int UserID);
        List<string> BulkUploadCRMRole(int TenantID, int CreatedBy, int RoleFor, DataSet DataSetCSV);
    }
}
