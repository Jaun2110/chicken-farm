using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs.Order
{
    public class CreateOrderRequest
    {
        public string Customer { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DozensOrdered { get; set; }
        public decimal PricePerDozen { get; set; }
        public DateOnly DeliveryDate { get; set; }
    }
}