using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("TrafficInsuranceTrafficInsuranceCarComponent")]
    public partial class TrafficInsuranceTrafficInsuranceCarComponent
    {
        [Key]
        [Column(Order = 0)]
        public Guid TrafficInsuranceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TrafficInsuranceCarComponentId { get; set; }

        public int StatusValueId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual StatusValue StatusValue { get; set; }

        public virtual TrafficInsurance TrafficInsurance { get; set; }

        public virtual TrafficInsuranceCarComponent TrafficInsuranceCarComponent { get; set; }
    }
}
