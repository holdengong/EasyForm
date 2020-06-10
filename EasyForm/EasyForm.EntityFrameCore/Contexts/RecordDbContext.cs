using EasyForm.EntityFrameCore.Entities.Config;
using EasyForm.EntityFrameCore.Interfaces;
using EasyForm.EntityFrameCore.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Contexts
{
    public class RecordDbContext : EasyFormConfigDbContext<RecordDbContext>
    {
        public RecordDbContext(DbContextOptions<RecordDbContext> options, FormStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public class RecordDbContext<TContext> : DbContext, IFormRecordDbContext
    {
        private readonly FormStoreOptions storeOptions;
        public RecordDbContext(DbContextOptions options, FormStoreOptions storeOptions)
          : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        public DbSet<FormRecordEntity> FormRecords { get; set; }
        public DbSet<BoolFieldValueEntity> BoolFieldValues { get; set; }
        public DbSet<DateTimeFieldValueEntity> DateTimeFieldValues { get; set; }
        public DbSet<DecimalFieldValueEntity> DecimalFieldValues { get; set; }
        public DbSet<IntFieldValueEntity> IntFieldValues { get; set; }
        public DbSet<ObjectFieldValueEntity> ObjectFieldValues { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormRecordEntity>(form =>
            {
                form.ToTable("record");
                form.HasKey(x => x.Id);

                form.Property(x => x.Created)
                .IsRequired();

                form.Property(x => x.Updated);

                form.HasMany(x => x.BoolFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DateTimeFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DecimalFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.IntFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.ObjectFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BoolFieldValueEntity>(entity =>
            {
                entity.ToTable("bool_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DateTimeFieldValueEntity>(entity =>
            {
                entity.ToTable("datetime_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DecimalFieldValueEntity>(entity =>
            {
                entity.ToTable("decimal_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<IntFieldValueEntity>(entity =>
            {
                entity.ToTable("int_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<ObjectFieldValueEntity>(entity =>
            {
                entity.ToTable("object_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
                entity.Property(x => x.Value).HasColumnType("json");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
