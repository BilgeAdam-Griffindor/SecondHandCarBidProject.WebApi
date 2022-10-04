using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("CorporatePackageType")]
    public partial class CorporatePackageType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CorporatePackageType()
        {
            Corporations = new HashSet<Corporation>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PackageName { get; set; }

        public short? CountOfBids { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporation> Corporations { get; set; }
    }
}
