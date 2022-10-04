using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("ExpertInfo")]
    public partial class ExpertInfo
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CentreName { get; set; }

        public int AddressInfoId { get; set; }

        [StringLength(200)]
        public string ExpertAddress { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }
    }
}
