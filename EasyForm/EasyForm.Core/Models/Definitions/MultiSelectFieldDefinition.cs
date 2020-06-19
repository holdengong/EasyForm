﻿using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class MultiSelectFieldDefinition : ObjectFieldDefinition<List<int>>,
        IFieldHasOptions
    {
        public MultiSelectFieldDefinition()
        {
        }

        public MultiSelectFieldDefinition(string fieldName, string displayName)
    : base(fieldName, displayName)
        {
        }
        public IEnumerable<FieldOption> Options { get; set; }
        public string OptionsProvider { get; set; }
        public IFieldOptionsStore OptionsStore { get; set; }
    }
}
