using FluentValidation;

namespace CustomCRM.Application.Services.Update
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator() 
        {
            RuleFor(s => s.id)
                .NotEmpty().WithMessage("Service type cannot be empty.")
                .NotNull().WithMessage("Service type cannot be null.");

            RuleFor(s => s.serviceType)
                .NotEmpty().WithMessage("Service type cannot be empty.")
                .NotNull().WithMessage("Service type cannot be null.")
                .Must(value => !string.IsNullOrWhiteSpace(value)).WithMessage("Service type cannot be whitespace.")
                .Length(2, 50).WithMessage("Service type must be between 2 and 50 characters.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Service type can only contain letters, numbers, and spaces.");

            RuleFor(s => s.difficult)
                .NotEmpty().WithMessage("Difficult cannot be empty.")
                .NotNull().WithMessage("Difficult cannot be null.")
                .IsInEnum().WithMessage("Difficult must be a valid enum value.");

            RuleFor(s => s.amount)
                .NotEmpty().WithMessage("Amount cannot be empty.")
                .NotNull().WithMessage("Amount cannot be null.")
                .GreaterThan(0).WithMessage("Amount must be greater than zero.")
                .LessThanOrEqualTo(1000000).WithMessage("Amount must be less than or equal to 1,000,000.");

            RuleFor(s => s.currency)
                .NotEmpty().WithMessage("Currency cannot be empty.")
                .NotNull().WithMessage("Currency cannot be null.")
                .IsInEnum().WithMessage("Currency must be a valid enum value.");

            RuleFor(s => s.quantity)
                .NotEmpty().WithMessage("Quantity cannot be empty.")
                .NotNull().WithMessage("Quantity cannot be null.")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(100).WithMessage("Quantity must be less than or equal to 100.");

            RuleFor(s => s.comment)
                .MaximumLength(500).WithMessage("Comment must be 500 characters or less.");
        }
    }
}
