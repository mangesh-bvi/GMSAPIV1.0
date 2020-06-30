using GMS_System.Model;
using System.Collections.Generic;
using System.Data;

namespace GMS_System.Interface
{
    public interface IStoreCRMRole
    {
        int InsertUpdateStoreCRMRole(int CRMRoleID, int tenantID, string RoleName, bool RoleisActive, int createdBy, string ModulesEnabled, string ModulesDisabled);


        int DeleteStoreCRMRole(int tenantID, int CRMRoleID);

        List<StoreCRMRoleModel> GetStoreCRMRoleList(int tenantID);
        List<StoreCRMRoleModel> GetStoreCRMRoleDropdown(int tenantID);
        StoreCRMRoleModel GetStoreCRMRoleByUserID(int tenantID, int UserID);
        List<string> StoreBulkUploadCRMRole(int TenantID, int CreatedBy, int RoleFor, DataSet DataSetCSV);
        List<CrmModule> GetStoreCrmModule(int tenantID);
    }
}
