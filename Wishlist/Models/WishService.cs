using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Wishlist.Models
{
    public sealed class WishService : IWishService
    {
        private readonly Container container;

        public WishService(CosmosClient client, string dbName, string containerName)
        {
            this.container = client.GetContainer(dbName, containerName);
        }

        public async Task<IEnumerable<Wish>> GetAllWishesAsync()
        {
            var query = this.container.GetItemQueryIterator<Wish>(new QueryDefinition("SELECT * FROM c"));
            List<Wish> result = new List<Wish>();
            while (query.HasMoreResults)
            {
                result.AddRange(await query.ReadNextAsync());
            }
            return result;
        }
    }
}
