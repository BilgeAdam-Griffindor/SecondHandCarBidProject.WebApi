using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("TrafficInsurance")]
    public partial class TrafficInsurance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrafficInsurance()
        {
            TrafficInsuranceTrafficInsuranceCarComponents = new HashSet<TrafficInsuranceTrafficInsuranceCarComponent>();
        }

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        [Required]
        [StringLength(100)]
        public string Cost { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual Car Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents { get; set; }
    }
}
