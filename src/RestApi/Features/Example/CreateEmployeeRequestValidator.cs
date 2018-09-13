using FluentValidation;
using RestApi.Shared;
using RestApi.Shared.Rest;

namespace RestApi.Features.Example
{
    public class CreateEmployeeRequestValidator : RestApiValidator<RestPostRequest<Employee, CreateEmployeeRequest, EmployeeModel>>
    {
        public CreateEmployeeRequestValidator(RestApiDbContext opinionatedDbContext) 
            : base(opinionatedDbContext)
        {
            RuleFor(e => e.NewEntity.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(e => e.NewEntity.LastName).NotEmpty().WithMessage("Last name is required.");
        }
    }
}