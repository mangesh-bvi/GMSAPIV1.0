using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    /// <summary>
    /// Interface for the Brand
    /// </summary>
    public interface IBrand
    {
        List<Brand> GetBrandList(int TenantID);

        int AddBrand(Brand brand, int TenantId);

        List<Brand> BrandList(int TenantId);

        int DeleteBrand(int BrandID, int TenantId);

        int UpdateBrand(Brand brand);
    }
}
