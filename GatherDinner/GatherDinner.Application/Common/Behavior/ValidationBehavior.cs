using ErrorOr;
using FluentValidation;
    using FluentValidation.Results;
    using GatherDinner.Application.Authentication.Commands;
    using GatherDinner.Application.Authentication.Common;
    using MediatR;

    namespace GatherDinner.Application.Common.Behavior;

    public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, AuthenticationResult>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<AuthenticationResult> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<AuthenticationResult> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request,cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            
           var errors = validationResult.Errors
               .ConvertAll(ValidationFailure=>Error.Validation(
                ValidationFailure.PropertyName,
                ValidationFailure.ErrorMessage
               ));
            
            return errors;

        }
    }