using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EasyForm.Core.Stores
{
    public class InMemoryFormStore : IFormStore
    {
        private readonly IEnumerable<Form> forms;

        public InMemoryFormStore(IEnumerable<Form> forms)
        {
            if (forms.HasDuplicates(_ => _.FormId))
            {
                throw new ArgumentException("Forms must not contain duplicate ids");
            }

            this.forms = forms;
        }

        public Task<Form> FindFormByFormIdAsync(string formId)
        {
            var query =
               from form in forms
               where form.FormId == formId
               select form;

            return Task.FromResult(query.SingleOrDefault());
        }
    }
}
