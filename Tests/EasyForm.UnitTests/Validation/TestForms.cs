using EasyForm.Core.Models.Abstract;
using EasyForm.Core.Models.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.UnitTests.Validation
{
    internal class TestForms
    {
        public static IEnumerable<Form> GetForms()
        {
            var result = new List<Form>();

            var testForm = new Form
            {
                FormId = "test",
                Description = "test",
                Fields = new List<Field>
                {
                    new TextBox{ FieldName="testTextBox" }
                }
            };

            return result;
        }
    }
}
