using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Campaign: IEntity
    {
        public int Id { get; set; }
        public string Nane { get; set; }
        private decimal _discount;
        public decimal Discount
        {
            get
            {
                return _discount / 100;
            }
            set
            {
                _discount = value;
            }
        }

        public List<Order> Orders { get; set; }
    }
}
