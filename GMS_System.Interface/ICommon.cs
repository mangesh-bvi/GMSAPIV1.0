﻿using GMS_System.Model;

namespace GMS_System.Interface
{
    /// <summary>
    /// Interface for the common methods
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="smtpDetails"></param>
        /// <param name="emailToAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        string SendEmail(SMTPDetails smtpDetails, string emailToAddress, string subject, string body);
    }
}
