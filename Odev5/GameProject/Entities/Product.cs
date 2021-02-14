using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Nane { get; set; }
        public decimal Price { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
