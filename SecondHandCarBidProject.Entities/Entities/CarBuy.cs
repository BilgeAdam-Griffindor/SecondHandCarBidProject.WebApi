using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("CarBuy")]
    public partial class CarBuy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarBuy()
        {
            CarBuyAdditionalFees = new HashSet<CarBuyAdditionalFee>();
            CarBuyStatusHistories = new HashSet<CarBuyStatusHistory>();
        }

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        [Column(TypeName = "money")]
        public decimal? PreValuationPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? BidPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual Car Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyAdditionalFee> CarBuyAdditionalFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyStatusHistory> CarBuyStatusHistories { get; set; }
    }
}
