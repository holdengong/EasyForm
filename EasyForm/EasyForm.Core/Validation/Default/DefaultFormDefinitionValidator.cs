using EasyForm.Core.Configuration;
using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class DefaultFormDefinitionValidator : IFormDefinitionValidator
    {
        private readonly EasyFormOptions _easyFormOptions;

        public DefaultFormDefinitionValidator(EasyFormOptions easyFormOptions)
        {
            _easyFormOptions = easyFormOptions;
        }

        public async Task ValidateAsync(FormDefinitionValidationContext context)
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

        protected virtual Task ValidateFormDefinitionAsync(FormDefinitionValidationContext context)
        {
            var form = context.FormDefinition;
            if (form == null)
            {
                context.SetError("form is null");
                return Task.CompletedTask;
            }

            if (form.FormId.IsMissing())
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

        protected async virtual Task ValidateFieldsAsync(FormDefinitionValidationContext context)
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

        protected virtual Task ValidateTextBoxAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateCheckBoxAsync(FormDefinitionValidationContext context)
        {
            await ValidateOptionsAsync<CheckboxFieldDefinition>(context);
        }

        protected virtual Task ValidateDateBoxAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateTimeBoxAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateDecimalBoxAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateIntBoxAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateMultiSelectAsync(FormDefinitionValidationContext context)
        {
            await ValidateOptionsAsync<MultiSelectFieldDefinition>(context);
        }

        protected async virtual Task ValidateRadioAsync(FormDefinitionValidationContext context)
        {
            await ValidateOptionsAsync<RadioFieldDefinition>(context);
        }

        protected virtual Task ValidateRichTextAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateSelectAsync(FormDefinitionValidationContext context)
        {
            await ValidateOptionsAsync<SelectFieldDefinition>(context);
        }

        protected virtual Task ValidateTextAreaAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateTimeAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateCascaderAsync(FormDefinitionValidationContext context)
        {
            await ValidateOptionsAsync<CascaderFieldDefinition>(context);
        }

        protected virtual Task ValidateColorPickerAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateSliderAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateSwitchAsync(FormDefinitionValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateUploadAsync(FormDefinitionValidationContext context)
        {
            var uploads = context.FormDefinition.Fields.Where(_ => _ is UploaderFieldDefinition)?.Select(_ => _ as UploaderFieldDefinition);
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

        protected virtual Task ValidateOptionsAsync<TFieldType>(FormDefinitionValidationContext context)
            where TFieldType : class, IFieldHasOptions,new()
        {
            var fields = context.FormDefinition.Fields.Where(_ => _ is TFieldType)
                ?.Select(_ => _ as TFieldType);

            if (fields.IsNullOrEmpty()) return Task.CompletedTask;

            foreach (var field in fields)
            {
                if (field.Options.IsNullOrEmpty())
                {
                    if (field.FieldOptionsName.IsMissing())
                    {
                        context.SetError("field options name is required if options is numm or empty.");
                        return Task.CompletedTask;
                    }
                    if (field.FieldOptionsStore == null)
                    {
                        context.SetError("field options store is required if options is numm or empty.");
                        return Task.CompletedTask;
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
