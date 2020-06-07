using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Options
{
    public class FormStoreOptions
    {
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }
    }
}
