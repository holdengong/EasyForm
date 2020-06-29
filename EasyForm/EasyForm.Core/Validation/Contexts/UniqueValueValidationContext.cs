using EasyForm.Core.Models.Records.Base;

namespace EasyForm.Core.Validation.Contexts
{
    public class UniqueValueValidationContext
    {
        public string FormKey { get; set; }

        public FieldValue FieldValue { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public UniqueValueValidationContext(string formKey, FieldValue fieldValue)
        {
            FormKey = formKey;
            FieldValue = fieldValue;
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
