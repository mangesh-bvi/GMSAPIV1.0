using GMS_System.CustomModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace GMS_System.Interface
{
    public interface IHierarchy
    {
        int CreateHierarchy(CustomHierarchymodel customHierarchymodel);
        List<CustomHierarchymodel> ListHierarchy(int TenantID,int HierarchyFor);

        List<string> BulkUploadHierarchy(int TenantID, int CreatedBy, int HierarchyFor,  DataSet DataSetCSV);
    }
}
