﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Model
{
    public class OrderItem
    {

        public int? OrderItemID { get; set; }
        public int? OrderMasterID { get; set; }
        public string ItemName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }
        public int? ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal PricePaid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Size { get; set; }
        public string RequireSize { get; set; }
        public decimal Discount { get; set; }
        public string ArticleNumber { get; set; }
        public string ArticleName { get; set; }
        public bool isCheck { get; set; }
        public string PaymentMode { get; set; }
        

    }
}
