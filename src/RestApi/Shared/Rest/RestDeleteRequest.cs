using MediatR;

namespace RestApi.Shared.Rest
{
    public class RestDeleteRequest<TEntity> : IRequest<object>
        where TEntity : RestApiEntity
    {
        public int Id { get; set; }
    }
}