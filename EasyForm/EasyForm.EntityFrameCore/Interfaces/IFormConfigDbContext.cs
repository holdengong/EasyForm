using EasyForm.EntityFrameCore.Entities.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IFormConfigDbContext : IDisposable
    {
        DbSet<FormEntity> Forms { get; set; }
        DbSet<BoolFieldEntity> BoolFields { get; set; }
        DbSet<DateTimeFieldEntity> DateTimeFields { get; set; }
        DbSet<DecimalFieldEntity> DecimalFields { get; set; }
        DbSet<IntFieldEntity> IntFields { get; set; }
        DbSet<ObjectFieldEntity> ObjectFields { get; set; }
        DbSet<OptionEntity> Options { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
