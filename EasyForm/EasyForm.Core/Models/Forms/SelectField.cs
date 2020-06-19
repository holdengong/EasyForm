﻿using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class SelectField : IntField, IHasOptions
    {
        public SelectField()
        {

        }

        public SelectField(string fieldName, string displayName)
            : base(fieldName, displayName)
        {

        }

        public IEnumerable<FieldOption> Options { get; set; }
        public string OptionsProvider { get; set; }
        public IOptionsStore OptionsStore { get; set; }
    }
}
