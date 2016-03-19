using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mandrill.Requests.Templates;

using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Storage
{
    public class DocumentStorage
    {
        public async Task<string> StoreInstructionDocument( HttpPostedFileBase file,
            Guid transactionId)
        {
            return await new AzureFileStorage().StoreInstructionDocument(file, transactionId);
        }

        public async Task<string> StoreTemplate(HttpPostedFileBase file, Guid documentTemplateId)
        {
           return await new AzureFileStorage().StoreTemplateDocument(file, documentTemplateId);

        }

        public async Task<string> StoreExportTemplate(HttpPostedFileBase file, Guid documentTemplateId)
        {
            return await new AzureFileStorage().StoreTemplateDocument(file, documentTemplateId);

        }



    }
}
