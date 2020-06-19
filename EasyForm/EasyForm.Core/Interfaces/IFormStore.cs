using EasyForm.Core.Models.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IFormStore
    {
        /// <summary>
        /// get form by form id.
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        Task<FormDefinition> GetByFormIdAsync(string formId);

        /// <summary>
        /// add form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task AddAsync(FormDefinition form);

        /// <summary>
        /// update form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task UpdateAsync(FormDefinition form);

        /// <summary>
        /// remove form by form id.
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        Task RemoveByFormIdAsync(string formId);

        /// <summary>
        /// get all form definitions.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FormDefinition>> GetAllAsync();
    }
}
