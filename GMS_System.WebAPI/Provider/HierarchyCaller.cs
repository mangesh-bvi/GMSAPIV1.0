using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS_System.Interface;
using GMS_System.CustomModel;
using GMS_System.Model;
using System.Data;
using System.Xml;

namespace GMS_System.WebAPI.Provider
{
    public class HierarchyCaller
    {
        #region Variable
        public IHierarchy _HierarchyRepository;
        #endregion
        /// <summary>
        /// Create Hierarchy /update /soft delete
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public int CreateHierarchy(IHierarchy Hierarchy, CustomHierarchymodel customHierarchymodel)
        {
            _HierarchyRepository = Hierarchy;
            return _HierarchyRepository.CreateHierarchy(customHierarchymodel);
        }
        /// <summary>
        /// ListofHierarchy
        /// </summary>
        /// <param name="TenantID"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public List<CustomHierarchymodel> ListofHierarchy(IHierarchy Hierarchy,int TenantID, int HierarchyFor)
        {
            _HierarchyRepository = Hierarchy;
            return _HierarchyRepository.ListHierarchy(TenantID, HierarchyFor);
        }

        public List<string> HierarchyBulkUpload(IHierarchy Hierarchy, int TenantID, int CreatedBy, int HierarchyFor,DataSet DataSetCSV)
        {
            _HierarchyRepository = Hierarchy;
            return _HierarchyRepository.BulkUploadHierarchy(TenantID, CreatedBy, HierarchyFor, DataSetCSV);
        }

    }
}
