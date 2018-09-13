using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApi.Shared.Errors;
using RestApi.Shared.Rest;

namespace RestApi.Shared
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class RestApiController : Controller, IUrlHelperProvider
    {
        public RestApiDbContext OpinionatedDbContext { get; }
        public IMapper Mapper { get; }
        public IMediator Mediator { get; }

        protected RestApiController(RestApiDbContext opinionatedDbContext, IMapper mapper, IMediator mediator) {
            OpinionatedDbContext = opinionatedDbContext;
            Mapper = mapper;
            Mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequestAsync<TReturn>(IRequest<TReturn> request)
        {
            if (request == null)
            {
                var error = new ErrorResponse
                {
                    Error = new Error
                    {
                        Message = "A bad request was received.",
                        Details = new[] { 
                            new ErrorDetail
                            {
                                Message = "The body of the request contained no usable content."
                            }
                        }
                    }
                };
                return BadRequest(error);
            }
            
            try
            {
                var response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                var error = new ErrorResponse
                {
                    Error = new Error
                    {
                        Message = "A bad request was received.",
                        Details = ex.Errors.Select(e => new ErrorDetail
                        {
                            Message = e.ErrorMessage,
                            Target = e.PropertyName
                        }).ToArray()
                    }
                };
                return BadRequest(error);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}