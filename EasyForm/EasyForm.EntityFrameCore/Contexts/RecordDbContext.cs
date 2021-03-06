﻿using EasyForm.EntityFrameCore.Entities.Records;
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

    public class RecordDbContext<TContext> : DbContext, IRecordDbContext
    {
        private readonly FormStoreOptions storeOptions;
        public RecordDbContext(DbContextOptions options, FormStoreOptions storeOptions)
          : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        public DbSet<Record> FormRecords { get; set; }
        public DbSet<BoolFieldValue> BoolFieldValues { get; set; }
        public DbSet<DateTimeFieldValue> DateTimeFieldValues { get; set; }
        public DbSet<DecimalFieldValue> DecimalFieldValues { get; set; }
        public DbSet<IntFieldValue> IntFieldValues { get; set; }
        public DbSet<ObjectFieldValue> ObjectFieldValues { get; set; }

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
            modelBuilder.Entity<Record>(form =>
            {
                form.ToTable("record");
                form.HasKey(x => x.Id);
                form.HasIndex(x => x.Key).IsUnique();

                form.Property(x => x.Created).IsRequired();
                form.Property(x => x.Updated);
                form.HasMany(x => x.BoolFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DateTimeFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DecimalFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.IntFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.ObjectFieldValues).WithOne(x => x.Record).HasForeignKey(x => x.RecordId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BoolFieldValue>(entity =>
            {
                entity.ToTable("bool_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DateTimeFieldValue>(entity =>
            {
                entity.ToTable("datetime_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DecimalFieldValue>(entity =>
            {
                entity.ToTable("decimal_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<IntFieldValue>(entity =>
            {
                entity.ToTable("int_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<ObjectFieldValue>(entity =>
            {
                entity.ToTable("object_value");
                entity.Property(x => x.FieldName).HasMaxLength(200);
                entity.Property(x => x.Value).HasColumnType("json");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
