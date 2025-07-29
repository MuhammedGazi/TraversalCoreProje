using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz");
        }
    }
}
