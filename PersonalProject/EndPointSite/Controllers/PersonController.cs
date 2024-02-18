using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Application.Personal.Validation;
using Domain.Personal;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
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
            return View();
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
            response = _personFacade.PersonVaidationService.CheckUniqUser(addPersonViewModel);
            if (!response.IsSuccess)
            {
                return Json(response);
            }
            else
            {
                response = _personFacade.AddPersonService.Add(addPersonViewModel);
                return Json(response);
            }
        }
    }
}
