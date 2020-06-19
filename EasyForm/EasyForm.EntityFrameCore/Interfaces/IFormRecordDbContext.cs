using EasyForm.EntityFrameCore.Entities.Records;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IFormRecordDbContext : IDisposable
    {
        DbSet<Record> FormRecords { get; set; }
        DbSet<BoolFieldValue> BoolFieldValues { get; set; }
        DbSet<DateTimeFieldValue> DateTimeFieldValues { get; set; }
        DbSet<DecimalFieldValue> DecimalFieldValues { get; set; }
        DbSet<IntFieldValueEntity> IntFieldValues { get; set; }
        DbSet<ObjectFieldValueEntity> ObjectFieldValues { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
