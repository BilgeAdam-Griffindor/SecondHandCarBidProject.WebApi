using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{

    [Table("AdvertFavorite")]
    public partial class AdvertFavorite
    {
        [Key]
        [Column(Order = 0)]
        public Guid BaseUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid AdvertInfoId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual AdvertInfo AdvertInfo { get; set; }

        public virtual BaseUser BaseUser { get; set; }
    }
}
