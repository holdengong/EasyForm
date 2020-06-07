using EasyForm.EntityFrameCore.Entities.Config;
using EasyForm.EntityFrameCore.Interfaces;
using EasyForm.EntityFrameCore.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Contexts
{
    public class EasyFormConfigDbContext : EasyFormConfigDbContext<EasyFormConfigDbContext>
    {
        public EasyFormConfigDbContext(DbContextOptions<EasyFormConfigDbContext> options, FormStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public class EasyFormConfigDbContext<TContext> : DbContext, IEasyFormConfigDbContext
    {
        private readonly FormStoreOptions storeOptions;
        public EasyFormConfigDbContext(DbContextOptions options, FormStoreOptions storeOptions)
          : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        public DbSet<FormEntity> Forms { get; set; }
        public DbSet<BoolFieldEntity> BoolFields { get; set; }
        public DbSet<DateTimeFieldEntity> DateTimeFields { get; set; }
        public DbSet<DecimalFieldEntity> DecimalFields { get; set; }
        public DbSet<IntFieldEntity> IntFields { get; set; }
        public DbSet<ObjectFieldEntity> ObjectFields { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
