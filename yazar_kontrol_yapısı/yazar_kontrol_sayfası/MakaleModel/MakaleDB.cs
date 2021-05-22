namespace MakaleModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MakaleDB : DbContext
    {
        public MakaleDB()
            : base("name=MakaleDB")
        {
        }

        public virtual DbSet<Bolum> Bolum { get; set; }
        public virtual DbSet<Dergi> Dergi { get; set; }
        public virtual DbSet<Endeks> Endeks { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<MakaleKategori> MakaleKategori { get; set; }
        public virtual DbSet<MakaleTur> MakaleTur { get; set; }
        public virtual DbSet<MakaleYazar> MakaleYazar { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MakaleTur>()
                .HasMany(e => e.Makale)
                .WithOptional(e => e.MakaleTur)
                .HasForeignKey(e => e.MakaleTuruNo);
        }
    }
}
