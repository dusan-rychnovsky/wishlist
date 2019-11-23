using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace Wishlist.Models
{
    public sealed class ImageService : IImageService
    {
        private readonly CloudBlobContainer container;

        public ImageService(CloudStorageAccount account, string containerName)
        {
            this.container = account.CreateCloudBlobClient().GetContainerReference(containerName);
        }

        public Task<Stream> GetImageAsync(string id)
        {
            return this.container.GetBlockBlobReference(id).OpenReadAsync();
        }

        public Task SaveImageAsync(string id, Stream stream)
        {
            return this.container.GetBlockBlobReference(id).UploadFromStreamAsync(stream);
        }
    }
}
