using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Model.StoreModal
{
    public class ClientCustomSendTextModel
    {
        /// <summary>
        /// Customer Mobile Number
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// textToReply
        /// </summary>
        public string textToReply { get; set; }

        /// <summary>
        /// programCode
        /// </summary>
        public string programCode { get; set; }

       
    }
}
