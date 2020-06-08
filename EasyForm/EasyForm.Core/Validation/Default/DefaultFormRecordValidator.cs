using EasyForm.Core.Configuration;
using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class DefaultFormRecordValidator : IFormRecordValidator
    {
        private readonly EasyFormOptions _easyFormOptions;
        private readonly IFieldRecordUniqueValidator _fieldRecordUniqueValidator;

        public DefaultFormRecordValidator(EasyFormOptions easyFormOptions, IFieldRecordUniqueValidator fieldRecordUniqueValidator)
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

            if (context.FormDefinition == null)
            {
                throw new ArgumentNullException(nameof(context.FormDefinition));
            }

            if (context.FormRecord == null)
            {
                throw new ArgumentNullException(nameof(context.FormRecord));
            }

            await ValidateFormRecordsAsync(context);
            if (!context.IsValid) return;

            await ValidateFieldRecordsAsync(context);
            if (!context.IsValid) return;
        }

        protected virtual Task ValidateFormRecordsAsync(FormRecordValidationContext context)
        {
            var formRecord = context.FormRecord;
            if (formRecord == null)
            {
                context.SetError("form record is null");
                return Task.CompletedTask;
            }

            if (formRecord.FormDefinitionId.IsMissing())
            {
                context.SetError("form definition id is missing");
                return Task.CompletedTask;
            }

            if (formRecord.FieldValues.IsNullOrEmpty())
            {
                context.SetError("form field records is null or empty");
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        protected async virtual Task ValidateFieldRecordsAsync(FormRecordValidationContext context)
        {
            var fieldRecords = context.FormRecord.FieldValues;

            if (fieldRecords.IsNullOrEmpty())
            {
                context.SetError("field records is null or empty");
            }

            if (fieldRecords.Any(_ => _.FieldDefinition == null))
            {
                context.SetError("field definition is null");
            }

            if (fieldRecords.Any(_ => _.FieldDefinition.FieldName.IsMissing()))
            {
                context.SetError("field name is null");
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

        protected async virtual Task ValidateTextBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is TextboxFieldValue).Select(_ => _ as TextboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TextboxFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsMissing())
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (fieldDefinition.IsUnique && record.Value.IsPresent())
                {
                    var fieldRecordValidationContext = new FieldRecordUniqueValidationContext(context.FormDefinition.FormId, record);
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

        protected virtual Task ValidateCheckBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is CheckboxFieldValue).Select(_ => _ as CheckboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CheckboxFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is DateFieldValue).Select(_ => _ as DateFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DateFieldDefinition;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDateTimeBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is DateTimeFieldValue).Select(_ => _ as DateTimeFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DateTimeFieldDefinition;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateDecimalBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is DecimalFieldValue).Select(_ => _ as DecimalFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as DecimalFieldDefinition;

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

        protected async virtual Task ValidateIntBoxAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is IntFieldValue).Select(_ => _ as IntFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as IntFieldDefinition;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }

                if (fieldDefinition.IsUnique && record.Value.HasValue)
                {
                    var fieldRecordValidationContext = new FieldRecordUniqueValidationContext(context.FormDefinition.FormId, record);
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

        protected virtual Task ValidateMultiSelectAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is MultiSelectFieldValue).Select(_ => _ as MultiSelectFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as MultiSelectFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateRadioAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is CheckboxFieldValue).Select(_ => _ as CheckboxFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CheckboxFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateRichTextAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is RichTextFieldValue).Select(_ => _ as RichTextFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as RichTextFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSelectAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is SelectFieldValue).Select(_ => _ as SelectFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SelectFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateTextAreaAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is TextAreaFieldValue).Select(_ => _ as SelectFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TextAreaFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateTimeAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is TimeFieldValue).Select(_ => _ as TimeFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as TimeFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateCascaderAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is CascaderFieldValue).Select(_ => _ as CascaderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as CascaderFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateColorPickerAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is ColorPickerFieldValue).Select(_ => _ as ColorPickerFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as ColorPickerFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSliderAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is SliderFieldValue).Select(_ => _ as SliderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SliderFieldDefinition;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateSwitchAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is SwitchFieldValue).Select(_ => _ as SwitchFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as SwitchFieldDefinition;

                if (fieldDefinition.IsRequired && !record.Value.HasValue)
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }

        protected virtual Task ValidateUploadAsync(FormRecordValidationContext context)
        {
            var records = context.FormRecord.FieldValues.Where(_ => _ is UploaderFieldValue).Select(_ => _ as UploaderFieldValue);

            foreach (var record in records)
            {
                var fieldDefinition = record.FieldDefinition as UploaderFieldDefinition;

                if (fieldDefinition.IsRequired && record.Value.IsNullOrEmpty())
                {
                    context.AddRecordError(record, "required validation failure");
                }
            }

            return Task.CompletedTask;
        }
    }
}
