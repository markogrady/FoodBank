using System.Collections.Generic;

namespace FoodBank.Core.Mail.Model
{
    public class BaseMailModel
    {
        public BaseMailModel()
        {
            ToRecipients = new List<string>();
            CcRecipients = new List<string>();
            BccRecipients = new List<string>();
        }

        public List<string> ToRecipients { get; set; }
        public List<string> CcRecipients { get; set; }
        public List<string> BccRecipients { get; set; }
        public string Subject { get; set; }
        public string FirstName { get; set; }
     
    }
}