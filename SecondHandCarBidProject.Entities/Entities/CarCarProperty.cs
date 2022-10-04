using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{

    [Table("CarCarProperty")]
    public partial class CarCarProperty
    {
        [Key]
        [Column(Order = 0)]
        public Guid CarId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CarPropertyValueId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarPropertyValue CarPropertyValue { get; set; }
    }
}
