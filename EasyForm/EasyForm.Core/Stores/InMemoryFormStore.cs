﻿using EasyForm.Core.Extensions;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyForm.Core.Stores
{
    public class InMemoryFormStore : IFormStore
    {
        private static List<FormDefinition> forms;
        private readonly IFormValidator formValidator;

        public InMemoryFormStore(IEnumerable<FormDefinition> seedForms,
            IFormValidator formValidator)
        {
            if (seedForms.HasDuplicates(_ => _.FormId))
            {
                throw new ArgumentException("Forms must not contain duplicate ids");
            }
            if (forms == null)
            {
                forms = seedForms.ToList();
            }

            this.formValidator = formValidator;
        }

        public async Task AddAsync(FormDefinition form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (forms.Any(_ => _.FormId == form.FormId))
            {
                throw new ArgumentException("form id already exist");
            }

            var context = new FormDefinitionValidationContext(form);
            await formValidator.ValidateAsync(context);
            if (!context.IsValid)
            {
                throw new ArgumentException(context.ErrorMessage);
            }
            forms.Add(form);
        }

        public Task<IEnumerable<FormDefinition>> GetAllAsync()
        {
            return Task.FromResult(forms as IEnumerable<FormDefinition>);
        }

        public async Task<FormDefinition> GetByFormIdAsync(string formId)
        {
            var form = forms.SingleOrDefault(_ => _.FormId == formId);
            var context = new FormDefinitionValidationContext(form);
            await formValidator.ValidateAsync(context);
            if (!context.IsValid)
            {
                throw new ArgumentException(context.ErrorMessage);
            }

            return form;
        }

        public Task RemoveByFormIdAsync(string formId)
        {
            var form = forms.SingleOrDefault(_ => _.FormId == formId);
            if (form != null)
            {
                forms.Remove(form);
            }

            return Task.CompletedTask;
        }

        public Task UpdateAsync(FormDefinition form)
        {
            var match = forms.SingleOrDefault(_ => _.FormId == form.FormId);
            if (match != null)
            {
                match.Description = form.Description;
                match.Fields = form.Fields;
            }

            return Task.CompletedTask;
        }
    }
}
