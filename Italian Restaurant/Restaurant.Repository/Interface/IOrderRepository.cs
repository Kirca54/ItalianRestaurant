using Restaurant.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
