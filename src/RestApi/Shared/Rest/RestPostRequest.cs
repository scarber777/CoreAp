using MediatR;

namespace RestApi.Shared.Rest
{
    public class RestPostRequest<TEntity, TPostModel, TGetModel> : IRequest<TGetModel>
        where TEntity : RestApiEntity
    {
        public TPostModel NewEntity { get; set; }
    }
}