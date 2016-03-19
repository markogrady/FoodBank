using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Helpers;
using FoodBank.Core.Seed;
using FoodBank.Web.Models;
using log4net;
using Microsoft.ApplicationInsights;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FoodBank.Web.Controllers
{
    public class BaseFoodController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(BaseFoodController));

        private ApplicationUserManager _userManager;

        public void Success(string message)
        {
            TempData["SuccessMessage"] = message;
        }

        public void Error(string message)
        {
            TempData["ErrorMessage"] = message;
        }

        public void InfoMessage(string message)
        {
            TempData["InformationMessage"] = message;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private AuthenticatedUserModel _authenticatedUser;

        public AuthenticatedUserModel AuthenticatedUser
        {
            get
            {
                if (_authenticatedUser == null)
                {
                    // get the profile
                    if (User != null && User.Identity.IsAuthenticated)
                    {

                        _authenticatedUser = new AuthenticatedUserModel();
                        _authenticatedUser.UserId = Guid.Parse(User.Identity.GetUserId());

                        _authenticatedUser.AppUser = UserManager.FindById(_authenticatedUser.UserId);


                        _authenticatedUser.Avatar = !String.IsNullOrEmpty(_authenticatedUser.AppUser.AvatarUrl) ? _authenticatedUser.AppUser.AvatarUrl : "/assets/images/placeholder.jpg";

                        if (User.IsInRole("FoodBank"))
                        {
                            _authenticatedUser.AuthBankModel = GetAuthFirmModel(_authenticatedUser.UserId);
                            _authenticatedUser.CompanyFirmId = _authenticatedUser.AuthBankModel.BankCompanyId;
                            _authenticatedUser.PartyType = PartyType.FoodBank;
                        }
                        //if (User.IsInRole("Admin"))
                        //{

                        //}
                        //if (User.IsInRole("Surveyor"))
                        //{
                        //    _authenticatedUser.AuthSurveyorModel = GetAuthSurveyorModel(_authenticatedUser.UserId);
                        //}
                        //if (User.IsInRole("Conveyancer"))
                        //{
                        //    _authenticatedUser.AuthConvFirmModel = GetAuthConvFirmModel(_authenticatedUser.UserId);
                        //    _authenticatedUser.CompanyId = _authenticatedUser.AuthConvFirmModel.ConveyencerFirmId;
                        //    _authenticatedUser.PartyType = PartyType.Conveyancer;
                        //}

                    }
                }


                return _authenticatedUser;

            }
            set { _authenticatedUser = value; }
        }

        private AuthBankModel GetAuthFirmModel(Guid userId)
        {
            var model = new AuthBankModel();
            using (var context = new AppDbContext())
            {
                var bankUser = context.BankUsers.Select(o => new
                {
                    o.BankUserId,
                    o.BankCompanyId,
                    o.BankCompany.BankCompanyName
                }).FirstOrDefault(o => o.BankUserId == userId);
                if (bankUser != null)
                {
                    model.BankCompanyId = bankUser.BankCompanyId;
                    model.BankCompanyName = bankUser.BankCompanyName;
                }
            }
            return model;
        }

        #region Events

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (AuthenticatedUser != null)
            //{
            //    log4net.GlobalContext.Properties["UserName"] = AuthenticatedUser.AppUser.UserName;

            //}

            log.Error(filterContext.Exception.Message, filterContext.Exception);
            var ai = new TelemetryClient();
            ai.TrackException(filterContext.Exception);
            filterContext.Controller.TempData.Add("ErrorMessage", filterContext.Exception.Message);
            filterContext.Controller.TempData.Add("ErrorMessage2", filterContext.Exception.ToString());
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                TempData = filterContext.Controller.TempData
            };

            filterContext.ExceptionHandled = true;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SetViewBagDefaultProperties();
            base.OnActionExecuted(filterContext);
        }

        private void SetViewBagDefaultProperties()
        {
            if (this.AuthenticatedUser != null)
            {
                ViewBag.FullName = this.AuthenticatedUser.AppUser.FirstName + " " + AuthenticatedUser.AppUser.LastName;
                ViewBag.Avatar = this.AuthenticatedUser.Avatar;

                if (AuthenticatedUser.AuthBankModel != null)
                    ViewBag.CompanyName = this.AuthenticatedUser.AuthBankModel.BankCompanyName;
            }

        }

        protected void SetCompanyViewBag(Guid id)
        {
            ViewBag.AccCompanyId = id;

        }
        #endregion Events



    }
}