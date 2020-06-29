using EasyForm.Core.Models.Forms;

namespace EasyForm.Core.Validation.Contexts
{
    public class FormValidationContext
    {
        public Form FormDefinition { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public FormValidationContext(Form formDefinition)
        {
            FormDefinition = formDefinition;
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
