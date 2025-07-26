using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Bırakılamaz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Bırakılamaz");
            RuleFor(x => x.ConfirmPassword).Equal(y=>y.ConfirmPassword).WithMessage("Şifreler Birbiriyle Uyuşmuyor");

        }
    }
}
