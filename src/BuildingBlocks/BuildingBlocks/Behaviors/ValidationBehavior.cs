using BuildingBlocks.CQRS.Commands;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validating command {CommandName} with {CommandType}", request.GetType().Name, typeof(TRequest).Name);

        var context = new ValidationContext<TRequest>(request);
        ValidationFailure[] failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f is not null)
            .ToArray();

        if (failures.Length > 0)
        {
            _logger.LogWarning("Command {CommandName} with {CommandType} has validation errors: {@ValidationErrors}", request.GetType().Name, typeof(TRequest).Name, failures);
            throw new ValidationException(failures);
        }

        return next();
    }
}