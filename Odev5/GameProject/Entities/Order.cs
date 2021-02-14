using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        private string _orderNumber;
        public string OrderNumber
        {
            get
            {
                return "O_" + _orderNumber;
            }
            set
            {
                _orderNumber = Id.ToString();
            }
        }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public int CampaignId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Campaign Campaign { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
