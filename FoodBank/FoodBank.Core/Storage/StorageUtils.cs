using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;

namespace FoodBank.Core.Storage
{
    public static class StorageUtils
    {
        public static CloudStorageAccount StorageAccount()
        {
            string account = CloudConfigurationManager.GetSetting("StorageAccountName");
            string key = CloudConfigurationManager.GetSetting("StorageAccountAccessKey");
            string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
