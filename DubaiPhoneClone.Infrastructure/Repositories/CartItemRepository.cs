using DubaiPhone.DTOs.cartDTOs;
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

        public async Task<IQueryable<ProductCartDTO>> GetCartProducts(string userId)
        {
            return from item in _appContext.CartItems
                   where item.UserId == userId
                   join prod in _appContext.Products
                   on item.ProductID equals prod.Id
                   select new ProductCartDTO
                   {
                       ProductId = prod.Id,
                       CartItemId = item.Id,
                       Name = prod.Name,
                       ArabicName = prod.ArabicName,
                       SalePrice = prod.SalePrice,
                       NormalPrice = prod.NormalPrice,
                       Quantity = item.Quantity,
                       Stock = prod.Stock,
                       Cover = prod.Cover
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
                var prod = _appContext.Products.Find(item.ProductID);

                if (prod is not null)
                    prod.Stock -= item.Quantity;

                _appContext.OrderItems.Add(orderItem);

                //Remove CartItems
                _appContext.CartItems.Remove(item);
            }
            _appContext.SaveChanges();


        }

        public async Task<bool> AddCartItem(CartItem item)
        {
            CartItem cart;
            List<CartItem> userCartItems = await _appContext.CartItems.Where(c => c.UserId == item.UserId).ToListAsync();

            Product product = _appContext.Products.FirstOrDefault(p => p.Id == item.ProductID);

            if (product is null || product.Stock <= item.Quantity)
                return false;

            var existingCartItem = userCartItems.FirstOrDefault(c => c.ProductID == item.ProductID);

            if (existingCartItem is not null)
                // If the item already exists, update the quantity
                existingCartItem.Quantity = item.Quantity;

            else
                // If the item doesn't exist, add it as a new cart item
                 _appContext.Add(item);

            return true;
        }

        public async Task<IQueryable<CartItem>> GetUserCart(string userId) =>
            _appContext.CartItems.Where(c => c.UserId == userId);

        public async Task<IQueryable<ProductCartDTO>> GetCartProducts(int[] ids)
        {
          return _appContext.Products.Where(p => ids.Contains(p.Id))
            .Select(prod=>new ProductCartDTO
            {
                ProductId = prod.Id,
                Name = prod.Name,
                ArabicName = prod.ArabicName,
                SalePrice = prod.SalePrice,
                NormalPrice = prod.NormalPrice,
                Stock = prod.Stock >5 ?5 : prod.Stock,
                Cover = prod.Cover
            });
        }
    }

}
