using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("Corporation")]
    public partial class Corporation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corporation()
        {
            BidCorporations = new HashSet<BidCorporation>();
            CarCorporations = new HashSet<CarCorporation>();
            CorporationUsers = new HashSet<CorporationUser>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        public int AddressInfoId { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int CorporationTypeId { get; set; }

        public short CorporatePackageTypeId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCorporation> BidCorporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCorporation> CarCorporations { get; set; }

        public virtual CorporatePackageType CorporatePackageType { get; set; }

        public virtual CorporationType CorporationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporationUser> CorporationUsers { get; set; }
    }
}
