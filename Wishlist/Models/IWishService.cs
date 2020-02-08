using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.Models
{
    public interface IWishService
    {
        Task<IEnumerable<Wish>> GetAllWishesAsync();

        Task<IEnumerable<Wish>> GetAllEnabledWishesAsync();

        Task CreateWishAsync(Wish wish);
    }
}