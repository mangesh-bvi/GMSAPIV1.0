﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.CustomModel
{
  public class CustomTaskNotificationModel
    {
        public int NotificationID { get; set; }
        public int AlertID { get; set; }
        public int NotificatonTypeID { get; set; }
        public int NotificatonType { get; set; }
        public string NotificatonTypeName { get; set; }
    }
    public class StoreNotificationModel
    {
        public int NotificationCount { get; set; }
        public int AlertID { get; set; }
        public string NotificationName { get; set; }
        public List<CustomTaskNotificationModel> CustomTaskNotificationModels { get; set; }
    }
    public class ListStoreNotificationModels
    {
        public List<StoreNotificationModel> StoreNotificationModel  { get; set; }
        public int NotiCount { get; set; }
    }
}
