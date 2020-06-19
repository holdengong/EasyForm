using EasyForm.Core.Models.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    /// <summary>
    /// store for getting field options at runtime.
    /// </summary>
    public interface IOptionsStore
    {
        /// <summary>
        /// get field options by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<FieldOption>> GetAsync(string name);

        /// <summary>
        /// remove field options by name.
        /// </summary>
        /// <param name="name"></param>
        Task RemoveAsync(string name);

        /// <summary>
        /// add field options.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        Task AddAsync(string name, IEnumerable<FieldOption> options);
    }
}
