using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Stores
{
    public class InMemoryFormStore : IFormStore
    {
        private static List<Form> forms;
        private readonly IFormValidator formValidator;

        public InMemoryFormStore(IEnumerable<Form> seedForms,
            IFormValidator formValidator)
        {
            if (seedForms.HasDuplicates(_ => _.Key))
            {
                throw new ArgumentException("Forms must not contain duplicate ids");
            }
            if (forms == null)
            {
                forms = seedForms.ToList();
            }

            this.formValidator = formValidator;
        }

        public async Task AddAsync(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (forms.Any(_ => _.Key == form.Key))
            {
                throw new ArgumentException("form id already exist");
            }

            var context = new FormValidationContext(form);
            await formValidator.ValidateAsync(context);
            if (!context.IsValid)
            {
                throw new ArgumentException(context.ErrorMessage);
            }
            forms.Add(form);
        }

        public Task<IEnumerable<Form>> GetAllAsync()
        {
            return Task.FromResult(forms as IEnumerable<Form>);
        }

        public async Task<Form> GetByKeyAsync(string formId)
        {
            var form = forms.SingleOrDefault(_ => _.Key == formId);
            var context = new FormValidationContext(form);
            await formValidator.ValidateAsync(context);
            if (!context.IsValid)
            {
                throw new ArgumentException(context.ErrorMessage);
            }

            return form;
        }

        public Task RemoveByKeyAsync(string formId)
        {
            var form = forms.SingleOrDefault(_ => _.Key == formId);
            if (form != null)
            {
                forms.Remove(form);
            }

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Form form)
        {
            var match = forms.SingleOrDefault(_ => _.Key == form.Key);
            if (match != null)
            {
                match.Description = form.Description;
                match.Fields = form.Fields;
            }

            return Task.CompletedTask;
        }
    }
}
