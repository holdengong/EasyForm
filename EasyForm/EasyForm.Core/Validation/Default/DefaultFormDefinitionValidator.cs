using EasyForm.Core.Configuration;
using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class DefaultFormDefinitionValidator : IFormValidator
    {
        private readonly EasyFormOptions _easyFormOptions;

        public DefaultFormDefinitionValidator(EasyFormOptions easyFormOptions)
        {
            _easyFormOptions = easyFormOptions;
        }

        public async Task ValidateAsync(FormValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            await ValidateFormDefinitionAsync(context);
            if (!context.IsValid) return;

            await ValidateFieldsAsync(context);
            if (!context.IsValid) return;
        }

        protected virtual Task ValidateFormDefinitionAsync(FormValidationContext context)
        {
            var form = context.FormDefinition;
            if (form == null)
            {
                context.SetError("form is null");
                return Task.CompletedTask;
            }

            if (form.Key.IsMissing())
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

        protected async virtual Task ValidateFieldsAsync(FormValidationContext context)
        {
            var fields = context.FormDefinition.Fields;

            if (fields.Any(_ => _.FieldName.IsMissing()))
            {
                context.SetError("field name is missing");
                return;
            }

            if (fields.HasDuplicates(_ => _.FieldName))
            {
                context.SetError("field name has duplicates");
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

            await ValidateCascaderAsync(context);
            if (!context.IsValid) return;

            await ValidateColorPickerAsync(context);
            if (!context.IsValid) return;

            await ValidateSliderAsync(context);
            if (!context.IsValid) return;

            await ValidateSwitchAsync(context);
            if (!context.IsValid) return;

            await ValidateUploadAsync(context);
            if (!context.IsValid) return;
        }

        protected virtual Task ValidateTextBoxAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateCheckBoxAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<CheckboxField>(context);
        }

        protected virtual Task ValidateDateBoxAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateTimeBoxAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDecimalBoxAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateIntBoxAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateMultiSelectAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<MultiSelectField>(context);
        }

        protected async virtual Task ValidateRadioAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<RadioField>(context);
        }

        protected virtual Task ValidateRichTextAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateSelectAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<SelectField>(context);
        }

        protected virtual Task ValidateTextAreaAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateTimeAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateCascaderAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<CascaderField>(context);
        }

        protected virtual Task ValidateColorPickerAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateSliderAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateSwitchAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateUploadAsync(FormValidationContext context)
        {
            var uploads = context.FormDefinition.Fields.Where(_ => _ is UploaderField)?.Select(_ => _ as UploaderField);
            if (uploads.IsNullOrEmpty()) return Task.CompletedTask;

            foreach (var upload in uploads)
            {
                if (upload.AllowFileTypes.IsNullOrEmpty())
                {
                    context.SetError("allow file types is empty");
                    return Task.CompletedTask;
                }

                if (upload.IsMultiple && upload.CountLimit <= 0)
                {
                    context.SetError("is multiple set true, but count limit is 0 or negative");
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateOptionsAsync<TFieldType>(FormValidationContext context)
            where TFieldType : class, IHasOptions,new()
        {
            var fields = context.FormDefinition.Fields.Where(_ => _ is TFieldType)
                ?.Select(_ => _ as TFieldType);

            if (fields.IsNullOrEmpty()) return Task.CompletedTask;

            foreach (var field in fields)
            {
                if (field.Options.IsNullOrEmpty())
                {
                    if (field.OptionsFunc==null)
                    {
                        context.SetError("field options func is required if options is numm or empty.");
                        return Task.CompletedTask;
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
