using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("BidAdditionlFee")]
    public partial class BidAdditionlFee
    {
        public Guid Id { get; set; }

        public Guid BidId { get; set; }

        public Guid NotaryFeeId { get; set; }

        public Guid CommissionFeeId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual CommissionFee CommissionFee { get; set; }

        public virtual NotaryFee NotaryFee { get; set; }
    }
}
