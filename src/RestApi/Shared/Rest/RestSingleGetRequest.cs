using MediatR;
using RestApi.Shared.Gets;

namespace RestApi.Shared.Rest
{
    public class RestSingleGetRequest<TEntity, TGetModel> : IRequest<TGetModel>
        where TEntity : RestApiEntity
        where TGetModel : IGetModel
    {
        public int Id { get; set; }
    }
}