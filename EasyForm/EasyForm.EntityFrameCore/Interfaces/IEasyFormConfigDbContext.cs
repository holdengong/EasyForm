using EasyForm.EntityFrameCore.Entities.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IEasyFormConfigDbContext : IDisposable
    {
        DbSet<FormDefinitionEntity> FormDefinitions { get; set; }
        DbSet<BoolFieldDefinitionEntity> BoolFieldDefinitions { get; set; }
        DbSet<DateTimeFieldDefinitionEntity> DateTimeFieldDefinitions { get; set; }
        DbSet<DecimalFieldDefinitionEntity> DecimalFieldDefinitions { get; set; }
        DbSet<IntFieldDefinitionEntity> IntFieldDefinitions { get; set; }
        DbSet<ObjectFieldDefinitionEntity> ObjectFieldDefinitions { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
