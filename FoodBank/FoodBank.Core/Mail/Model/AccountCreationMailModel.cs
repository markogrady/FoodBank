using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Mail.Model
{
    public class AccountCreationMailModel :BaseMailModel
    {
        public string ActivationUrl { get; set; }
    }
}
