﻿using GMS_System.Interface;
using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.WebAPI.Provider
{
    public class BlockEmailCaller
    {
        #region Variable declaration

        private IBlockEmail _blockEmail;
        #endregion

        #region Methods 
        public int InsertBlockEmail(IBlockEmail blockEmail, BlockEmailMaster blockEmailMaster)
        {
            _blockEmail = blockEmail;

            return _blockEmail.InsertBlockEmail(blockEmailMaster);
        }
        public int UpdateBlockEmail(IBlockEmail blockEmail, BlockEmailMaster blockEmailMaster)
        {
            _blockEmail = blockEmail;

            return _blockEmail.UpdateBlockEmail(blockEmailMaster);
        }
        public int DeleteBlockEmail(IBlockEmail blockEmail, int blockEmailID, int UserMasterID, int TenantId)
        {
            _blockEmail = blockEmail;

            return _blockEmail.DeleteBlockEmail(blockEmailID, UserMasterID, TenantId);
        }
        public List<BlockEmailMaster> GetBlockEmail(IBlockEmail blockEmail,int TenantId)
        {
            _blockEmail = blockEmail;

            return _blockEmail.ListBlockEmail(TenantId);
        }
        #endregion
    }
}
