using EasyForm.Core.Models.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    /// <summary>
    /// store for getting field options at runtime.
    /// </summary>
    public interface IOptionStore
    {
        /// <summary>
        /// get field options by name.
        /// </summary>
        /// <param name="purpose"></param>
        /// <returns></returns>
        Task<IEnumerable<Option>> GetAsync(string purpose);

        /// <summary>
        /// remove field options by name.
        /// </summary>
        /// <param name="purpose"></param>
        Task RemoveAsync(string purpose);

        /// <summary>
        /// add field options.
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="options"></param>
        Task AddAsync(string purpose, IEnumerable<Option> options);

        /// <summary>
        /// update field options.
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task UpdateAsync(string purpose, IEnumerable<Option> options);
    }
}
