using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using RestApi.Shared.Gets;

namespace RestApi.Shared.Rest
{
    public class RestPostHandler<TEntity, TPostModel, TGetModel> : RestApiValidatedHandler<RestPostRequest<TEntity, TPostModel, TGetModel>, TGetModel>
        where TEntity : RestApiEntity
        where TGetModel : IGetModel
    {
        public RestPostHandler(RestApiDbContext opinionatedDbContext, IMapper mapper, IEnumerable<IValidator<RestPostRequest<TEntity, TPostModel, TGetModel>>> validators) 
            : base(opinionatedDbContext, mapper, validators)
        {
        }

        public override async Task<TGetModel> OnHandle(RestPostRequest<TEntity, TPostModel, TGetModel> message, CancellationToken cancellationToken)
        {
            var newEntity = Mapper.Map<TEntity>(message.NewEntity);
            OpinionatedDbContext.Add(newEntity);
            await OpinionatedDbContext.SaveChangesAsync(cancellationToken);
            return Mapper.Map<TGetModel>(newEntity);
        }
    }
}