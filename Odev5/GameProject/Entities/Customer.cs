﻿using GameProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Customer: IEntity
    {
        public int Id { get; set; }
        public string TcNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Order> Orders{ get; set; }
    }
}
