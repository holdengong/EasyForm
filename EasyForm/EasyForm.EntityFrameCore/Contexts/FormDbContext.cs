using EasyForm.EntityFrameCore.Entities.Config;
using EasyForm.EntityFrameCore.Interfaces;
using EasyForm.EntityFrameCore.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyForm.EntityFrameCore.Contexts
{
    public class FormDbContext : EasyFormConfigDbContext<FormDbContext>
    {
        public FormDbContext(DbContextOptions<FormDbContext> options, FormStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public class EasyFormConfigDbContext<TContext> : DbContext, IFormConfigDbContext
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
        public DbSet<OptionEntity> Options { get; set; }

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
            modelBuilder.Entity<FormEntity>(form =>
            {
                form.ToTable("form");
                form.HasKey(x => x.Id);

                form.Property(x => x.FormId)
                .HasMaxLength(100)
                .IsRequired();

                form.Property(x => x.Description)
                .HasMaxLength(200);

                form.Property(x => x.Created)
                .IsRequired();

                form.Property(x => x.Updated);

                form.HasIndex(_ => _.FormId).IsUnique();

                form.HasMany(x => x.BoolFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DateTimeFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DecimalFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.IntFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.ObjectFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);

                form.HasMany(x => x.Records).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BoolFieldEntity>(entity =>
            {
                entity.ToTable("bool_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DateTimeFieldEntity>(entity =>
            {
                entity.ToTable("date_time_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DecimalFieldEntity>(entity=>
            {
                entity.ToTable("decimal_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<IntFieldEntity>(entity =>
            {
                entity.ToTable("int_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<ObjectFieldEntity>(entity =>
            {
                entity.ToTable("object_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<OptionEntity>(entity=> 
            {
                entity.ToTable("options");
                entity.Property(x => x.Label).HasMaxLength(200);
                entity.Property(x=>x.Purpose).HasMaxLength(50);

                entity.HasIndex(x => x.Purpose);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
