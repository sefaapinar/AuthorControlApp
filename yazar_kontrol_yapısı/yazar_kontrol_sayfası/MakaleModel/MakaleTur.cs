namespace MakaleModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MakaleTur")]
    public partial class MakaleTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MakaleTur()
        {
            Makale = new HashSet<Makale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makale { get; set; }
    }
}
