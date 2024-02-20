using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Application.Personal.Validation;
using Common.Number;
using Domain.Personal;
using EndPointSite.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Common.BaseDTO.ResultViewModel;

namespace EndPointSite.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }
        [HttpGet]
        public IActionResult Index()
        {          
             List<ListPersonViewModel>Result = _personFacade.GetListPersonService.GetAll();
            Result.Select(p => new PersonViewModel
            {
                Firstname = p.Firstname,
                Lastname = p.Lastname,
                DateOfBirth = DateTime.Now,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
            }).ToList();
            return View(Result);
        }

        [HttpPost]
        public IActionResult Add(AddPersonViewModel  addPersonViewModel)
        {
            PersonValidator validator = new PersonValidator();
            List<string> ValidationMessages = new();
            var person = new Person
            {
                Firstname = addPersonViewModel.Firstname,
                Lastname = addPersonViewModel.Lastname,
                Email = addPersonViewModel.Email,
                DateOfBirth = addPersonViewModel.DateOfBirth,
                PhoneNumber = addPersonViewModel.PhoneNumber,
            };
            var validationResult = validator.Validate(person);
            ResultDataModel response = new();
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.Message = ValidationMessages;
                return Json(response);
            }
             response = _personFacade.PersonVaidationService.CheckUniqEmail(addPersonViewModel.Email);
             if (!response.IsSuccess)
            {
                return Json(response);
            }
            response = _personFacade.PersonVaidationService.CheckUniqUser(person);
            if (!response.IsSuccess)
            {
                return Json(response);
            }
            else
            {
                if(!string.IsNullOrEmpty(addPersonViewModel.PhoneNumber))
                addPersonViewModel.PhoneNumber =ConvertArabicNumberToEnglish.ToEnglishNumber(addPersonViewModel.PhoneNumber.Trim());
                response = _personFacade.AddPersonService.Add(addPersonViewModel);
                return Json(response);
            }
        }

        [HttpPut]
        public IActionResult Edit(EditPersonViewModel editPersonViewModel)
        {
            PersonValidator validator = new PersonValidator();
            List<string> ValidationMessages = new();
            var person = new Person
            {
                Firstname = editPersonViewModel.Firstname,
                Lastname = editPersonViewModel.Lastname,
                Email = editPersonViewModel.Email,
                DateOfBirth = editPersonViewModel.DateOfBirth,
                PhoneNumber = editPersonViewModel.PhoneNumber,
            };
            var validationResult = validator.Validate(person);
            ResultDataModel response = new();
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.Message = ValidationMessages;
                return Json(response);
            }
            response = _personFacade.PersonVaidationService.CheckUniqEmail(editPersonViewModel.Email);
            if (!response.IsSuccess)
            {
                return Json(response);
            }
            response = _personFacade.PersonVaidationService.CheckUniqUser(person);
            if (!response.IsSuccess)
            {
                return Json(response);
            }
            else
            {
                if (!string.IsNullOrEmpty(editPersonViewModel.PhoneNumber))
                    editPersonViewModel.PhoneNumber = ConvertArabicNumberToEnglish.ToEnglishNumber(editPersonViewModel.PhoneNumber.Trim());
                response = _personFacade.EditPersonService.Edit(editPersonViewModel);
                return Json(response);
            }
        }

        //[HttpDelete]
        //public IActionResult Delete(int Id)
        //{
            
        //}
    }
}
