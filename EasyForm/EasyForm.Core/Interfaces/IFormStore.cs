﻿using EasyForm.Core.Models.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IFormStore
    {
        /// <summary>
        /// get form by form key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Form> GetByKeyAsync(string key);

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
        /// remove form by form key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveByKeyAsync(string key);

        /// <summary>
        /// get all form definitions.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Form>> GetAllAsync();
    }
}
