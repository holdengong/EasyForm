using EasyForm.Core.Configuration;
using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Models.Forms.Base;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class DefaultFormRecordValidator : IRecordValidator
    {
        private readonly EasyFormOptions _easyFormOptions;
        private readonly IUniqueValueValidator _fieldRecordUniqueValidator;

        public DefaultFormRecordValidator(EasyFormOptions easyFormOptions, IUniqueValueValidator fieldRecordUniqueValidator)
        {
            _easyFormOptions = easyFormOptions;
            _fieldRecordUniqueValidator = fieldRecordUniqueValidator;
        }

        public async Task ValidateAsync(FormRecordValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var formRecord = context.FormRecord;

            if (formRecord == null)
            {
                throw new ArgumentNullException(nameof(formRecord));
            }

            if (formRecord.FormKey.IsMissing())
            {
                throw new ArgumentNullException(nameof(formRecord.FormKey));
            }

            if (formRecord.Values.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(formRecord.Values));
            }

            var fieldValues = formRecord.Values;

            if (fieldValues.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(context.FormRecord.Values));
            }

            if (fieldValues.Any(_ => _.FieldDefinition == null))
            {
                throw new ArgumentNullException("field definition");
            }

            if (fieldValues.Any(_ => _.FieldDefinition.FieldName.IsMissing()))
            {
                throw new ArgumentNullException("field name");
            }

            await ValidateFieldValuesAsync(context);
            if (!context.IsValid) return;
        }

        protected async virtual Task ValidateFieldValuesAsync(FormRecordValidationContext context)
        {
            await ValidateCheckboxFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateDateFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateDateTimeFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateDecimalFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateIntFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateMultiSelectFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateRadioFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateRichTextFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateSelectFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateTextAreaFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateTextboxFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateTimeFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateCascaderFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateColorPickerFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateSliderFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateSwitchFieldValueAsync(context);
            if (!context.IsValid) return;

            await ValidateUploadFieldValueAsync(context);
            if (!context.IsValid) return;
        }

        protected async virtual Task ValidateTextboxFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is TextboxFieldValue).Select(_ => _ as TextboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TextboxField;

                if (fieldDefinition.IsRequired && record.Value.IsMissing())
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (fieldDefinition.IsUnique && record.Value.IsPresent())
                {
                    var fieldRecordValidationContext = new UniqueValueValidationContext(context.FormId, record);
                    await _fieldRecordUniqueValidator.ValidateAsync(fieldRecordValidationContext);
                    if (!fieldRecordValidationContext.IsValid)
                    {
                        context.AddRecordError(record, fieldRecordValidationContext.ErrorMessage);
                    }
                }

                if (record.Value.IsTooLong(fieldDefinition.MaxLength))
                {
                    context.AddRecordError(record, "max length validation failure");
                }
            }
        }

        protected virtual Task ValidateCheckboxFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is CheckboxFieldValue).Select(_ => _ as CheckboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CheckboxField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is DateFieldValue).Select(_ => _ as DateFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DateField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateTimeFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is DateTimeFieldValue).Select(_ => _ as DateTimeFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DateTimeField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDecimalFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is DecimalFieldValue).Select(_ => _ as DecimalFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DecimalField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (record.Value.IsOutOfRange(fieldDefinition.Min, fieldDefinition.Max))
                {
                    context.AddRecordError(record, "range validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected async virtual Task ValidateIntFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is IntFieldValue).Select(_ => _ as IntFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as IntField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (fieldDefinition.IsUnique && record.Value.HasValue)
                {
                    var fieldRecordValidationContext = new UniqueValueValidationContext(context.FormId, record);
                    await _fieldRecordUniqueValidator.ValidateAsync(fieldRecordValidationContext);
                    if (!fieldRecordValidationContext.IsValid)
                    {
                        context.AddRecordError(record, fieldRecordValidationContext.ErrorMessage);
                    }
                }

                if (record.Value.IsOutOfRange(fieldDefinition.Min, fieldDefinition.Max))
                {
                    context.AddRecordError(record, "range validation failure");
                }
            }
        }

        protected virtual Task ValidateMultiSelectFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is MultiSelectFieldValue).Select(_ => _ as MultiSelectFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as MultiSelectField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateRadioFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is CheckboxFieldValue).Select(_ => _ as CheckboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CheckboxField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateRichTextFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is RichTextFieldValue).Select(_ => _ as RichTextFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as RichTextField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSelectFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is SelectFieldValue).Select(_ => _ as SelectFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SelectField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateTextAreaFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is TextAreaFieldValue).Select(_ => _ as TextAreaFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TextAreaField;

                if (fieldDefinition.IsRequired && record.Value.IsMissing())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateTimeFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is TimeFieldValue).Select(_ => _ as TimeFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TimeField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateCascaderFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is CascaderFieldValue).Select(_ => _ as CascaderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CascaderField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateColorPickerFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is ColorPickerFieldValue).Select(_ => _ as ColorPickerFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as ColorPickerField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSliderFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is SliderFieldValue).Select(_ => _ as SliderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SliderField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (record.Value.IsOutOfRange(fieldDefinition.Min, fieldDefinition.Max))
                {
                    context.AddRecordError(record, "range validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSwitchFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is SwitchFieldValue).Select(_ => _ as SwitchFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SwitchField;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateUploadFieldValueAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.Values.Where(_ => _ is UploaderFieldValue).Select(_ => _ as UploaderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as UploaderField;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }
    }
}
