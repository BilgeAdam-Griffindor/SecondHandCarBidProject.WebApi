using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("TrafficInsuranceCarComponent")]
    public partial class TrafficInsuranceCarComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrafficInsuranceCarComponent()
        {
            TrafficInsuranceTrafficInsuranceCarComponents = new HashSet<TrafficInsuranceTrafficInsuranceCarComponent>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ComponentName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents { get; set; }
    }
}
