using EasyForm.Core.Interfaces;
using EasyForm.Core.Validation.Contexts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EasyForm.Core.Stores
{
    public class ValidatingFormStore<T> : IFormStore
        where T : IFormStore
    {
        private readonly IFormStore _inner;
        private readonly IFormConfigurationValidator _validator;
        private readonly ILogger<ValidatingFormStore<T>> _logger;
        private readonly string _validatorType;

        public ValidatingFormStore(T inner, IFormConfigurationValidator validator, ILogger<ValidatingFormStore<T>> logger)
        {
            _inner = inner;
            _validator = validator;
            _logger = logger;

            _validatorType = validator.GetType().FullName;
        }

        public async Task<Form> FindFormByFormIdAsync(string formId)
        {
            var form = await _inner.FindFormByFormIdAsync(formId);

            if (form != null)
            {
                _logger.LogTrace("Calling into form configuration validator: {validatorType}", _validatorType);

                var context = new FormConfigurationValidationContext(form);
                await _validator.ValidateAsync(context);

                if (context.IsValid)
                {
                    _logger.LogDebug("client configuration validation for client {id} succeeded.", form.FormId);
                    return form;
                }
                else
                {
                    _logger.LogError("Invalid form configuration for form {clientId}: {errorMessage}", form.FormId, context.ErrorMessage);
                    return null;
                }
            }

            return null;
        }
    }
}