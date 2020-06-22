using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using EasyForm.EntityFrameCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Stores
{
    public class OptionStore : IOptionStore
    {
        private readonly FormDbContext _formDbContext;

        public OptionStore(FormDbContext formDbContext)
        {
            _formDbContext = formDbContext;
        }

        public Task AddAsync(string purpose, IEnumerable<Option> options)
        {
            var existing = _formDbContext.Options.Count(x => x.Purpose.Equals(purpose, StringComparison.CurrentCultureIgnoreCase));
            if (existing > 0)
            {
                throw new InvalidOperationException($"purpose {purpose} existed");
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Option>> GetAsync(string purpose)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string purpose)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string purpose, IEnumerable<Option> options)
        {
            throw new NotImplementedException();
        }
    }
}
