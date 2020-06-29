using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class CascaderField : ObjectField<List<int>>, IHasOptions
    {
        public CascaderField()
        {
        }

        public CascaderField(string fieldName, string displayName)
          : base(fieldName, displayName)
        {
        }
        public string OptionsPurpose { get; set; }
        public string OptionsProviderName { get; set; }
    }
}
