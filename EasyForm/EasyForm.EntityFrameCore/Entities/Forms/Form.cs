using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class Form : BaseEntity
    {
        public string Key { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public string Description { get; set; }
        public IEnumerable<BoolField> BoolFields { get; set; }
        public IEnumerable<DateTimeField> DateTimeFields { get; set; }
        public IEnumerable<DecimalField> DecimalFields { get; set; }
        public IEnumerable<IntField> IntFields { get; set; }
        public IEnumerable<ObjectField> ObjectFields { get; set; }
    }
}
