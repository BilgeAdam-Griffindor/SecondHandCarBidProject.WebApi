using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("CarPropertyValue")]
    public partial class CarPropertyValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarPropertyValue()
        {
            CarCarProperties = new HashSet<CarCarProperty>();
            CarPropertyValue1 = new HashSet<CarPropertyValue>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyValue { get; set; }

        public Guid? TopPropertyValueId { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCarProperty> CarCarProperties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPropertyValue> CarPropertyValue1 { get; set; }

        public virtual CarPropertyValue CarPropertyValue2 { get; set; }
    }
}
