using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.UnitTests.Stubs
{
    public class FakeFieldOptionsStore : IFieldOptionsStore
    {
        public Task AddAsync(string name, IEnumerable<FieldOption> options)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<FieldOption>> GetAsync(string name)
        {
            return Task.FromResult(null as IEnumerable<FieldOption>);
        }

        public Task RemoveAsync(string name)
        {
            return Task.CompletedTask;
        }
    }
}
