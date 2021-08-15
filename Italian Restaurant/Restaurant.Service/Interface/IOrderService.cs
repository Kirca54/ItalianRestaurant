using Restaurant.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Service.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();

        Order getOrderDetails(BaseEntity model);
    }
}
