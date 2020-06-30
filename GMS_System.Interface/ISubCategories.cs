using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    /// <summary>
    /// Interface for the Category
    /// </summary>
    public interface ISubCategories
    {
        List<SubCategory> GetSubCategoryByCategoryID(int CategoryID,int TypeId);
        List<SubCategory> GetSubCategoryByMultiCategoryID(string CategoryIDs);
        int AddSubCategory(int CategoryID,string category, int TenantID, int UserID);
        List<SubCategory> GetSubCategoryByCategoryOnSearch(int tenantID,int CategoryID, string searchText);
    }
}
