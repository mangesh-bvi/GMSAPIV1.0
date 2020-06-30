using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public class DesignationCaller
    {
        #region Variable
        public IDesignation _designationRepository;
        #endregion

        #region Customer wrapper method

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerMaster"></param>
        /// <returns></returns>
        public List<DesignationMaster> GetDesignations(IDesignation designation, int TenantId)
        {
            _designationRepository = designation;
            return _designationRepository.GetDesignations(TenantId);
        }

        public List<DesignationMaster> GetReporteeDesignation(IDesignation designation, int DesignationID, int HierarchyFor, int TenantID)
        {
            _designationRepository = designation;
            return _designationRepository.GetReporteeDesignation(DesignationID, HierarchyFor, TenantID);
        }

        public List<CustomSearchTicketAgent> GetReportToUser(IDesignation designation, int DesignationID, int IsStoreUser, int TenantID)
        {
            _designationRepository = designation;
            return _designationRepository.GetReportToUser(DesignationID, IsStoreUser, TenantID);
        }
        #endregion



    }
}
