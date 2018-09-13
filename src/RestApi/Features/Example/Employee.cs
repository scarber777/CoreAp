using RestApi.Shared;

namespace RestApi.Features.Example
{
    public class Employee : RestApiEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}