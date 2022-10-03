using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("CarCorporation")]
    public partial class CarCorporation
    {
        [Key]
        [Column(Order = 0)]
        public Guid CarId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CorporationId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual Car Car { get; set; }

        public virtual Corporation Corporation { get; set; }
    }
}
