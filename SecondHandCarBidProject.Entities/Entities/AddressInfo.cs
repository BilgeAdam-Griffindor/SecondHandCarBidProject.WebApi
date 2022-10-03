using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("AddressInfo")]
    public partial class AddressInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressInfo()
        {
            AddressInfo1 = new HashSet<AddressInfo>();
            Corporations = new HashSet<Corporation>();
            ExpertInfoes = new HashSet<ExpertInfo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressName { get; set; }

        public int? TopAddressInfoId { get; set; }

        public int? AddressTypeId { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressInfo> AddressInfo1 { get; set; }

        public virtual AddressInfo AddressInfo2 { get; set; }

        public virtual AddressType AddressType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporation> Corporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertInfo> ExpertInfoes { get; set; }
    }
}
