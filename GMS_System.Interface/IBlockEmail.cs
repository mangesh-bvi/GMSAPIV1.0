using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public interface IBlockEmail
    {
        int InsertBlockEmail(BlockEmailMaster blockEmailMaster);
        int UpdateBlockEmail(BlockEmailMaster blockEmailMaster);
        int DeleteBlockEmail(int blockEmailID, int UserMasterID, int TenantId);
        List<BlockEmailMaster> ListBlockEmail(int TenantId);
    }
}
