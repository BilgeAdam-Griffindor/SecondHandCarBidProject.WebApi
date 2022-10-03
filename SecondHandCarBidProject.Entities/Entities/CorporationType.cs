using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("CorporationType")]
    public partial class CorporationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CorporationType()
        {
            Corporations = new HashSet<Corporation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CorporationTypeName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporation> Corporations { get; set; }
    }
}
