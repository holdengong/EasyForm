using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class RadioField : IntField, IHasOptions
    {
        public RadioField()
        {
        }
        public IEnumerable<Option> Options { get; set; }
        public Func<string, IEnumerable<Option>> OptionsFunc { get; set; }
    }
}
