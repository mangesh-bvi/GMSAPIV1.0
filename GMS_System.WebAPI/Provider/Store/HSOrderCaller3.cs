﻿using GMS_System.CustomModel;
using GMS_System.Interface;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public partial class HSOrderCaller
    {
        /// <summary>
        /// CreateShipmentAWB
        /// </summary>
        /// <param name="orderID"></param>
        ///  <param name="itemIDs"></param>
        ///  <param name="tenantID"></param>
        ///  <param name="userID"></param>
        /// <returns></returns>
        public ReturnShipmentDetails InsertShipmentAWB(IHSOrder order, int orderID, string itemIDs,int tenantID,int userID,string clientAPIURL)
        {
            _OrderRepository = order;
            return _OrderRepository.CreateShipmentAWB(orderID, itemIDs, tenantID, userID, clientAPIURL);
        }

        /// <summary>
        /// GetItemDetailByOrderID
        /// </summary>
        /// <param name="orderID"></param>
        ///  <param name="tenantID"></param>
        ///  <param name="userID"></param>
        /// <returns></returns>
        public OrdersItemDetails GetItemDetailByOrderID(IHSOrder order, int orderID,int tenantID, int userID)
        {
            _OrderRepository = order;
            return _OrderRepository.GetItemDetailByOrderID(orderID, tenantID, userID);
        }

        /// <summary>
        /// GetAWBInvoicenoDetails
        /// </summary>
        /// <param name="orderID"></param>
        ///  <param name="tenantID"></param>
        ///  <param name="userID"></param>
        /// <returns></returns>
        public List<ReturnShipmentDetails>GetAWBInvoicenoDetails(IHSOrder order, int orderID, int tenantID, int userID)
        {
            _OrderRepository = order;
            return _OrderRepository.GetAWBInvoicenoDetails(orderID, tenantID, userID);
        }
        /// <summary>
        ///Generate Link
        /// </summary>
        /// <param name="sentPaymentLink"></param>
        /// <param name="clientAPIUrlForGenerateToken"></param>
        /// <param name="clientAPIUrlForGeneratePaymentLink"></param>
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <param name="programCode"></param>
        /// <returns></returns>
        public int GeneratePaymentLink(IHSOrder order, SentPaymentLink sentPaymentLink, string clientAPIUrlForGenerateToken, string clientAPIUrlForGeneratePaymentLink, int tenantID, int userID, string programCode)
        {
            _OrderRepository = order;
            return _OrderRepository.GenerateLink(sentPaymentLink, clientAPIUrlForGenerateToken, clientAPIUrlForGeneratePaymentLink, tenantID, userID, programCode);
        }

        /// <summary>
        /// CheckPinCodeForCourierAvailibilty
        /// </summary>
        ///  <param name="HSChkCourierAvailibilty"></param>
        ///  <param name="tenantID"></param>
        ///  <param name="userID"></param>
        ///  <param name="clientAPIUrl"></param>
        /// <returns></returns>
        public ResponseCourierAvailibilty CheckPinCodeForCourierAvailibilty(IHSOrder order, HSChkCourierAvailibilty hSChkCourierAvailibilty, int tenantID, int userID,string clientAPIUrl)
        {
            _OrderRepository = order;
            return _OrderRepository.CheckPinCodeForCourierAvailibilty(hSChkCourierAvailibilty, tenantID, userID, clientAPIUrl);
        }

        /// <summary>
        ///GetStorePinCodeByUserID
        /// </summary>     
        /// <param name="TenantID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetStorePinCodeByUserID(IHSOrder order, int tenantID, int userID)
        {
            _OrderRepository = order;
            return _OrderRepository.GetStorePinCodeByUserID(tenantID, userID);
        }
    }
}
