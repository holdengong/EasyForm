using EasyForm.Core.Stores;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyForm.UnitTests.Stores
{
    public class InMemoryFormStoreTests
    {
        [Fact]
        public void InMemoryClients_should_throw_if_contains_duplicate_ids()
        {
            var forms = new List<Form>
            {
                new Form{  Id = "1"},
                new Form{  Id = "1"},
                new Form{  Id = "2"}
            };
            Action act = () => new InMemoryFormStore(forms);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void InMemoryClients_should_not_throw_if_does_not_contains_duplicate_ids()
        {
            var forms = new List<Form>
            {
                new Form{  Id = "1"},
                new Form{  Id = "2"},
                new Form{  Id = "3"}
            };
            var store = new InMemoryFormStore(forms);
        }
    }
}
