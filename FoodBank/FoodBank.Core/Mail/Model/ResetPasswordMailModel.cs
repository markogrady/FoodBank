using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Mail.Model
{
    public class ResetPasswordMailModel :BaseMailModel
    {
        public string ResetLink { get; set; }
    }
}
