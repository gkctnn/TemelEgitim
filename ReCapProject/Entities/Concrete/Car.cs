using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    [ToTable("Cars")]
    [ToTable("TblCars")]
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        [RequiredProperty]
        public string Name { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class RequiredPropertyAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string _v;

        public ToTableAttribute(string v)
        {
            _v = v;
        }
    }
}
