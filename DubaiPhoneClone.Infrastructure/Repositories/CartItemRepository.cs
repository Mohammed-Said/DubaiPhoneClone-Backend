using DubaiPhone.DTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class CartItemRepository : Repository<CartItem, int>, ICartItemRepository
    {
        private readonly ApplicationContext _appContext;

        public CartItemRepository(ApplicationContext context) : base(context)
        {
            _appContext = context;
        }

        public bool ChangeQuantity(int cartItemId, int quantity)
        {
            // Retrieve the associated book
            var item = _appContext.CartItems?.FirstOrDefault(i => i.Id == cartItemId);

            if (item == null)
                return false;

            if (quantity == 0)
                Delete(item.Id);
            else
            {
                item.Quantity = quantity;
                Update(item);
            }

            _appContext.SaveChanges();

            return true;
        }
        public IQueryable<ProductCart> GetUserCart(int userId)
        {
            return from item in _appContext.CartItems
                   where item.UserId == userId
                   join prod in _appContext.Products.Include(p => p.Images)?.Select(p => p)
                   on item.ProductID equals prod.Id
                   select new ProductCart
                   {
                       ProductId = prod.Id,
                       CartItemId = item.Id,
                       Title = prod.Name,
                       Price = prod.Price,
                       Quantity = item.Quantity,
                       Stock = prod.Stock,
                       ImagePath = prod.Images.FirstOrDefault().Path 
                   };
        }
        public void PlaceOrder(Order order)
        {
            //Create Order

            _appContext.Orders.Add(order);
            _appContext.SaveChanges();

            //Add Cart items into Order items
            //Get All Customer Catr items
            var cartItems = _appContext.CartItems.Where(c => c.UserId == order.UserId);

            foreach (var item in cartItems)
            {
                //Create Order item
                OrderItem orderItem = new OrderItem();
                orderItem.OrderID = order.Id;
                orderItem.Quantity = item.Quantity;
                orderItem.ProductID = item.ProductID;
                _appContext.OrderItems.Add(orderItem);

                //Remove CartItems
                _appContext.CartItems.Remove(item);
            }
            _appContext.SaveChanges();


        }

    }
    
}
