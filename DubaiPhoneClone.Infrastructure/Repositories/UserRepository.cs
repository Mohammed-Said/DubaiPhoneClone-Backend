using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, int>,IUserRepository
    {
        private readonly ApplicationContext applicationContext;

        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)=>
            this.applicationContext = applicationContext;
        

        public void AddCartItem(int prodId, int userId, int quantity)
        {
            var existingCartItem = applicationContext?.CartItems?.FirstOrDefault(c => c.ProductID == prodId && c.UserId == userId);

            if (existingCartItem != null)
            {
                // If the item already exists, update the quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // If the item doesn't exist, add it as a new cart item
                var cartItem = new CartItem
                {
                    ProductID = prodId,
                    UserId = userId,
                    Quantity = quantity
                };
                applicationContext.CartItems.Add(cartItem);
            }

            applicationContext.SaveChanges();
        }

        public IQueryable<Order> GetCustomerOrders(int userId)=>
            applicationContext.Orders.Where(o => o.UserId == userId);

        void IUserRepository.AddWishlistItem(int prodId, int userId, int quantity)
        {
            //var existingWishlistItem = applicationContext?.WishlistItems?.FirstOrDefault(c => c.ProductId == prodId && c.UserId == userId);
            //if (existingWishlistItem != null) 
            //    return;
            //var wishlistItem = new WishlistItem
            //{
            //    ProductId = prodId,
            //    UserId = userId

            //};
            //applicationContext.WishlistItems.Add(wishlistItem);

            applicationContext.SaveChanges();

        }


    }
}
