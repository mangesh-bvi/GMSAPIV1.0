using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.CustomModel
{
    public class CustomStoreSearch
    {
        public string programCode { get; set; }
        public string storeAddressPin { get; set; }
      
        public string securityToken { get; set; }
        public int userID { get; set; }
        public int appID { get; set; }
    }
}
