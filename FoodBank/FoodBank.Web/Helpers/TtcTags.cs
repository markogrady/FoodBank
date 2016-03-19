using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace FoodBank.Web.Helpers
{
    public static class TtcHtmlHelpers
    {
        public static MvcHtmlString TtcWizTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, string placeholder)
        {
            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var valueAttr = "";
            if (metadata.Model != null)
            {
                valueAttr = String.Format("value='{0}'", metadata.Model);
            }

            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label>{0}</label>", labelText));

            builder.Append(String.Format("<input type='text' name='{0}' class='form-control {1}' placeholder='{2}' {3}>", htmlFieldName, require, placeholder, valueAttr));

            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcFullTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, string placeholder)
        {
            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var valueAttr = "";
            if (metadata.Model != null)
            {
                valueAttr = String.Format("value='{0}'", metadata.Model);
            }

            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label class='control-label col-lg-2'>{0}</label>", labelText));
            builder.Append("<div class='col-lg-10'>");
            builder.Append(String.Format("<input type='text' name='{0}' class='form-control {1}' placeholder='{2}' {3}>", htmlFieldName, require, placeholder, valueAttr));
            builder.Append(String.Format("</div>"));
            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcFullReadOnlyTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, string placeholder)
        {
            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var valueAttr = "";
            if (metadata.Model != null)
            {
                valueAttr = String.Format("value='{0}'", metadata.Model);
            }

            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label class='control-label col-lg-2'>{0}</label>", labelText));
            builder.Append("<div class='col-lg-10'>");
            builder.Append(String.Format("<input type='text' name='{0}' class='form-control {1}' placeholder='{2}' readonly='readonly' {3}>", htmlFieldName, require, placeholder, valueAttr));
            builder.Append(String.Format("</div>"));
            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcFullLinkTextBox(this HtmlHelper htmlhelper, string labelText, MvcHtmlString link)
        {



            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label class='control-label col-lg-2'>{0}</label>", labelText));
            builder.Append("<div class='col-lg-10'>");
            builder.Append(link);
            builder.Append(String.Format("</div>"));
            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcFullTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, string placeholder, int rows, int cols)
        {
            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var valueAttr = "";
            if (metadata.Model != null)
            {
                valueAttr = String.Format("{0}", metadata.Model);
            }

            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label class='control-label col-lg-2'>{0}</label>", labelText));
            builder.Append("<div class='col-lg-10'>");
            builder.Append($"<textarea name='{htmlFieldName}' class='form-control {require}' placeholder='{placeholder}'  rows='{rows}' col='{cols}' >{valueAttr}</textarea>");
            builder.Append(String.Format("</div>"));
            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcDropDownFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectListItems, string placeholder, bool isFullText)
        {
            var labelClasses = "";
            var valueAttr = "";
            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (metadata.Model != null)
            {
                valueAttr = metadata.Model.ToString();
            }
            
            if (isFullText)
            {
                labelClasses = "class='control-label col-lg-2'";
            }
            
            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label {0}>{1}</label>", labelClasses, labelText));
            if (isFullText)
            {
                builder.Append(String.Format("<div class='col-lg-10'>"));
            }

            builder.Append(String.Format("<select name='{0}' data-placeholder='{1}' class='bootstrap-select' {2}>", htmlFieldName, placeholder, required));
            foreach (var selectListItem in selectListItems)
            {
                var selectedAttr = "";
                if (valueAttr == selectListItem.Value)
                {
                    selectedAttr = "selected='selected'";
                }
                builder.Append(String.Format("<option {2} value='{0}'>{1} </option>", selectListItem.Value, selectListItem.Text,selectedAttr));
            }
            builder.Append("</select>");
            if (isFullText)
            {
                builder.Append(String.Format("</div>"));
            }

            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcEnumDropDownFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, Type newenum, string placeholder, bool isFullText)
        {
            var labelClasses = "";

            bool required = false;
            string require = required ? "required" : "";
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (isFullText)
            {
                labelClasses = "class='control-label col-lg-2'";
            }


            var builder = new StringBuilder(@"<div class='form-group'>");
            builder.Append(String.Format("<label {0}>{1}</label>", labelClasses, labelText));
            if (isFullText)
            {
                builder.Append(String.Format("<div class='col-lg-10'>"));
            }

            builder.Append(String.Format("<select name='{0}' data-placeholder='{1}' class='select {2}'>", htmlFieldName, placeholder, required));

            var valueAttr = "";
            if (metadata.Model != null)
            {
                valueAttr = String.Format("{0}", metadata.Model);

            }

            foreach (int value in Enum.GetValues(newenum))
            {
                //skip not set
                if (value == 0)
                    continue;
                var selected = "";

                var text = Enum.GetName(newenum, value);
                if (text == valueAttr)
                    selected = "selected";
                var memInfo = newenum.GetMember(text);
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                //TODO Improve
                try
                {
                    var description = ((DescriptionAttribute)attributes[0]).Description;
                    if (!string.IsNullOrEmpty(description))
                    {
                        text = description;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                builder.Append(String.Format("<option value='{0}' {1}>{2} </option>", value, selected, text));
            }


            builder.Append("</select>");
            if (isFullText)
            {
                builder.Append(String.Format("</div>"));
            }

            builder.Append(String.Format("</div>"));

            return new MvcHtmlString(builder.ToString());
        }


        public static MvcHtmlString TtcCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlhelper,
            Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            bool? isChecked = new bool?();
            bool result;
            if (metadata.Model != null && bool.TryParse(metadata.Model.ToString(), out result))
                isChecked = new bool?(result);


            var isCheckValue = isChecked != null && isChecked.Value ? "checked" : "";
            var builder = new StringBuilder(@"<div class='checkbox checkbox-right'>");
            builder.Append(String.Format("<label>"));

            builder.Append(String.Format("<div><span class=''><input type='checkbox'  checked='{0}'></span></div>{1}", isCheckValue, labelText));
            builder.Append(String.Format("</label>"));
            builder.Append(String.Format("</div>"));



            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcSaveRight(this HtmlHelper htmlHelper)
        {
            var builder = new StringBuilder("<div class='text-right'><button type='submit' class='btn btn-primary'>Save</button></div>");

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcInfoAlert(this HtmlHelper htmlHelper, string message)
        {
            var builder = new StringBuilder(@"<div class='alert bg-primary alert-styled-left'><button type='button' class='close' data-dismiss='alert'><span>×</span><span class='sr-only'>Close</span></button>
                                <span class='text-semibold'>" + message + "</span></div>");
            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString TtcUpload<TModel, TValue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, TValue>> expression, List<string> fileTypes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlhelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
           

            var builder = new StringBuilder(string.Format("<div class='form-group'> <label class='col-lg-2 control-label text-semibold'>{0}:</label><div class='col-lg-10'><input type='file' class='file-input' name='{1}' data-show-upload='false' data-show-preview='false' data-allowed-file-extensions='['pdf']' ></div></div>", labelText,htmlFieldName));
            return new MvcHtmlString(builder.ToString());
        }
    }
}