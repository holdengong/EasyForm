using EasyForm.Core.Interfaces;
using EasyForm.Core.Validation.Contexts;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class NoOpFieldRecordUniqueValidator : IFieldRecordUniqueValidator
    {
        public Task ValidateAsync(FieldRecordUniqueValidationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
