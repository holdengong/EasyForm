using EasyForm.Core.Interfaces;
using EasyForm.Core.Validation.Contexts;
using System.Threading.Tasks;

namespace EasyForm.Core.Validation.Default
{
    public class NoOpUniqueValueValidator : IUniqueValueValidator
    {
        public Task ValidateAsync(UniqueValueValidationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
