using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Definitions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.UnitTests.Validation
{
    internal class TestForms
    {
        public static IEnumerable<FormDefinition> GetForms()
        {
            var result = new List<FormDefinition>();

            var testForm = new FormDefinition
            {
                FormId = "test",
                Description = "test",
                Fields = new List<FieldDefinition>
                {
                    new TextboxFieldDefinition{ FieldName="testTextBox" }
                }
            };

            return result;
        }
    }
}
