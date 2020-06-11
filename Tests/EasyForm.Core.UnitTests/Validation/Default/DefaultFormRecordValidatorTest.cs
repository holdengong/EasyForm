using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using EasyForm.Core.Validation.Contexts;
using EasyForm.Core.Validation.Default;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EasyForm.UnitTests.Validation.Default
{
    public class DefaultFormRecordValidatorTest
    {
        private readonly IFormRecordValidator validator;
        private readonly IUniqueValueValidator fieldRecordUniqueValidator;
        private readonly EasyFormOptions options;
        public DefaultFormRecordValidatorTest()
        {
            options = new EasyFormOptions();
            fieldRecordUniqueValidator = new NoOpUniqueValueValidator();
            validator = new DefaultFormRecordValidator(options, fieldRecordUniqueValidator);
        }

        [Fact]
        public async Task Validate_should_success()
        {
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, TestData.FormRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Context_is_null_should_throw()
        {
            FormRecordValidationContext context = null;
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Form_record_is_null_should_throw()
        {
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, null);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Form_definition_id_is_missiing_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FormDefinitionId = null;
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Field_values_is_null_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FieldValues = null;
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Field_values_is_empty_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FieldValues = new List<FieldValue>();
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Any_field_definition_is_null_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FieldValues.First().FieldDefinition = null;
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Any_field_name_is_null_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FieldValues.First().FieldDefinition.FieldName = null;
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Any_field_name_is_empty_should_throw()
        {
            var formRecord = TestData.FormRecord;
            formRecord.FieldValues.First().FieldDefinition.FieldName = string.Empty;
            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId,formRecord);
            Func<Task> func = async () => await validator.ValidateAsync(context);
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Checkbox_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is CheckboxFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is CheckboxFieldValue) as CheckboxFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Checkbox_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is CheckboxFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is CheckboxFieldValue) as CheckboxFieldValue).Value = new List<int>();

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Date_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is DateFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is DateFieldValue) as DateFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task DateTime_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is DateTimeFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is DateTimeFieldValue) as DateTimeFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Decimal_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is DecimalFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is DecimalFieldValue) as DecimalFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Decimal_field_value_less_than_min_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is DecimalFieldValue).FieldDefinition as DecimalFieldDefinition).Min = 1.0M;

            (formRecord.FieldValues.First(_ => _ is DecimalFieldValue) as DecimalFieldValue).Value = 0.9M;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Decimal_field_value_greater_than_max_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is DecimalFieldValue).FieldDefinition as DecimalFieldDefinition).Max = 1.0M;

            (formRecord.FieldValues.First(_ => _ is DecimalFieldValue) as DecimalFieldValue).Value = 1.1M;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Int_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is IntFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue) as IntFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Int_field_value_less_than_min_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue).FieldDefinition as IntFieldDefinition).Min = 1;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue) as IntFieldValue).Value = 0;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Int_field_value_greater_than_max_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue).FieldDefinition as IntFieldDefinition).Max = 1;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue) as IntFieldValue).Value = 2;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is MultiSelectFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is MultiSelectFieldValue) as MultiSelectFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is MultiSelectFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is MultiSelectFieldValue) as MultiSelectFieldValue).Value = new List<int>();

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Radio_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is RadioFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is RadioFieldValue) as RadioFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task RichText_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is RichTextFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is RichTextFieldValue) as RichTextFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task RichText_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is RichTextFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is RichTextFieldValue) as RichTextFieldValue).Value = string.Empty;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Select_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is SelectFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is SelectFieldValue) as SelectFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task TextArea_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is TextAreaFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is TextAreaFieldValue) as TextAreaFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task TextArea_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is TextAreaFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is TextAreaFieldValue) as TextAreaFieldValue).Value = string.Empty;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Time_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is TimeFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is TimeFieldValue) as TimeFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Time_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is TimeFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is TimeFieldValue) as TimeFieldValue).Value = string.Empty;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is CascaderFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is CascaderFieldValue) as CascaderFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is CascaderFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is CascaderFieldValue) as CascaderFieldValue).Value = new List<int>();

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Colorpicker_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is ColorPickerFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is ColorPickerFieldValue) as ColorPickerFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Colorpicker_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is ColorPickerFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is ColorPickerFieldValue) as ColorPickerFieldValue).Value = string.Empty;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Slider_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is SliderFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is SliderFieldValue) as SliderFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Slider_field_value_less_than_min_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue).FieldDefinition as IntFieldDefinition).Min = 1;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue) as IntFieldValue).Value = 0;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Slider_field_value_greater_than_max_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue).FieldDefinition as IntFieldDefinition).Max = 1;

            (formRecord.FieldValues.First(_ => _ is IntFieldValue) as IntFieldValue).Value = 2;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Switch_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is SwitchFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is SwitchFieldValue) as SwitchFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_field_value_is_required_and_null_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is UploaderFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is UploaderFieldValue) as UploaderFieldValue).Value = null;

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_field_value_is_required_and_empty_should_be_invalid()
        {
            var formRecord = TestData.FormRecord;

            formRecord.FieldValues.First(_ => _ is UploaderFieldValue).FieldDefinition.IsRequired = true;

            (formRecord.FieldValues.First(_ => _ is UploaderFieldValue) as UploaderFieldValue).Value = new List<FileModel>();

            var context = new FormRecordValidationContext(TestData.FormDefinition.FormId, formRecord);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }
    }
}
