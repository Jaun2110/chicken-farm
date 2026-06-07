using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Enums;

namespace ChickenFarm.Application.DTOs.Order
{
    public class UpdateOrderStatusRequest
    {
        public OrderStatus Status { get; set; }

    }
}