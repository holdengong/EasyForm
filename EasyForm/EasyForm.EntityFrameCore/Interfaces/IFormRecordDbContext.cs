using EasyForm.EntityFrameCore.Entities.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IFormRecordDbContext : IDisposable
    {
        DbSet<FormRecordEntity> FormRecords { get; set; }
        DbSet<BoolFieldValueEntity> BoolFieldValues { get; set; }
        DbSet<DateTimeFieldValueEntity> DateTimeFieldValues { get; set; }
        DbSet<DecimalFieldValueEntity> DecimalFieldValues { get; set; }
        DbSet<IntFieldValueEntity> IntFieldValues { get; set; }
        DbSet<ObjectFieldValueEntity> ObjectFieldValues { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
