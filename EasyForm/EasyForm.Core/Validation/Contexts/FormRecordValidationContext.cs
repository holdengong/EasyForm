using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Records;
using EasyForm.Core.Models.Records.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Validation.Contexts
{
    public class FormRecordValidationContext
    {
        public FormDefinition FormDefinition { get; }
        public FormRecord FormRecord { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public Dictionary<FieldValue, string> FieldRecordErrors { get; set; } 

        public FormRecordValidationContext(FormDefinition formDefinition,FormRecord formRecord)
        {
            FormDefinition = formDefinition;
            FormRecord = formRecord;
            FieldRecordErrors = new Dictionary<FieldValue, string>();
        }

        public void AddRecordError(FieldValue record, string message)
        {
            FieldRecordErrors.Add(record, message);
            SetError("invalid record");
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
