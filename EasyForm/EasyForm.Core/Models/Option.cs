using System.Collections.Generic;

namespace EasyForm
{
    public class Option<TOptionValueType>
    { 
        public string Label { get; set; }
        public TOptionValueType Value { get; set; }
    }

    public class OptionWithChild<TOptionValueType> : Option<TOptionValueType>
    { 
       public IEnumerable<OptionWithChild<TOptionValueType>> Children { get; set; }
    }
}
