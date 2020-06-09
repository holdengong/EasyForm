using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IFieldRecordUniqueValidator
    {
        Task ValidateAsync(UniqueFieldValueValidationContext context);
    }
}
