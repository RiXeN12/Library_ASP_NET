using FluentValidation;
using Library_NPR321.Models;

namespace Library_NPR321.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator() 
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("Ім'я обов'зкове")
                .MaximumLength(100).WithMessage("Максимальна к-сть символів дорівнює 100");
            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("Прізвище обов'зкове")
                .MaximumLength(100).WithMessage("Максимальна к-сть символів дорівнює 100");
            RuleFor(a => a.Birthday)
                .LessThan(DateTime.Now.Date).WithMessage("Не вірно вказано дату")
                .NotEmpty().WithMessage("Вкажіть дату");
        }
    }
}
