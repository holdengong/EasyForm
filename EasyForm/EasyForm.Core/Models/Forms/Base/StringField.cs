using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class StringField : Field<string>,
        IFuzzyFilterableField,
        ISortableField,
        IUniqueableField
    {
        public StringField()
        {

        }

        public StringField(string fieldName, string displayName)
     : base(fieldName, displayName)
        {
        }

        public int MaxLength { get; set; } = 255;
        public string Placeholder { get; set; }
        public bool IsUnique { get; set; }
        public bool AllowFilter { get; set; }
        public bool AllowSort { get; set; }
    }
}
