using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace RestApi.Shared
{
    public abstract class RestApiValidator<TRequest> : AbstractValidator<TRequest>
    {
        public RestApiDbContext OpinionatedDbContext { get; }
        
        public RestApiValidator(RestApiDbContext opinionatedDbContext)
        {
            OpinionatedDbContext = opinionatedDbContext;
        }

        protected async Task<bool> ExistAsync<TEntity>(int id, CancellationToken cancellationToken)
            where TEntity : class
        {
            return (await OpinionatedDbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken)) != null;
        }
    }
}