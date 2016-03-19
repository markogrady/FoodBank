using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Mail.Model
{
    public class ErrorLogMailModel :BaseMailModel
    {
        public string ErrorMessage { get; set; }
    }
}
