using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameProject.Abstract
{
    public class OrderItemManager : IOrderItemService
    {
        public void Add(OrderItem orderItem)
        {
            Console.WriteLine("Add OrderItem");
        }

        public void Delete(OrderItem orderItem)
        {
            Console.WriteLine("Delete OrderItem");
        }

        public OrderItem Get(Expression<Func<OrderItem, bool>> filter)
        {
            Console.WriteLine("Get OrderItem");

            return new OrderItem();
        }

        public List<OrderItem> GetAll(Expression<Func<OrderItem, bool>> filter = null)
        {
            Console.WriteLine("Get OrderItems");

            return new List<OrderItem>();
        }

        public void Update(OrderItem orderItem)
        {
            Console.WriteLine("Update OrderItem");
        }
    }
}
