using AutoMapper;
using RestApi.Features.Example;

namespace RestApi.Shared
{
    public static class RestApiMapperFactory
    {
        public static IMapper CreateMapper()
        {
            //TODO Set the mapping of entities to models here
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Employee, EmployeeModel>();
                config.CreateMap<CreateEmployeeRequest, Employee>()
                    .ForMember(r => r.Id, c => c.Ignore());
            }).CreateMapper();
        }
    }
}