using EasyForm.Core.Models;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Models.Forms.Base;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.UnitTests.Validation
{
    public static class TestData
    {
        public static IEnumerable<Form> FormDefinitions
        {
            get
            {
                return new List<Form> { FormDefinition };
            }
        }

        public static Form FormDefinition
        {
            get
            {
                return new Form
                {
                    Key = "test",
                    Description = "test",
                    Fields = new List<Field>
                    {
                        CascaderFieldDefinition,
                        CheckboxFieldDefinition,
                        ColorPickerFieldDefinition,
                        DateFieldDefinition ,
                        MultiSelectFieldDefinition,
                        RadioFieldDefinition,
                        RichTextFieldDefinition,
                        SelectFieldDefinition ,
                        SliderFieldDefinition,
                        SwitchFieldDefinition,
                        TextAreaFieldDefinition,
                        TextboxFieldDefinition,
                        TimeFieldDefinition,
                        UploaderFieldDefinition
                    }
                };
            }
        }

        public static Record FormRecord
        {
            get
            {
                return new Record
                {
                    FormKey = "test",
                    Values = new List<FieldValue>
                    {
                        new CascaderFieldValue { FieldDefinition = CascaderFieldDefinition, Value = new List<int>{1 }},
                        new CheckboxFieldValue { FieldDefinition = CheckboxFieldDefinition, Value = new List<int>{ 1} },
                        new ColorPickerFieldValue{ FieldDefinition = ColorPickerFieldDefinition, Value = "#FFFFF" },
                        new DateFieldValue{ FieldDefinition = DateFieldDefinition, Value = DateTime.Now },
                        new MultiSelectFieldValue{ FieldDefinition = MultiSelectFieldDefinition, Value = new List<int>{1 } },
                        new RadioFieldValue{ FieldDefinition = RadioFieldDefinition, Value = 1 },
                        new RichTextFieldValue { FieldDefinition = RichTextFieldDefinition, Value = "test" },
                        new SelectFieldValue{ FieldDefinition = SelectFieldDefinition, Value = 1},
                        new SliderFieldValue{ FieldDefinition = SliderFieldDefinition, Value = 1},
                        new SwitchFieldValue { FieldDefinition = SwitchFieldDefinition, Value = true },
                        new TextAreaFieldValue{ FieldDefinition = TextAreaFieldDefinition,Value = "test" },
                        new TextboxFieldValue{ FieldDefinition = TextboxFieldDefinition,Value="test" },
                        new TimeFieldValue { FieldDefinition = TimeFieldDefinition, Value = "17:00" },
                        new UploaderFieldValue
                        {
                            FieldDefinition = UploaderFieldDefinition, Value =
                            new List<File>
                            {
                                new File{ Id = "test" }
                            }
                        },
                        new DecimalFieldValue{  FieldDefinition = DecimalFieldDefinition, Value = 1.1234M },
                        new IntFieldValue{ FieldDefinition = IntFieldDefinition, Value = 1 }
                    }
                };
            }
        }

        public static IEnumerable<Record> FormRecords
        {
            get
            {
                return new List<Record> { FormRecord };
            }
        }

        public static CascaderField CascaderFieldDefinition=> 
            new CascaderField { FieldName = "cascader", Options = OptionHasChildren };

        public static CheckboxField CheckboxFieldDefinition=> 
            new CheckboxField { FieldName = "checkbox", Options = Options };

        public static ColorPickerField ColorPickerFieldDefinition =>
            new ColorPickerField { FieldName = "colorpicker" };

        public static DateField DateFieldDefinition =>
            new DateField { FieldName = "date" };

        public static MultiSelectField MultiSelectFieldDefinition =>
            new MultiSelectField { FieldName = "multiselect", Options = Options };

        public static RadioField RadioFieldDefinition =>
            new RadioField { FieldName = "radio", Options = Options };

        public static RichTextField RichTextFieldDefinition=>
            new RichTextField { FieldName = "richtext" };

        public static SelectField SelectFieldDefinition=>
            new SelectField { FieldName = "select", Options = Options };

        public static SliderField SliderFieldDefinition=>
            new SliderField { FieldName = "slider" };

        public static SwitchField SwitchFieldDefinition=>
            new SwitchField { FieldName = "switch" };

        public static TextAreaField TextAreaFieldDefinition=>
            new TextAreaField { FieldName = "textare" };

        public static TextboxField TextboxFieldDefinition=>
            new TextboxField { FieldName = "textbox" };

        public static TimeField TimeFieldDefinition=>
            new TimeField { FieldName = "time" };

        public static UploaderField UploaderFieldDefinition=>
            new UploaderField { FieldName = "uploader", AllowFileTypes = new List<string> { "jpg" } };

        public static DecimalField DecimalFieldDefinition =>
            new DecimalField { FieldName = "decimal" };

        public static IntField IntFieldDefinition =>
            new IntField { FieldName = "int" };

        private static List<FieldOption> Options
        {
            get
            {
                return new List<FieldOption>
            {
                new FieldOption
                {
                    Label = "test1",
                    Value=1
                },
                new FieldOption
                {
                    Label = "test2",
                    Value=2
                }
            };
            }
        }

        private static List<FieldOption> OptionHasChildren
        {
            get
            {
                return new List<FieldOption>
                {
                    new FieldOption
                    {
                        Label = "test1",
                        Value=1,
                        Children = new List<FieldOption>
                        {
                            new FieldOption{ Label = "test1.1", Value = 12 }
                        }
                    },
                    new FieldOption
                    {
                        Label = "test2",
                        Value=2,
                        Children = new List<FieldOption>
                        {
                            new FieldOption{ Label = "test2.2", Value = 21 }
                        }
                    }
                };
            }
        }
    }
}
