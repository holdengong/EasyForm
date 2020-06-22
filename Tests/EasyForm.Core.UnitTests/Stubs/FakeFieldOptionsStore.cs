using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Core.UnitTests.Stubs
{
    public class FakeFieldOptionsStore : IOptionStore
    {
        public Task AddAsync(string name, IEnumerable<Option> options)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Option>> GetAsync(string purpose)
        {
            return Task.FromResult(null as IEnumerable<Option>);
        }

        public Task RemoveAsync(string purpose)
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(string purpose, IEnumerable<Option> options)
        {
            throw new System.NotImplementedException();
        }
    }
}
