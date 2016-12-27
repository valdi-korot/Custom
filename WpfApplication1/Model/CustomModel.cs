namespace WpfApplication1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CustomModel : DbContext
    {
        public CustomModel()
            : base("name=CustomContext")
        {
        }

        public virtual DbSet<BlackList> BlackList { get; set; }
        public virtual DbSet<Customs> Customs { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customs>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.LName)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.Passport)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .HasMany(e => e.BlackList)
                .WithOptional(e => e.Persons)
                .HasForeignKey(e => e.PersonId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Persons>()
                .HasMany(e => e.Customs)
                .WithOptional(e => e.Persons)
                .HasForeignKey(e => e.PersonId);
        }
    }
}
