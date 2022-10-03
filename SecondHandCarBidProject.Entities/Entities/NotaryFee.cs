using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("NotaryFee")]
    public partial class NotaryFee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NotaryFee()
        {
            BidAdditionlFees = new HashSet<BidAdditionlFee>();
            CarBuyAdditionalFees = new HashSet<CarBuyAdditionalFee>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "money")]
        public decimal FeeAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidAdditionlFee> BidAdditionlFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyAdditionalFee> CarBuyAdditionalFees { get; set; }
    }
}
