using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("StatusValue")]
    public partial class StatusValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusValue()
        {
            BidStatusHistories = new HashSet<BidStatusHistory>();
            CarBuyStatusHistories = new HashSet<CarBuyStatusHistory>();
            CarStatusHistories = new HashSet<CarStatusHistory>();
            TrafficInsuranceTrafficInsuranceCarComponents = new HashSet<TrafficInsuranceTrafficInsuranceCarComponent>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }

        public int StatusTypeId { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidStatusHistory> BidStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyStatusHistory> CarBuyStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarStatusHistory> CarStatusHistories { get; set; }

        public virtual StatusType StatusType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents { get; set; }
    }
}
