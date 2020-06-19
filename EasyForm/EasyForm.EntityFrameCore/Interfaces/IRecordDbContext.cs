using EasyForm.EntityFrameCore.Entities.Records;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IRecordDbContext : IDisposable
    {
        DbSet<Record> FormRecords { get; set; }
        DbSet<BoolFieldValue> BoolFieldValues { get; set; }
        DbSet<DateTimeFieldValue> DateTimeFieldValues { get; set; }
        DbSet<DecimalFieldValue> DecimalFieldValues { get; set; }
        DbSet<IntFieldValue> IntFieldValues { get; set; }
        DbSet<ObjectFieldValue> ObjectFieldValues { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
