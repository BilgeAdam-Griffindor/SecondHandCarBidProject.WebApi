using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("CarBuyHistory")]
    public partial class CarBuyHistory
    {
        public Guid Id { get; set; }

        public Guid CarBuyId { get; set; }

        public int StatusValueId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual CarBuy CarBuy { get; set; }

        public virtual StatusValue StatusValue { get; set; }
    }
}
