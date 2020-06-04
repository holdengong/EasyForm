using System;
using System.Collections.Generic;
using System.Text;
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
        Task<Form> GetByFormIdAsync(string formId);

        /// <summary>
        /// add form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task AddAsync(Form form);

        /// <summary>
        /// update form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task UpdateAsync(Form form);

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
        Task<IEnumerable<Form>> GetAllAsync();
    }
}
