using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori İsmi Boş Geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Kategori İsmi En Az 5 Karakter Olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori İsmi En Fazla 50 Karakter Olmalıdır.");
        }
    }
}
