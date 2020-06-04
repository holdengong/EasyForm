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
    public class DefaultFormValidator : IFormValidator
    {
        private readonly EasyFormOptions easyFormOptions;

        public DefaultFormValidator(EasyFormOptions easyFormOptions)
        {
            this.easyFormOptions = easyFormOptions;
        }

        public async Task ValidateAsync(FormValidationContext context)
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

        protected virtual Task ValidateFormAsync(FormValidationContext context)
        {
            var form = context.Form;
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

        protected async virtual Task ValidateFieldsAsync(FormValidationContext context)
        {
            var fields = context.Form.Fields;

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
            await ValidateOptionsAsync<Checkbox, int,Option<int>>(context);
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
            await ValidateOptionsAsync<MultiSelect, int, Option<int>>(context);
        }

        protected async virtual Task ValidateRadioAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<Radio, int,Option<int>>(context);
        }

        protected virtual Task ValidateRichTextAsync(FormValidationContext context)
        {
            return Task.CompletedTask;
        }

        protected async virtual Task ValidateSelectAsync(FormValidationContext context)
        {
            await ValidateOptionsAsync<Select, int,Option<int>>(context);
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
            await ValidateOptionsAsync<Cascader, int, OptionWithChild<int>>(context);
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
            var uploads = context.Form.Fields.Where(_ => _ is Uploader)?.Select(_ => _ as Uploader);
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

        protected virtual Task ValidateOptionsAsync<TComponentType, TOptionValueType,TOptionType>(FormValidationContext context)
            where TComponentType : class,IComponentHasOptions<TOptionValueType,TOptionType>,new()
            where TOptionValueType : struct
            where TOptionType : Option<TOptionValueType>
        {
            var fields = context.Form.Fields.Where(_ => _ is TComponentType)
                ?.Select(_ => _ as TComponentType);

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
