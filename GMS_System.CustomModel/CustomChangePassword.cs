﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.CustomModel
{
   public class CustomChangePassword
    {
        public int UserID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ChangePasswordType { get; set; }
        public string ProgramCode { get; set; } = "";

    }
}
