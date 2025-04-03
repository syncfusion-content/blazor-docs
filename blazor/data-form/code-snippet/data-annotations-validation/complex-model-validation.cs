public class PaymentDetailsValidator : AbstractValidator<PaymentDetails>
{
    public PaymentDetailsValidator()
    {
        RuleFor(customer => customer.Name).NotEmpty().MinimumLength(3).WithMessage("Name should greater than 3 characters ").MaximumLength(50).WithMessage("Name should not contains more than 50 characters");
        RuleFor(customer => customer.CardNumber).NotEmpty().WithMessage("Please enter credit card number").CreditCard().WithMessage("Entered number is not a valid credit card number.");
        RuleFor(customer => customer.ExpirationDate).NotEmpty().WithMessage("Please enter expiration date");
        RuleFor(customer => customer.CVV).NotEmpty().Length(3);
        RuleFor(customer => customer.BillingAddress).NotEmpty().WithMessage("Please specify a billing address");
        RuleFor(customer => customer.Accept).Equal(true).WithMessage("You must accept the terms and conditions to proceed further");
    }
}