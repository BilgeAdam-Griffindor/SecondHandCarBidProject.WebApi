using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("NotificationMessage")]
    public partial class NotificationMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NotificationMessage()
        {
            NotificationMessageUsers = new HashSet<NotificationMessageUser>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string Content { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificationMessageUser> NotificationMessageUsers { get; set; }
    }
}
