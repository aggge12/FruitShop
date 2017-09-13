namespace FruitWebService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FruitDBModels : DbContext
    {
        public FruitDBModels()
            : base("name=FruitDBModels")
        {
        }

        public virtual DbSet<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }
        public virtual DbSet<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }
        public virtual DbSet<Fruit> Fruit { get; set; }
        public virtual DbSet<FruitSupplier> FruitSupplier { get; set; }
        public virtual DbSet<ProcessedIncomingTransactions> ProcessedIncomingTransactions { get; set; }
        public virtual DbSet<ProcessedOutgoingTransactions> ProcessedOutgoingTransactions { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Fruit>()
                .HasMany(e => e.ContentOfIncomingTransaction)
                .WithRequired(e => e.Fruit1)
                .HasForeignKey(e => e.Fruit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fruit>()
                .HasMany(e => e.ContentOfOutgoingTransaction)
                .WithRequired(e => e.Fruit1)
                .HasForeignKey(e => e.Fruit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fruit>()
                .HasMany(e => e.FruitSupplier)
                .WithRequired(e => e.Fruit1)
                .HasForeignKey(e => e.Fruit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessedIncomingTransactions>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ProcessedIncomingTransactions>()
                .HasMany(e => e.ContentOfIncomingTransaction)
                .WithRequired(e => e.ProcessedIncomingTransactions1)
                .HasForeignKey(e => e.ProcessedIncomingTransactions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessedOutgoingTransactions>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<ProcessedOutgoingTransactions>()
                .HasMany(e => e.ContentOfOutgoingTransaction)
                .WithRequired(e => e.ProcessedOutgoingTransactions)
                .HasForeignKey(e => e.ProcessedOutgoingTransaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.FruitSupplier)
                .WithRequired(e => e.Supplier1)
                .HasForeignKey(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.ProcessedIncomingTransactions)
                .WithRequired(e => e.Supplier1)
                .HasForeignKey(e => e.Supplier)
                .WillCascadeOnDelete(false);
        }
    }
}
