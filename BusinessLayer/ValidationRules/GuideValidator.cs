using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber isim Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber Açıklama Boş Bırakılamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Rehber Görsel Boş Bırakılamaz");
        }
    }
}
