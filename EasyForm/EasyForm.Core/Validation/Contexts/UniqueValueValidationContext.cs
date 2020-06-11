using EasyForm.Core.Models.Records.Base;

namespace EasyForm.Core.Validation.Contexts
{
    public class UniqueValueValidationContext
    {
        public string FormId { get; set; }

        public FieldValue FieldValue { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public UniqueValueValidationContext(string formId, FieldValue fieldValue)
        {
            FormId = formId;
            FieldValue = fieldValue;
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
