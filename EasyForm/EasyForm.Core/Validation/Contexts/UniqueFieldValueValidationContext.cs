using EasyForm.Core.Models.Records.Base;

namespace EasyForm.Core.Validation.Contexts
{
    public class UniqueFieldValueValidationContext
    {
        public string FormId { get; set; }

        public FieldValue FieldValue { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public UniqueFieldValueValidationContext(string formId, FieldValue fieldValue)
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
