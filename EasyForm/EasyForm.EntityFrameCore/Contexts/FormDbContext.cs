using EasyForm.EntityFrameCore.Entities.Forms;
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

    public class EasyFormConfigDbContext<TContext> : DbContext, IFormDbContext
    {
        private readonly FormStoreOptions storeOptions;
        public EasyFormConfigDbContext(DbContextOptions options, FormStoreOptions storeOptions)
          : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<BoolField> BoolFields { get; set; }
        public DbSet<DateTimeField> DateTimeFields { get; set; }
        public DbSet<DecimalField> DecimalFields { get; set; }
        public DbSet<IntField> IntFields { get; set; }
        public DbSet<ObjectField> ObjectFields { get; set; }
        public DbSet<Option> Options { get; set; }

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
            modelBuilder.Entity<Form>(form =>
            {
                form.ToTable("form");
                form.HasKey(x => x.Id);

                form.Property(x => x.Key)
                .HasMaxLength(100)
                .IsRequired();

                form.Property(x => x.Description)
                .HasMaxLength(200);

                form.Property(x => x.Created)
                .IsRequired();

                form.Property(x => x.Updated);

                form.HasIndex(_ => _.Key).IsUnique();

                form.HasMany(x => x.BoolFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DateTimeFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.DecimalFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.IntFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                form.HasMany(x => x.ObjectFields).WithOne(x => x.Form).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BoolField>(entity =>
            {
                entity.ToTable("bool_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DateTimeField>(entity =>
            {
                entity.ToTable("date_time_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<DecimalField>(entity=>
            {
                entity.ToTable("decimal_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<IntField>(entity =>
            {
                entity.ToTable("int_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<ObjectField>(entity =>
            {
                entity.ToTable("object_field");
                entity.Property(x => x.Description).HasMaxLength(200);
                entity.Property(x => x.FieldName).HasMaxLength(200);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("options");
                entity.Property(x => x.Label).HasMaxLength(200);
                entity.Property(x => x.Value).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Purpose).HasMaxLength(50).IsRequired();

                entity.HasIndex("purpose", "value").IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
