using EasyForm.EntityFrameCore.Entities.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Interfaces
{
    public interface IFormDbContext : IDisposable
    {
        DbSet<Form> Forms { get; set; }
        DbSet<BoolField> BoolFields { get; set; }
        DbSet<DateTimeField> DateTimeFields { get; set; }
        DbSet<DecimalField> DecimalFields { get; set; }
        DbSet<IntField> IntFields { get; set; }
        DbSet<ObjectField> ObjectFields { get; set; }
        DbSet<Option> Options { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
