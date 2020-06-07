using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Stores
{
    public class EntityFrameworkFormStore : IFormDefinitionStore
    {
        public Task AddAsync(FormDefinition form)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FormDefinition>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FormDefinition> GetByFormIdAsync(string formId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByFormIdAsync(string formId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FormDefinition form)
        {
            throw new NotImplementedException();
        }
    }
}
