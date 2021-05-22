namespace MakaleModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }

        [StringLength(100)]
        public string IP { get; set; }
        public string Ip { get; set; }
        [StringLength(100)]
        public string Tarayici { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(100)]
        public string Metot { get; set; }

        [StringLength(100)]
        public string Parametre { get; set; }

        public int? KullaniciNumara { get; set; }
        public string MetotAdi { get; set; }
    }
}
