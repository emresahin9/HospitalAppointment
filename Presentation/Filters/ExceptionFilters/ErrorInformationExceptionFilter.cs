using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;

namespace Presentation.Filters.ExceptionFilters
{
    public class ErrorInformationExceptionFilter : IExceptionFilter, IActionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ITempDataDictionaryFactory _tempDataFactory;
        private readonly ErrorType _errorType;


        public ErrorInformationExceptionFilter(IModelMetadataProvider modelMetadataProvider, ITempDataDictionaryFactory tempDataFactory, ErrorType errorType = 0)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _tempDataFactory = tempDataFactory;
            _errorType = errorType;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["ActionArguments"] = context.ActionArguments;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ErrorInformation)
            {
                var tempData = _tempDataFactory.GetTempData(context.HttpContext);
                var viewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                IDictionary arguments;

                switch (_errorType)
                {
                    //case _errorType
                }


                tempData.Add("ErrorMessage", context.Exception.Message.ToString());

                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = tempData,
                    StatusCode = 406,
                };
                context.ExceptionHandled = true;
            }
        }
    }

    public enum ErrorType
    {
        Null = 0,
        _AskOurExpertForm = 1,
        _ContactForm = 2,
        _HumanResourcesForm = 3,
        _CallMeForm = 4,
    }

}
