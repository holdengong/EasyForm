using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.UnitTests.Stubs;
using EasyForm.Core.Validation.Contexts;
using EasyForm.Core.Validation.Default;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EasyForm.UnitTests.Validation.Default
{
    public class DefaultFormDefinitionValidatorTest
    {
        private readonly IFormValidator validator;
        private readonly EasyFormOptions options;
        public DefaultFormDefinitionValidatorTest()
        {
            options = new EasyFormOptions();
            validator = new DefaultFormDefinitionValidator(options);
        }

        [Fact]
        public async Task Valid_should_success()
        {
            var forms = TestData.FormDefinitions;

            foreach (var form in forms)
            {
                var context = new FormDefinitionValidationContext(form);
                await validator.ValidateAsync(context);
                context.IsValid.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Id_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "",
                Fields = new List<FieldDefinition>
                  {
                      new TextboxFieldDefinition
                      {
                           FieldName = "test"
                      }
                  }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Fields_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = null
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Fields_has_no_element_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>()
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Field_name_is_missing_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new TextboxFieldDefinition{ FieldName="" }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Field_name_has_duplicates_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new TextboxFieldDefinition{ FieldName = "1" },
                    new TextboxFieldDefinition{ FieldName = "1"}
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_option_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new CascaderFieldDefinition{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_option_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new CascaderFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Checkbox_option_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new CheckboxFieldDefinition{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Chexkbox_option_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new CheckboxFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_option_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new MultiSelectFieldDefinition{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_option_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new MultiSelectFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Radio_option_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new RadioFieldDefinition{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Radio_option_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new RadioFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Select_option_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new SelectFieldDefinition{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Select_option_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new SelectFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_file_types_is_null_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new UploaderFieldDefinition{ FieldName="test", AllowFileTypes=null }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_file_types_is_empty_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new UploaderFieldDefinition{ FieldName="test", AllowFileTypes= new List<string>() }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_multiple_and_limit_count_is_zero_or_negative_should_be_invalid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new UploaderFieldDefinition
                    {
                        FieldName="test",
                        AllowFileTypes= new List<string>{ "jpg" },
                        IsMultiple=true
                    }
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Checkbox_options_is_null_and_options_store_provided_should_be_valid()
        {
            var form = new FormDefinition
            {
                FormId = "test",
                Fields = new List<FieldDefinition>
                {
                    new CheckboxFieldDefinition{ FieldName="test" ,Options = new List<FieldOption>(),
                     OptionsProvider = "test", OptionsStore = new FakeFieldOptionsStore()}
                }
            };
            var context = new FormDefinitionValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeTrue();
        }
    }
}
