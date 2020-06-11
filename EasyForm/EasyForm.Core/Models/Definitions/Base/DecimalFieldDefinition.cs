﻿using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public class DecimalFieldDefinition : FieldDefinition, 
        ISortableField,
        IFilterableField,
        IUniqueableField
    {
        public decimal? Max { get; set; }
        public decimal? Min { get; set; }
        public decimal? DefaultValue { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
        public bool IsUnique { get; set; }
    }
}
