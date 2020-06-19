using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class RadioField : IntField, IHasOptions
    {
        public RadioField()
        {
        }
        public IEnumerable<FieldOption> Options { get; set; }
        public string OptionsProvider { get; set; }
        public IOptionsStore OptionsStore { get; set; }
    }
}
