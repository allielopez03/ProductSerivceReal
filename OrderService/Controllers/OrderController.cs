﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                CustomerName = "John Doe",
                Products = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, ProductName = "Laptop", Price = 1200 }
                }
            }
        };

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.Id = orders.Max(o => o.Id) + 1;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }
    }
}