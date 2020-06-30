using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Interface
{
    public interface IJunkWords
    {
        int InsertJunkWords(JunkWordsMaster junkWordsMaster);
        int UpdateJunkWords(JunkWordsMaster junkWordsMaster);
        int DeleteJunkWords(int junkKeywordID, int userMasterID, int tenantId);
        List<JunkWordsMaster> ListJunkWords(int tenantId);

    }
}
