using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IFormDefinitionValidator
    {
        /// <summary>
        /// Determines whether the configuration of a form is valid.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        Task ValidateAsync(FormDefinitionValidationContext context);
    }
}
