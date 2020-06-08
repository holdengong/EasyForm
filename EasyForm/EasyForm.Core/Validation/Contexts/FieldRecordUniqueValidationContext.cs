﻿using EasyForm.Core.Models.Records.Base;

namespace EasyForm.Core.Validation.Contexts
{
    public class FieldRecordUniqueValidationContext
    {
        public string FormDefinitionId { get; set; }

        public FieldValue FieldReocrd { get; }

        public bool IsValid { get; set; } = true;

        public string ErrorMessage { get; set; }

        public FieldRecordUniqueValidationContext(string formDefinitionId, FieldValue fieldRecord)
        {
            FormDefinitionId = formDefinitionId;
            FieldReocrd = fieldRecord;
        }

        public void SetError(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }
    }
}
