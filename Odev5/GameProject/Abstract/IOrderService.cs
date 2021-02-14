using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public interface IOrderService : IBaseService<Order>
    {
        void Add(Customer customer, Product product, int quantity, Campaign campaign = null);
    }
}
