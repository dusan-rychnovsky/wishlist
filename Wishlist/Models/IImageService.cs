using System.IO;
using System.Threading.Tasks;

namespace Wishlist.Models
{
    public interface IImageService
    {
        Task<Stream> GetImageAsync(string id);
    }
}
