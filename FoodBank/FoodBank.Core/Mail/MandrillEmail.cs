using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Mail.Model;
using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;


namespace FoodBank.Core.Mail
{
    public class MandrillEmail : IEmailService
    {
        public async Task<List<EmailResult>> SendGeneralEmail(BaseMailModel model)
        {
            return await SendMail(model, new Dictionary<string, string>(), "General Email");
        }



        public async Task<List<EmailResult>> SendAccountCreation(AccountCreationMailModel model)
        {
            var variables = new Dictionary<string, string>();
            variables.Add("FNAME", model.FirstName);
            variables.Add("ACTIVATELINK", model.ActivationUrl);
            return await SendMail(model, variables, "Account Creation");
        }


        public async Task<List<EmailResult>> SendResetPassword(ResetPasswordMailModel model)
        {
            var variables = new Dictionary<string, string>();
            variables.Add("FNAME", model.FirstName);
            variables.Add("RESETLINK", model.ResetLink);
            return await SendMail(model, variables, "Reset Password");
        }

        public async Task<List<EmailResult>> SendErrorExceptionEmail(ErrorLogMailModel model)
        {
            var variables = new Dictionary<string, string>();
            variables.Add("FNAME", model.FirstName);
            variables.Add("Error", model.ErrorMessage);
            return await SendMail(model, variables, "Error Message");
        }

        private async Task<List<EmailResult>> SendMail(BaseMailModel model, Dictionary<string, string> variables, string template)
        {

            var api = new MandrillApi("aLZTF2B_tAyoIF56NW9X0A");

            var mandrillRecipients = new List<EmailAddress>();
            foreach (var to in model.ToRecipients)
            {
                mandrillRecipients.Add(new EmailAddress(to));
            }

            //Account Creation
            var email = new EmailMessage()
            {
                To = mandrillRecipients,

            };

            foreach (var variable in variables)
            {
                email.AddGlobalVariable(variable.Key, variable.Value);
            }

            var sendRequest = new SendMessageTemplateRequest(email, template, null);

            return await api.SendMessageTemplate(sendRequest);
        }
    }
}
