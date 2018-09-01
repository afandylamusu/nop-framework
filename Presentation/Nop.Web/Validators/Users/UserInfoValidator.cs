using System;
using FluentValidation;
using FluentValidation.Results;
using Nop.Core;
using Nop.Domain.Users;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.Customer;
using Nop.Web.Models.Users;

namespace Nop.Web.Validators.Users
{
    public partial class UserInfoValidator : BaseNopValidator<UserInfoModel>
    {
        public UserInfoValidator(
            ILocalizationService localizationService, 
            UserSettings userSettings)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.FirstName.Required"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.LastName.Required"));

            if (userSettings.UsernamesEnabled && userSettings.AllowUsersToChangeUsernames)
            {
                RuleFor(x => x.Username).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Username.Required"));
            }

            //form fields
            if (userSettings.CountryEnabled && userSettings.CountryRequired)
            {
                RuleFor(x => x.CountryId)
                    .NotEqual(0)
                    .WithMessage(localizationService.GetResource("Account.Fields.Country.Required"));
            }

            When(x => userSettings.DateOfBirthEnabled && userSettings.DateOfBirthRequired, () => {
                RuleFor(x => x.DateOfBirthDay).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.DateOfBirth.Required"));

                When(x => userSettings.DateOfBirthMinimumAge.HasValue, () =>
                {
                    RuleFor(x => x.DateOfBirthDay).Must((model, x) =>
                    {
                        return userSettings.DateOfBirthMinimumAge.HasValue && CommonHelper.GetDifferenceInYears(model.ParseDateOfBirth().Value, DateTime.Today) < userSettings.DateOfBirthMinimumAge.Value;
                    })
                    .WithMessage(string.Format(localizationService.GetResource("Account.Fields.DateOfBirth.MinimumAge"), userSettings.DateOfBirthMinimumAge.Value));
                });
            });

            if (userSettings.CompanyRequired && userSettings.CompanyEnabled)
            {
                RuleFor(x => x.Company).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Company.Required"));
            }
            if (userSettings.StreetAddressRequired && userSettings.StreetAddressEnabled)
            {
                RuleFor(x => x.StreetAddress).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.StreetAddress.Required"));
            }
            if (userSettings.StreetAddress2Required && userSettings.StreetAddress2Enabled)
            {
                RuleFor(x => x.StreetAddress2).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.StreetAddress2.Required"));
            }
            if (userSettings.ZipPostalCodeRequired && userSettings.ZipPostalCodeEnabled)
            {
                RuleFor(x => x.ZipPostalCode).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.ZipPostalCode.Required"));
            }
            if (userSettings.CityRequired && userSettings.CityEnabled)
            {
                RuleFor(x => x.City).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.City.Required"));
            }
            if (userSettings.PhoneRequired && userSettings.PhoneEnabled)
            {
                RuleFor(x => x.Phone).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Phone.Required"));
            }
            if (userSettings.FaxRequired && userSettings.FaxEnabled)
            {
                RuleFor(x => x.Fax).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Fax.Required"));
            }
        }
    }
}