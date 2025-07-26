using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncemenUpdateValidator:AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncemenUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Alanı Boş Bırakılamaz");
        }
    }
}
