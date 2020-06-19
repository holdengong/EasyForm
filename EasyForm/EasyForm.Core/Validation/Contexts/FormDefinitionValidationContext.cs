using EasyForm.Core.Models.Forms;

namespace EasyForm.Core.Validation.Contexts
{
    public class FormDefinitionValidationContext
    {
        public Form FormDefinition { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public FormDefinitionValidationContext(Form formDefinition)
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
