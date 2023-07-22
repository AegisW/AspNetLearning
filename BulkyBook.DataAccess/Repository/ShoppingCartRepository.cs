using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;


        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(int shoppingCartId, int count)
        {
            var shoppingCart = _db.ShoppingCarts.FirstOrDefault(x => x.Id == shoppingCartId);
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrememtCount(int shoppingCartId, int count)
        {
            var shoppingCart = _db.ShoppingCarts.FirstOrDefault(x => x.Id == shoppingCartId);
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
