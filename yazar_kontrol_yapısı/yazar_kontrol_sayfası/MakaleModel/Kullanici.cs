namespace MakaleModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            MakaleYazar = new HashSet<MakaleYazar>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Soyad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        [StringLength(100)]
        public string Cinsiyet { get; set; }

        [StringLength(100)]
        public string Eposta { get; set; }

        [StringLength(100)]
        public string TcKimlikNo { get; set; }

        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [StringLength(100)]
        public string Parola { get; set; }

        public int? UnvanNo { get; set; }

        public int? BolumNo { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual Unvan Unvan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MakaleYazar> MakaleYazar { get; set; }
    }
}
