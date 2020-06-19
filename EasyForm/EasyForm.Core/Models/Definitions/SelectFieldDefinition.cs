using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class SelectFieldDefinition : IntFieldDefinition, IHasOptions
    {
        public SelectFieldDefinition()
        {

        }

        public SelectFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {

        }

        public IEnumerable<FieldOption> Options { get; set; }
        public string OptionsProvider { get; set; }
        public IOptionsStore OptionsStore { get; set; }
    }
}
