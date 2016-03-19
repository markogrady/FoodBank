using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;


namespace FoodBank.Core.Storage
{

    internal class AzureFileStorage
    {

        //public async Task<string> StoreDocument(DocumentType documentType, HttpPostedFileBase file, Guid transactionId)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var filename = Path.GetFileName(file.FileName);

        //        var storageAccount = StorageUtils.StorageAccount();
        //        var blobStorage = storageAccount.CreateCloudBlobClient();
        //        CloudBlobContainer container = blobStorage.GetContainerReference(documentType.ToString().ToLower());
        //        if (container.CreateIfNotExists())
        //        {
        //            // configure container for public access
        //            var permissions = container.GetPermissions();
        //            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
        //            container.SetPermissions(permissions);
        //        }
        //        string uniqueBlobName = string.Format("{0}/document_{1}{2}", documentType.ToString().ToLower(), transactionId.ToString(),
        //           Path.GetExtension(file.FileName));
        //        CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
        //        blob.Properties.ContentType = file.ContentType;
        //        var stream = new System.IO.MemoryStream();
        //        stream.Position = 0;
        //        await blob.UploadFromStreamAsync(stream);
        //        stream.Dispose();

        //        return blob.Uri.ToString();
        //    }
        //    return null;
        //}


        public async Task<string> StoreTemplateDocument(HttpPostedFileBase file, Guid documentTemplateId)
        {
            return await BaseStoreDocument(file, documentTemplateId.ToString(), "template");
        }

        public async Task<string> StoreExportTemplateDocument(HttpPostedFileBase file, Guid documentTemplateId)
        {
            return await BaseStoreDocument(file, documentTemplateId.ToString(), "exporttemplate");
        }
        public async Task<string> BaseStoreDocument(HttpPostedFileBase file, string fileId, string folderName)
        {
            if (file.ContentLength > 0)
            {
                var filename = Path.GetFileName(file.FileName);

                var storageAccount = StorageUtils.StorageAccount();
                var blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference(folderName);
                if (container.CreateIfNotExists())
                {
                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);
                }
                string uniqueBlobName = string.Format("{0}/document_{1}{2}", folderName, fileId.ToString(),
                   Path.GetExtension(file.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = file.ContentType;

                await blob.UploadFromStreamAsync(file.InputStream);


                return blob.Uri.ToString();
            }
            return null;
        }

        public async Task<string> StoreInstructionDocument(HttpPostedFileBase file, Guid instructionId)
        {
            return await BaseStoreDocument(file, instructionId.ToString() + "-" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm"), "instruction");

        }


        public async Task<string> StoreImage(String imageType, HttpPostedFileBase file, Guid transactionId, int width = 200, int height = 200)
        {
            if (file.ContentLength > 0)
            {
                var filename = Path.GetFileName(file.FileName);

                System.Drawing.Image sourceimage = System.Drawing.Image.FromStream(file.InputStream);


                var compressedImage = ImageUtilities.ResizeImage(sourceimage, width, height);


                var storageAccount = StorageUtils.StorageAccount();
                var blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference(imageType.ToLower());
                if (container.CreateIfNotExists())
                {
                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);
                }


                string uniqueBlobName = string.Format("image_{0}{1}", imageType.ToLower(), transactionId.ToString(),
                    Path.GetExtension(file.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = file.ContentType;
                var stream = new System.IO.MemoryStream();
                compressedImage.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                await blob.UploadFromStreamAsync(stream);
                stream.Dispose();

                return blob.Uri.ToString();
            }
            return null;
        }



    }
}
