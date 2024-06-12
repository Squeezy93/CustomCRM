using FluentValidation;

namespace CustomCRM.Application.Services.Create
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator() 
        {
            RuleFor(s => s.serviceType)
                .NotNull()
                .NotEmpty().WithMessage("Service type is required")
                .MaximumLength(300);

            RuleFor(s => s.difficult)
                .IsInEnum().WithMessage("Difficult must be a valid enum value.");

            RuleFor(s => s.status)
                .IsInEnum().WithMessage("Status must be a valid enum value.");

            RuleFor(s => s.amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(s => s.quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(s => s.comment)
                .MaximumLength(500).WithMessage("Comment must be 500 characters or less.");
        }
    }
}
