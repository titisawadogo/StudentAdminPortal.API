using System;
using System.Linq;
using FluentValidation;
using StudentAdminPortal.API.DomainsModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Validators
{
    public class AddStudentRequestValidator: AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(999999).LessThan(10000000000);

            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetGenderAsync().Result.ToList()
                .FirstOrDefault(x => x.Id == id);

                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid Gender");

            RuleFor(x => x.PhysicalAdress).NotEmpty();
            RuleFor(x => x.PostalAdress).NotEmpty();
        }
    }
}
