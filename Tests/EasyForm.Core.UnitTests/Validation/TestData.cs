using EasyForm.Core.Models;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.UnitTests.Validation
{
    public static class TestData
    {
        public static IEnumerable<FormDefinition> FormDefinitions
        {
            get
            {
                return new List<FormDefinition> { FormDefinition };
            }
        }

        public static FormDefinition FormDefinition
        {
            get
            {
                return new FormDefinition
                {
                    FormId = "test",
                    Description = "test",
                    Fields = new List<FieldDefinition>
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

        public static FormRecord FormRecord
        {
            get
            {
                return new FormRecord
                {
                    FormDefinitionId = "test",
                    FieldValues = new List<FieldValue>
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
                            new List<FileModel>
                            {
                                new FileModel{ Id = "test" }
                            }
                        },
                        new DecimalFieldValue{  FieldDefinition = DecimalFieldDefinition, Value = 1.1234M },
                        new IntFieldValue{ FieldDefinition = IntFieldDefinition, Value = 1 }
                    }
                };
            }
        }

        public static IEnumerable<FormRecord> FormRecords
        {
            get
            {
                return new List<FormRecord> { FormRecord };
            }
        }

        public static CascaderFieldDefinition CascaderFieldDefinition=> 
            new CascaderFieldDefinition { FieldName = "cascader", Options = OptionHasChildren };

        public static CheckboxFieldDefinition CheckboxFieldDefinition=> 
            new CheckboxFieldDefinition { FieldName = "checkbox", Options = Options };

        public static ColorPickerFieldDefinition ColorPickerFieldDefinition =>
            new ColorPickerFieldDefinition { FieldName = "colorpicker" };

        public static DateFieldDefinition DateFieldDefinition =>
            new DateFieldDefinition { FieldName = "date" };

        public static MultiSelectFieldDefinition MultiSelectFieldDefinition =>
            new MultiSelectFieldDefinition { FieldName = "multiselect", Options = Options };

        public static RadioFieldDefinition RadioFieldDefinition =>
            new RadioFieldDefinition { FieldName = "radio", Options = Options };

        public static RichTextFieldDefinition RichTextFieldDefinition=>
            new RichTextFieldDefinition { FieldName = "richtext" };

        public static SelectFieldDefinition SelectFieldDefinition=>
            new SelectFieldDefinition { FieldName = "select", Options = Options };

        public static SliderFieldDefinition SliderFieldDefinition=>
            new SliderFieldDefinition { FieldName = "slider" };

        public static SwitchFieldDefinition SwitchFieldDefinition=>
            new SwitchFieldDefinition { FieldName = "switch" };

        public static TextAreaFieldDefinition TextAreaFieldDefinition=>
            new TextAreaFieldDefinition { FieldName = "textare" };

        public static TextboxFieldDefinition TextboxFieldDefinition=>
            new TextboxFieldDefinition { FieldName = "textbox" };

        public static TimeFieldDefinition TimeFieldDefinition=>
            new TimeFieldDefinition { FieldName = "time" };

        public static UploaderFieldDefinition UploaderFieldDefinition=>
            new UploaderFieldDefinition { FieldName = "uploader", AllowFileTypes = new List<string> { "jpg" } };

        public static DecimalFieldDefinition DecimalFieldDefinition =>
            new DecimalFieldDefinition { FieldName = "decimal" };

        public static IntFieldDefinition IntFieldDefinition =>
            new IntFieldDefinition { FieldName = "int" };

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
