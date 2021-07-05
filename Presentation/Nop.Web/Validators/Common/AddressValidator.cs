using System.Linq;
using FluentValidation;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.Common;

namespace Nop.Web.Validators.Common
{
    public partial class AddressValidator : BaseNopValidator<AddressModel>
    {
        public AddressValidator(ILocalizationService localizationService,
            IStateProvinceService stateProvinceService,
            IDistrictService districtService,
            AddressSettings addressSettings,
            CustomerSettings customerSettings)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.FirstName.Required"));
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.LastName.Required"));
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.Email.Required"));
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
            ////////////////////
            if (addressSettings.CountryEnabled)
            {
                RuleFor(x => x.CountryId)
                    .NotNull()
                    .WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.Country.Required"));
                RuleFor(x => x.CountryId)
                    .NotEqual(0)
                    .WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.Country.Required"));
            }
            if (addressSettings.CountryEnabled && addressSettings.StateProvinceEnabled)
            {
                RuleFor(x => x.StateProvinceId).MustAwait(async (x, context) =>
                {
                    //does selected country has states?
                    var countryId = x.CountryId ?? 0;
                    var hasStates = (await stateProvinceService.GetStateProvincesByCountryIdAsync(countryId)).Any();

                    if (hasStates)
                    {
                        //if yes, then ensure that state is selected
                        if (!x.StateProvinceId.HasValue || x.StateProvinceId.Value == 0)
                            return false;
                    }

                    return true;
                }).WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.StateProvince.Required"));
            }
            /////////
            if (addressSettings.CityEnabled)
            {
                RuleFor(x => x.CityId)
                    .NotNull()
                    .WithMessage("City required");
                RuleFor(x => x.CityId)
                    .NotEqual(0)
                    .WithMessage("City Required");
            }
            if (addressSettings.CityEnabled && addressSettings.DistrictEnabled)
            {
                RuleFor(x => x.DistrictId).MustAwait(async (x, context) =>
                {
                    //does selected city has districts?
                    var cityId = x.CityId ?? 0;
                    var hasDistricts = (await districtService.GetDistrictsByCityIdAsync(cityId)).Any();

                    if (hasDistricts)
                    {
                        //if yes, then ensure that district is selected
                        if (!x.DistrictId.HasValue || x.DistrictId.Value == 0)
                            return false;
                    }

                    return true;
                }).WithMessage("District Required");
            }
            /////////
            if (addressSettings.CompanyRequired && addressSettings.CompanyEnabled)
            {
                RuleFor(x => x.Company).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.Company.Required"));
            }
            if (addressSettings.StreetAddressRequired && addressSettings.StreetAddressEnabled)
            {
                RuleFor(x => x.Address1).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.StreetAddress.Required"));
            }
            if (addressSettings.StreetAddress2Required && addressSettings.StreetAddress2Enabled)
            {
                RuleFor(x => x.Address2).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.StreetAddress2.Required"));
            }
            if (addressSettings.ZipPostalCodeRequired && addressSettings.ZipPostalCodeEnabled)
            {
                RuleFor(x => x.ZipPostalCode).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.ZipPostalCode.Required"));
            }
            if (addressSettings.CountyEnabled && addressSettings.CountyRequired)
            {
                RuleFor(x => x.County).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Address.Fields.County.Required"));
            }

            if (addressSettings.PhoneRequired && addressSettings.PhoneEnabled)
            {
                RuleFor(x => x.PhoneNumber).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.Phone.Required"));
            }
            if (addressSettings.PhoneEnabled)
            {
                RuleFor(x => x.PhoneNumber).IsPhoneNumber(customerSettings).WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.Phone.NotValid"));
            }
            if (addressSettings.FaxRequired && addressSettings.FaxEnabled)
            {
                RuleFor(x => x.FaxNumber).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.Fields.Fax.Required"));
            }
        }
    }
}