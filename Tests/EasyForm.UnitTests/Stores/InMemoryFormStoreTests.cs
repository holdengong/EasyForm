using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Stores;
using EasyForm.Core.Validation.Default;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyForm.UnitTests.Stores
{
    public class InMemoryFormStoreTests
    {
        private readonly IFormValidator formValidator;
        private readonly EasyFormOptions easyFormOptions;
        public InMemoryFormStoreTests()
        {
            easyFormOptions = new EasyFormOptions();
            formValidator = new DefaultFormValidator(easyFormOptions);
        }

        [Fact]
        public void InMemoryClients_should_throw_if_contains_duplicate_ids()
        {
            var forms = new List<Form>
            {
                new Form{  FormId = "1"},
                new Form{  FormId = "1"},
                new Form{  FormId = "2"}
            };
            Action act = () => new InMemoryFormStore(forms, formValidator);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void InMemoryClients_should_not_throw_if_does_not_contains_duplicate_ids()
        {
            var forms = new List<Form>
            {
                new Form{  FormId = "1"},
                new Form{  FormId = "2"},
                new Form{  FormId = "3"}
            };
            var store = new InMemoryFormStore(forms, formValidator);
        }
    }
}
