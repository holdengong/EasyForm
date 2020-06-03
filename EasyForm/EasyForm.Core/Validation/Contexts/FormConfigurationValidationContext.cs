using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Validation.Contexts
{
    public class FormConfigurationValidationContext
    {
        public Form Form { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public FormConfigurationValidationContext(Form form)
        {
            Form = form;
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
