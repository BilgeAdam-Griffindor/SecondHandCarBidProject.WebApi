using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    public partial class CarImage
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        [Column("CarImage", TypeName = "image")]
        [Required]
        public byte[] CarImage1 { get; set; }

        public bool IsActive { get; set; }

        public virtual Car Car { get; set; }
    }
}
