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

        public DbSet<FormDefinitionEntity> FormDefinitions { get; set; }
        public DbSet<BoolFieldDefinitionEntity> BoolFieldDefinitions { get; set; }
        public DbSet<DateTimeFieldDefinitionEntity> DateTimeFieldDefinitions { get; set; }
        public DbSet<DecimalFieldDefinitionEntity> DecimalFieldDefinitions { get; set; }
        public DbSet<IntFieldDefinitionEntity> IntFieldDefinitions { get; set; }
        public DbSet<ObjectFieldDefinitionEntity> ObjectFieldDefinitions { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
