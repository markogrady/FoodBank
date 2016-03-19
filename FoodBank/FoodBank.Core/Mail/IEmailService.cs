using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using FoodBank.Core.Mail.Model;

namespace FoodBank.Core.Mail
{
    public interface IEmailService
    {
        Task<List<EmailResult>> SendGeneralEmail(BaseMailModel model);
        Task<List<EmailResult>> SendAccountCreation(AccountCreationMailModel model);
        Task<List<EmailResult>> SendResetPassword(ResetPasswordMailModel model);
        Task<List<EmailResult>> SendErrorExceptionEmail(ErrorLogMailModel model);


    }
}
