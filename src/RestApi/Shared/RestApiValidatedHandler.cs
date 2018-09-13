using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace RestApi.Shared
{
    public abstract class RestApiValidatedHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        public RestApiDbContext OpinionatedDbContext { get; }
        public IMapper Mapper { get; }
        public IEnumerable<IValidator<TRequest>> Validators { get; }

        public RestApiValidatedHandler(RestApiDbContext opinionatedDbContext, IMapper mapper, IEnumerable<IValidator<TRequest>> validators)
        {
            OpinionatedDbContext = opinionatedDbContext ?? throw new System.ArgumentNullException(nameof(opinionatedDbContext));
            Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            Validators = validators;
        }
        
        public abstract Task<TResponse> OnHandle(TRequest message, CancellationToken cancellationToken);
        public async Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken)
        {
            //all request validators will run through here first before moving onto the OnHandle request.
            if (Validators == null) return await OnHandle(message, cancellationToken);
            var result = (await Task.WhenAll(Validators
                    .Where(v => v != null)
                    .Select(v => v.ValidateAsync(message))))
                .SelectMany(v => v.Errors);

            if (result.Any())
            {
                throw new ValidationException(result);
            }

            return await OnHandle(message, cancellationToken);
        }
    }
}