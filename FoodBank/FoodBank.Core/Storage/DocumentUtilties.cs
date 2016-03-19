using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Words.Saving;
using FoodBank.Core.Data.Model;
using Newtonsoft.Json;

namespace FoodBank.Core.Storage
{
    public static  class DocumentUtilties
    {
        public static string CreateDocument<T>(string documentLocation, T model) where T : class
        {
            var dt = ToDataTable(model);
            return CreateDocument(documentLocation, dt);
        }

        public static string CreateDocument(string documentLocation, string json)         {
            var dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return CreateDocument(documentLocation, dt);
        }

        public static string CreateDocument(string documentLocation, DataTable dt)
        {
            Aspose
               .Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Words.lic");
            var mydir = @"C:\Code\PropertyCentral\FoodBank\FoodBank.SeedTest\DocumentCreation\";
            Document doc = new Document(documentLocation);

            doc.MailMerge.Execute(dt);

            PdfSaveOptions options = new PdfSaveOptions();
            var newDocumentLocation = mydir + "Seed" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".pdf";
            doc.Save(newDocumentLocation, options);

            return newDocumentLocation;
        }


        private static DataTable ToDataTable<T>(T entity) where T : class
        {
            var properties = typeof(T).GetProperties();
            var table = new DataTable();

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
            }

            table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
            return table;
        }

        
    }

}
