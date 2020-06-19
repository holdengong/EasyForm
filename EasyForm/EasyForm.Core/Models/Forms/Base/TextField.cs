using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class TextField : FieldDefinition<string>,
        IFuzzyFilterableField
    {
        public TextField()
        {

        }

        public TextField(string fieldName, string displayName)
     : base(fieldName, displayName)
        {
        }

        public string Placeholder { get; set; }
        public bool AllowFilter { get; set; }
    }
}
