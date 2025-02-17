using Autofac.Core;
using Business.Abstract;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Model.Concrete.Dto;
using System.Collections;

namespace Presentation.Filters.ExceptionFilters
{
    public class ValidationExceptionFilter : IExceptionFilter, IActionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ITempDataDictionaryFactory _tempDataFactory;
        private readonly ValidationType _validationType;
        private readonly IMedicalSpecialtyService _medicalSpecialtyService;

        public ValidationExceptionFilter(IModelMetadataProvider modelMetadataProvider, ITempDataDictionaryFactory tempDataFactory, IMedicalSpecialtyService medicalSpecialtyService, ValidationType validationType = 0)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _tempDataFactory = tempDataFactory;
            _validationType = validationType;
            _medicalSpecialtyService = medicalSpecialtyService;
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
            if (context.Exception is ValidationException ex)
            {
                var tempData = _tempDataFactory.GetTempData(context.HttpContext);
                var viewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                IDictionary arguments;

                switch (_validationType)
                {
                    case ValidationType.Login:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var login = arguments["model"] as LoginDto;
                        viewData.Model = login;
                        break;
                    case ValidationType.MedicalSpecialty:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var medicalSpecialty = arguments["model"] as MedicalSpecialtyDto;
                        viewData.Model = medicalSpecialty;
                        break;
                    case ValidationType.Doctor:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var doctor = arguments["model"] as DoctorDto;
                        tempData.Add("MedicalSpecialties", _medicalSpecialtyService.GetAll());
                        viewData.Model = doctor;
                        break;
                }

                var validationResult = new ValidationResult(ex.Errors);
                validationResult.AddToModelState(context.ModelState, null);
                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = tempData,
                    StatusCode = 422,
                };
                context.ExceptionHandled = true;
            }
        }

    }

    public enum ValidationType
    {
        Null = 0,
        Login = 1,
        MedicalSpecialty = 2,
        Doctor = 3
    }
}
