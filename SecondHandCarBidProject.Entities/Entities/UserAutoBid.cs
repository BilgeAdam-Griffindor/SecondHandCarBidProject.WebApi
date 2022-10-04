using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("UserAutoBid")]
    public partial class UserAutoBid
    {
        public Guid Id { get; set; }

        [Column(TypeName = "money")]
        public decimal MaximumOffer { get; set; }

        [Column(TypeName = "money")]
        public decimal IncrementAmount { get; set; }

        public Guid BaseUserId { get; set; }

        public Guid BidId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual BaseUser BaseUser2 { get; set; }

        public virtual Bid Bid { get; set; }
    }
}
