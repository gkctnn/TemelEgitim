using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameProject.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderItemService _orderItemService;

        public OrderManager(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public void Add(Order order)
        {
            Console.WriteLine("Add Order");
        }

        public void Add(Customer customer, Product product, int quantity, Campaign campaign = null)
        {
            decimal orderTotal = decimal.Zero;

            Order order = new Order()
            {
                Id = 1,
                CustomerId = customer.Id,
                Customer = customer
            };

            OrderItem orderItem = new OrderItem()
            {
                Id = 1,
                OrderId = order.Id,
                ProductId = product.Id,
                Product = product,
                Quantity = quantity
            };

            _orderItemService.Add(orderItem);

            orderTotal = orderItem.Product.Price * quantity;

            if (campaign != null)
            {
                decimal discount = product.Price * quantity * campaign.Discount;

                order.Campaign = campaign;
                order.CampaignId = campaign.Id;
                order.OrderTotal = orderTotal - discount;

                Console.WriteLine("Add Order (Discount: " + discount + ") For Customer Id: " + customer.Id);
            }
            else
            {
                order.OrderTotal = orderTotal;

                Console.WriteLine("Add Order For Customer Id: " + customer.Id);
            }
        }

        public void Delete(Order order)
        {
            Console.WriteLine("Delete Order");
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            Console.WriteLine("Get Order");

            return new Order();
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            Console.WriteLine("Get Orders");

            return new List<Order>();
        }

        public void Update(Order order)
        {
            Console.WriteLine("Update Order");
        }
    }
}
