using AutoMapper;

namespace RestApi.Shared
{
    public static class RestApiMapperFactory
    {
        public static IMapper CreateMapper()
        {
            //TODO Set the mapping of entities to models here
            return null;
            //return new MapperConfiguration(config => {
            //    config.CreateMap<Job, JobModel>();
            //    config.CreateMap<CreateJobRequest, Job>()
            //        .ForMember(r => r.Id, c => c.Ignore())
            //        .ForMember(r => r.ProjectManager, c => c.Ignore());
            //    config.CreateMap<Employee, EmployeeModel>();
            //    config.CreateMap<CreateEmployeeRequest, Employee>()
            //        .ForMember(r => r.Id, c => c.Ignore());
            //}).CreateMapper();
        }
    }
}