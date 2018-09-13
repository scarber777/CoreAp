using AutoMapper;
using MediatR;
using RestApi.Shared;
using RestApi.Shared.Rest;

namespace RestApi.Features.Example
{
    public class EmployeesController : RestController<Employee, EmployeeModel, EmployeeModel, CreateEmployeeRequest>
    {
        public EmployeesController(RestApiDbContext opinionatedDbContext, IMapper mapper, IMediator mediator)
            : base(opinionatedDbContext, mapper, mediator)
        {
        }
    }
}
