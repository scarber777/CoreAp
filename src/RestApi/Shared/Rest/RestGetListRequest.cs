using MediatR;
using RestApi.Shared.Gets;

namespace RestApi.Shared.Rest
{
    public class RestGetListRequest<TEntity, TGetModel> : IRequest<object>
        where TEntity : RestApiEntity
        where TGetModel : IGetModel
    {
        public int PageNumber { get; set; }
        public int NumberOfRecords { get; set; }
        public bool UsePaging { get; set; }
    }
}