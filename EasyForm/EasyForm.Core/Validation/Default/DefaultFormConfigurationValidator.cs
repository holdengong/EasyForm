using EasyForm.Core.Configuration;
using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Components;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class DefaultFormConfigurationValidator : IFormConfigurationValidator
    {
        private readonly EasyFormOptions easyFormOptions;

        public DefaultFormConfigurationValidator(EasyFormOptions easyFormOptions)
        {
            this.easyFormOptions = easyFormOptions;
        }

        public async Task ValidateAsync(FormConfigurationValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            await ValidateFormAsync(context);
            if (!context.IsValid) return;

            await ValidateFieldsAsync(context);
            if (!context.IsValid) return;
        }

        protected virtual Task ValidateFormAsync(FormConfigurationValidationContext context)
        {
            var form = context.Form;
            if (form == null)
            {
                context.SetError("form is null");
                return Task.CompletedTask;
            }

            if (form.Id.IsMissing())
            {
                context.SetError("form id is missing");
                return Task.CompletedTask;
            }

            if (form.Fields.IsNullOrEmpty())
            {
                context.SetError("fields is empty");
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        protected async virtual Task ValidateFieldsAsync(FormConfigurationValidationContext context)
        {
            var fields = context.Form.Fields;

            if (fields.Any(_ => _.FieldName.IsMissing()))
            {
                context.SetError("field name is missing");
                return;
            }

            await ValidateCheckBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateDateBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateDateTimeBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateDecimalBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateIntBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateMultiSelectAsync(context);
            if (!context.IsValid) return;

            await ValidateRadioAsync(context);
            if (!context.IsValid) return;

            await ValidateRichTextAsync(context);
            if (!context.IsValid) return;

            await ValidateSelectAsync(context);
            if (!context.IsValid) return;

            await ValidateTextAreaAsync(context);
            if (!context.IsValid) return;

            await ValidateTextBoxAsync(context);
            if (!context.IsValid) return;

            await ValidateTimeAsync(context);
            if (!context.IsValid) return;
        }

        protected virtual Task ValidateTextBoxAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateCheckBoxAsync(FormConfigurationValidationContext context)
        {
            await ValidateOptionsAsync<Checkbox, int>(context);
        }

        protected virtual Task ValidateDateBoxAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateTimeBoxAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDecimalBoxAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateIntBoxAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateMultiSelectAsync(FormConfigurationValidationContext context)
        {
            await ValidateOptionsAsync<MultiSelect, int>(context);
        }

        protected async virtual Task ValidateRadioAsync(FormConfigurationValidationContext context)
        {
            await ValidateOptionsAsync<Radio, int>(context);
        }

        protected virtual Task ValidateRichTextAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateSelectAsync(FormConfigurationValidationContext context)
        {
            await ValidateOptionsAsync<Select, int>(context);
        }

        protected virtual Task ValidateTextAreaAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateTimeAsync(FormConfigurationValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateOptionsAsync<T1, T2>(FormConfigurationValidationContext context)
            where T1 : IComponentHasOptions<T2>
            where T2 : struct
        {
            var fields = context.Form.Fields.Where(_ => _ is T1) as IEnumerable<T1>;
            if (fields.IsNullOrEmpty()) return Task.CompletedTask;

            foreach (var field in fields)
            {
                if (field.Options.IsNullOrEmpty())
                {
                    context.SetError("field has no options");
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
