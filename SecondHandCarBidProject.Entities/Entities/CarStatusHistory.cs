using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("CarStatusHistory")]
    public partial class CarStatusHistory
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public int StatusValueId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Explanation { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual Car Car { get; set; }

        public virtual StatusValue StatusValue { get; set; }
    }
}
