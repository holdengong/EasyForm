using EasyForm.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IRecordStore
    {
        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task<string> AddAsync(string formId, IDictionary<string, object> values);

        /// <summary>
        /// update a record
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task UpdateAsync(string recordId, IDictionary<string, object> values);

        /// <summary>
        /// remove a record
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        Task RemoveAsync(string recordId);

        /// <summary>
        /// get a record by id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        Task<Record> GetAsync(string recordId);

        /// <summary>
        /// get all records of form, caution: might case performance issue
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        Task<IEnumerable<Record>> GetAllAsync(string formId);

        /// <summary>
        /// get paged records, sort by lastest update time desc by default
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="total"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Record>> GetListAsync(string formId, out int total, int pageNo = 1, int pageSize = 10);

        /// <summary>
        /// get paged records, with sort/filter
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="total"></param>
        /// <param name="filterByFieldName"></param>
        /// <param name="filterByValue"></param>
        /// <param name="sortByFieldName"></param>
        /// <param name="asc"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Record>> GetListAsync(string formId, out int total, string filterByFieldName = "", object filterByValue = null, string sortByFieldName = "", bool asc = false, int pageNo = 1, int pageSize = 10);

        /// <summary>
        /// get records count
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        Task<long> CountAsync(string formId);
    }
}
