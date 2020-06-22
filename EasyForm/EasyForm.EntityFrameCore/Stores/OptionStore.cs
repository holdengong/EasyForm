using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using EasyForm.EntityFrameCore.Contexts;
using EasyForm.EntityFrameCore.Extensions;
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

        public async Task AddAsync(string purpose, IEnumerable<Option> options)
        {
            var existing = _formDbContext.Options.Count(x => x.Purpose.Equals(purpose, StringComparison.CurrentCultureIgnoreCase));
            if (existing > 0)
            {
                throw new InvalidOperationException($"purpose {purpose} existed");
            }

            var entities = options.ToEntity(purpose);

            _formDbContext.Options.AddRange(entities);

            await _formDbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Option>> GetAsync(string purpose)
        {
            var entities = _formDbContext.Options.Where(x => x.Purpose.Equals(purpose, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task RemoveAsync(string purpose)
        {
            var existing = _formDbContext.Options.Where(x => x.Purpose.Equals(purpose, StringComparison.CurrentCultureIgnoreCase));
            _formDbContext.Options.RemoveRange(existing);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(string purpose, IEnumerable<Option> options)
        {
            using ( var trans = _formDbContext.Database.BeginTransaction())
            {
                try
                {
                    var existing = _formDbContext.Options.Where(x => x.Purpose.Equals(purpose, StringComparison.CurrentCultureIgnoreCase));
                    _formDbContext.Options.RemoveRange(existing);
                    _formDbContext.Options.AddRange(options.ToEntity(purpose));
                    await trans.CommitAsync();
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}
