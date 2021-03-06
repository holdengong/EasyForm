﻿using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System;
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
        public IEnumerable<Option> Options { get; set; }
        public Func<string, IEnumerable<Option>> OptionsFunc { get; set; }
    }
}
