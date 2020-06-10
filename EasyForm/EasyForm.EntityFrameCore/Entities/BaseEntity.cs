using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
