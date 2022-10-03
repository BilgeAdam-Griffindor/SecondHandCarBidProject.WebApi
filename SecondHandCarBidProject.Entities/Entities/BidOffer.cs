using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("BidOffer")]
    public partial class BidOffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BidOffer()
        {
            BidResults = new HashSet<BidResult>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "money")]
        public decimal OfferAmount { get; set; }

        public Guid BaseUserId { get; set; }

        public Guid BidId { get; set; }

        [Required]
        public string Explanation { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual BaseUser BaseUser2 { get; set; }

        public virtual Bid Bid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidResult> BidResults { get; set; }
    }
}
