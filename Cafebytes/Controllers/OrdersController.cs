using CafebytesInterfaces;
using CafebytesModels.Auth;
using CafebytesModels.MasterDetails;
using CafebytesModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafebytes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Order> orderRepo;
        private readonly IGenericRepo<Product> productRepo;
        private readonly IGenericRepo<User> userRepo;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            orderRepo = this.unitOfWork.GetRepo<Order>();
            productRepo = this.unitOfWork.GetRepo<Product>();
            userRepo = this.unitOfWork.GetRepo<User>();
        }

        /*        [HttpPost]
                public async Task<ActionResult<Order>> CreateOrder(OrderModel orderModel)
                {
                    // Retrieve the product based on the ProductID from the database
                    var product = await productRepo.GetAsync(p => p.ProductID == orderModel.ProductID);

                    if (product == null)
                    {
                        return NotFound("Product not found");
                    }

                    // Create a new Order entity based on the OrderModel
                    var order = new Order
                    {
                        ProductID = orderModel.ProductID,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = orderModel.Quantity
                        // Add other properties as needed
                    };

                    // Add the order to the order repository and save changes
                    await orderRepo.AddAsync(order);
                    await unitOfWork.CompleteAsync();

                    return CreatedAtAction(nameof(GetOrder), new { id = order.OrderID }, order);
                }*/

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(List<OrderModel> orderModels)
        {
            foreach (var orderModel in orderModels)
            {
                // Retrieve the product based on the ProductID from the database
                var product = await productRepo.GetAsync(p => p.ProductID == orderModel.ProductID);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                // Create a new Order entity based on the OrderModel
                var order = new Order
                {
                    ProductID = orderModel.ProductID,
                    ProductName = product.ProductName,
                    Price = product.SellPrice* orderModel.Quantity,
                    Quantity = orderModel.Quantity,
                    OrderNumber = orderModel.OrderNumber
                    // Add other properties as needed
                };

                // Add the order to the order repository
                await orderRepo.AddAsync(order);
            }

            // Save changes
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        /*        [HttpPost]
                public async Task<ActionResult<Order>> CreateOrder(OrderModel orderModel)
                {
                    // Retrieve the product based on the ProductID from the database
                    var product = await productRepo.GetAsync(p => p.ProductID == orderModel.ProductID);

                    if (product == null)
                    {
                        return NotFound("Product not found");
                    }

                    var username = await userRepo.GetAsync(u => u.UserName == orderModel.UserName);

                    if (username == null)
                    {
                        return NotFound("Username not found");
                    }

                    // Create a new Order entity based on the OrderModel
                    var order = new Order
                    {
                        ProductID = orderModel.ProductID,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = orderModel.Quantity,
                        UserName = username.UserName  // Assign the retrieved username
                                                      // Add other properties as needed
                    };

                    // Add the order to the order repository and save changes
                    await orderRepo.AddAsync(order);
                    await unitOfWork.CompleteAsync();

                    return Ok();
                }*/



        [HttpGet("{ordernumber}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByOrdernumber(string ordernumber)
        {
            var orders = await orderRepo.GetAllAsync(o => o.OrderNumber == ordernumber);

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the given order number");
            }

            return orders.ToList();
        }



        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await orderRepo.GetAllAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found");
            }

            return orders.ToList();
        }


        [HttpDelete("truncate")]
        public async Task<IActionResult> TruncateOrders()
        {
            await orderRepo.DeleteAllAsync();
            await unitOfWork.CompleteAsync();

            return Ok("Orders table truncated");
        }






        // Add other actions as needed (e.g., GetOrders, UpdateOrder, DeleteOrder)

    }
}
