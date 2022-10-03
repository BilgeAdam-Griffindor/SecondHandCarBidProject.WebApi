using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("Bid")]
    public partial class Bid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bid()
        {
            BidAdditionlFees = new HashSet<BidAdditionlFee>();
            BidCars = new HashSet<BidCar>();
            BidCorporations = new HashSet<BidCorporation>();
            BidOffers = new HashSet<BidOffer>();
            BidStatusHistories = new HashSet<BidStatusHistory>();
            UserAutoBids = new HashSet<UserAutoBid>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BidName { get; set; }

        public bool IsCorporate { get; set; }

        [Column(TypeName = "date")]
        public DateTime BidStartDate { get; set; }

        public TimeSpan BidStartTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime BidEndDate { get; set; }

        public TimeSpan BidEndTime { get; set; }

        public bool IsApproved { get; set; }

        public Guid? ApproverAdminId { get; set; }

        public DateTime? VerificationDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual BaseUser BaseUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidAdditionlFee> BidAdditionlFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCar> BidCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCorporation> BidCorporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidOffer> BidOffers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidStatusHistory> BidStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAutoBid> UserAutoBids { get; set; }
    }
}
