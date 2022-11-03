using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar İsmi Boş Geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Yazar İsmi En Az 2 Karakter Olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Yazar İsmi En Fazla 50 Karakter Olmalıdır.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz.");
        }
    }
}
