using RestApi.Shared.Gets;

namespace RestApi.Features.Example
{
    public class EmployeeModel : IGetModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}