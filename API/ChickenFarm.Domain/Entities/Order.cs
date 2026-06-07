

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Enums;

namespace ChickenFarm.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DozensOrdered { get; set; }
        public decimal PricePerDozen { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Open;
    }
}