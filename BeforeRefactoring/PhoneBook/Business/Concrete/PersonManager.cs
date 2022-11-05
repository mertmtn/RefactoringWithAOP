using Business.Abstract;
using Business.ValidatonRules.FluentValidation;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Data.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        private readonly ILogger<PersonManager> _logger;
        public PersonManager(IPersonDal personDal, ILogger<PersonManager> logger)
        {
            _logger = logger;
            _personDal = personDal;
        }

        public IDataResult<List<Person>> GetAllPerson()
        {
            _logger.LogDebug("Inside GetAllPerson endpoint");
            var result = _personDal.GetAll();
            return new SuccessDataResult<List<Person>>(result);
        }

        public IResult UpdatePerson(Person person)
        {
            try
            {
                var validator = new PersonValidator();
                var validationResult = validator.Validate(person);
                if (!validationResult.IsValid)
                {
                    List<string> errorList = new();
                    foreach (var error in validationResult.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                    return new ErrorDataResult<List<string>>(errorList, "Alanları kontrol ediniz.");
                }
                _personDal.Update(person);
                return new SuccessResult("Person updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex.StackTrace);
                return new ErrorResult("Error occurred during operation, please try again later.");
            }
        }

        public IResult AddNewPerson(Person person)
        {
            try
            {
                var validator = new PersonValidator();
                var validationResult = validator.Validate(person);
                if (!validationResult.IsValid)
                {
                    List<string> errorList = new();
                    foreach (var error in validationResult.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                    return new ErrorDataResult<List<string>>(errorList, "Alanları kontrol ediniz.");
                }
                _personDal.Add(person);
                return new SuccessResult("Person added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex.StackTrace);
                return new ErrorResult("Error occurred during operation, please try again later.");
            }
        }

        public IDataResult<Person> GetPersonById(int personId)
        {
            var result = _personDal.Get(x => x.Id == personId);
            return new SuccessDataResult<Person>(result);
        }
    }
}
