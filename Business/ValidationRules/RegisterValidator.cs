using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using FluentValidation;

namespace Business.ValidationRules
{
    public class RegisterValidator : AbstractValidator<User>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adı boş olamaz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail boş olamaz");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("şifre boş olamaz");
            RuleFor(x => x.UserPassword).MinimumLength(5).WithMessage("şifre en az 5 karakter olmalıdır");
        }
    }
}
