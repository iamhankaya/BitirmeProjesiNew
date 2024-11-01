using Entities.Concrete;
using Entities.DTOs;
using FluentAssertions;
using FluentValidation;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<UserForRegisterDTO>
    {
        public UserValidator() 
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();

            RuleFor(u => u.Email).MinimumLength(2);
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8);

            RuleFor(u => u.Email).MaximumLength(50);
            RuleFor(u => u.FirstName).MaximumLength(50);
            RuleFor(u => u.LastName).MaximumLength(50);
            RuleFor(u => u.Password).MaximumLength(50);

            RuleFor(u => u.Password)
                .Matches("[A-Z]").WithMessage("Şifre en az bir adet büyük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir adet rakam içermelidir");
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email formatı yanlış");
        }
    }
}
