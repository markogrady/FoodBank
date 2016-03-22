using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace FoodBank.Core.Dto.Bank
{
    public class BankIndexModel
    {
        public BankIndexModel()
        {
            BankIndexItemModels = new List<BankIndexItemModel>();
        }
        public List<BankIndexItemModel> BankIndexItemModels { get; set; }
    }


    public class BankIndexItemModel
    {
        public Guid BankCompanyId { get; set; }
        public string BankCompanyName { get; set; }
    }
}
