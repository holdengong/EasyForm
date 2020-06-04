﻿using EasyForm.Core.Interfaces;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Components
{
    public class Select : NumberField<int>, IComponentHasOptions<int>
    {
        public IEnumerable<Option<int>> Options { get; set; }
    }
}