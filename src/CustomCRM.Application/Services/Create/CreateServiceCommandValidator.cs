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
                .MaximumLength(300).WithMessage("Service type must be 300 characters or less.");

            RuleFor(s => s.difficult)
                .IsInEnum().WithMessage("Difficult must be a valid enum value.");            

            RuleFor(s => s.amount)
                .NotEmpty()                
                .NotNull().WithMessage("Amount is required")
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(s => s.currency)
                .IsInEnum().WithMessage("Currency must be a valid enum value.");                

            RuleFor(s => s.quantity)
                .NotEmpty()
                .NotNull().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(s => s.comment)
                .MaximumLength(500).WithMessage("Comment must be 500 characters or less.");                
        }
    }
}
