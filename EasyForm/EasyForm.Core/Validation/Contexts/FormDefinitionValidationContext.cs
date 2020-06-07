using EasyForm.Core.Models.Definitions;

namespace EasyForm.Core.Validation.Contexts
{
    public class FormDefinitionValidationContext
    {
        public FormDefinition FormDefinition { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public FormDefinitionValidationContext(FormDefinition formDefinition)
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
