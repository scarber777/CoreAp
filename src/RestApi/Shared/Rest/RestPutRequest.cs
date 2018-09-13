using System.Collections.Generic;
using MediatR;
using RestApi.Shared.Gets;

namespace RestApi.Shared.Rest
{
    public class RestPutRequest<TEntity, TGetModel> : IRequest<TGetModel>
        where TEntity : RestApiEntity
        where TGetModel : IGetModel
    {
        public int Id { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}