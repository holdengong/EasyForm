using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Abstract;
using EasyForm.Core.Models.Components;
using EasyForm.Core.Validation.Contexts;
using EasyForm.Core.Validation.Default;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EasyForm.UnitTests.Validation.Default
{
    public class DefaultFormConfigurationValidatorTest
    {
        private readonly IFormConfigurationValidator validator;
        private readonly EasyFormOptions options;
        public DefaultFormConfigurationValidatorTest()
        {
            options = new EasyFormOptions();
            validator = new DefaultFormConfigurationValidator(options);
        }

        [Fact]
        public async Task Valid_should_success()
        {
            var forms = TestForms.GetForms();

            foreach (var form in forms)
            {
                var context = new FormConfigurationValidationContext(form);
                await validator.ValidateAsync(context);
                context.IsValid.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Id_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "",
                Fields = new List<Field>
                  {
                      new TextBox
                      {
                           FieldName = "test"
                      }
                  }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Fields_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = null
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Fields_has_no_element_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>()
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Field_name_is_missing_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new TextBox{ FieldName="" }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Field_name_has_duplicates_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new TextBox{ FieldName = "1" },
                    new TextBox{ FieldName = "1"}
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_option_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Cascader{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Cascader_option_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Cascader{ FieldName="test" ,Options = new List<OptionWithChild<int>>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Checkbox_option_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Checkbox{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Chexkbox_option_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Checkbox{ FieldName="test" ,Options = new List<Option<int>>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_option_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new MultiSelect{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task MultiSelect_option_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new MultiSelect{ FieldName="test" ,Options = new List<Option<int>>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Radio_option_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Radio{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Radio_option_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Radio{ FieldName="test" ,Options = new List<Option<int>>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Select_option_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Select{ FieldName="test" ,Options = null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Select_option_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Select{ FieldName="test" ,Options = new List<Option<int>>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_file_types_is_null_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Uploader{ FieldName="test", AllowFileTypes=null }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_file_types_is_empty_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Uploader{ FieldName="test", AllowFileTypes= new List<string>() }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Uploader_allow_multiple_and_limit_count_is_zero_or_negative_should_be_invalid()
        {
            var form = new Form
            {
                Id = "test",
                Fields = new List<Field>
                {
                    new Uploader
                    {
                        FieldName="test",
                        AllowFileTypes= new List<string>{ "jpg" },
                        IsMultiple=true
                    }
                }
            };
            var context = new FormConfigurationValidationContext(form);
            await validator.ValidateAsync(context);
            context.IsValid.Should().BeFalse();
        }
    }
}
