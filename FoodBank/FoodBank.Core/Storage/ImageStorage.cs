using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using FoodBank.Core.Storage;

namespace FoodBank.Core.Storage
{
    public class ImageStorage
    {
        public async Task<string> StoreLawGroupLogo(HttpPostedFileBase file, Guid transactionId)
        {
            return await new AzureFileStorage().StoreImage("LawGroupLogo", file, transactionId);
        }
        public async Task<string> StoreFirmLogo(HttpPostedFileBase file, Guid transactionId)
        {
            return await new AzureFileStorage().StoreImage("FirmLogo", file, transactionId);
        }

        public async Task<string> StoreAvatar(HttpPostedFileBase file, Guid transactionId)
        {
            return await new AzureFileStorage().StoreImage("Avatar", file, transactionId);
        }

    }
}
