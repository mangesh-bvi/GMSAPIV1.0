﻿using GMS_System.Interface;
using GMS_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS_System.WebAPI.Provider
{
    public partial class HSOrderCaller
    {

        public OrderResponseDetails GetOrdersDetails(IHSOrder order, int tenantId, int userId, OrdersDataRequest ordersDataRequest)
        {
            _OrderRepository = order;
            return _OrderRepository.GetOrdersDetails(tenantId, userId, ordersDataRequest);
        }

        public ShoppingBagResponseDetails GetShoppingBagDetails(IHSOrder order, int tenantId, int userId, OrdersDataRequest ordersDataRequest)
        {
            _OrderRepository = order;
            return _OrderRepository.GetShoppingBagDetails(tenantId, userId, ordersDataRequest);
        }

        public List<ShoppingBagDeliveryFilter> GetShoppingBagDeliveryType(IHSOrder order, int tenantId, int userId, int pageID)
        {
            _OrderRepository = order;
            return _OrderRepository.GetShoppingBagDeliveryType(tenantId, userId, pageID);
        }

        public OrderResponseDetails GetShipmentDetails(IHSOrder order, int tenantId, int userId, OrdersDataRequest ordersDataRequest)
        {
            _OrderRepository = order;
            return _OrderRepository.GetShipmentDetails(tenantId, userId, ordersDataRequest);
        }

        public OrderTabSetting GetOrderTabSettingDetails(IHSOrder order, int tenantId, int userId)
        {
            _OrderRepository = order;
            return _OrderRepository.GetOrderTabSettingDetails(tenantId, userId);
        }

        public int SetOrderHasBeenReturn(IHSOrder order, int tenantId, int userId, int orderID)
        {
            _OrderRepository = order;
            return _OrderRepository.SetOrderHasBeenReturn(tenantId, userId, orderID);
        }
    }
}
