using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("BidStatusHistory")]
    public partial class BidStatusHistory
    {
        public Guid Id { get; set; }

        public Guid BidId { get; set; }

        public int StatusValueId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Explanation { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual StatusValue StatusValue { get; set; }
    }
}
