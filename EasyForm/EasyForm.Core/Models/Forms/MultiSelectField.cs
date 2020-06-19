﻿using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class MultiSelectField : ObjectField<List<int>>,
        IHasOptions
    {
        public MultiSelectField()
        {
        }

        public MultiSelectField(string fieldName, string displayName)
    : base(fieldName, displayName)
        {
        }
        public IEnumerable<FieldOption> Options { get; set; }
        public string OptionsProvider { get; set; }
        public IOptionsStore OptionsStore { get; set; }
    }
}