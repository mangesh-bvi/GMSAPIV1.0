﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Model
{
    public class LoggedInAgentModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentEmailId { get; set; }
        public ChatStatus Chatstatus { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string ProfilePicture { get; set; }

        public int LoggedInDurationInHours { get; set; }
        public int LoggedInDurationInMinutes { get; set; }

        public int ShiftDurationInHour { get; set; }
        public int ShiftDurationInMinutes { get; set; } 

        public string LoggedInDuration { get; set; }
        public string SLAScore { get; set; }
        public string AvgResponseTime { get; set; }
        public string CSATScore { get; set; }

        public string WorkTimeInPercentage { get; set; }
        public string TotalWorkingTime { get; set; }
        public string workingMinute { get; set; }


        public int StoreID { get; set; }
        public string ProgramCode { get; set; }
        public string StoreCode { get; set; }

    }

    public class ChatStatus
    {
        public bool isOnline { get; set; }
        public bool isAway { get; set; }
        public bool isOffline { get; set; }
    }
}
