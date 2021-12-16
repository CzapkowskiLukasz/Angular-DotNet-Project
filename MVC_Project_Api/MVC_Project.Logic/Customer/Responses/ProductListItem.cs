﻿using System;
namespace MVC_Project.Logic.Customer.Responses
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int WarehouseQuantity { get; set; }

        public string ProducerName { get; set; }
    }
}