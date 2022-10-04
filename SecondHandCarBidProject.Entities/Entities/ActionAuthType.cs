using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{
    [Table("ActionAuthType")]
    public partial class ActionAuthType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActionAuthType()
        {
            RolePageActionAuths = new HashSet<RolePageActionAuth>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AuthorizationName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolePageActionAuth> RolePageActionAuths { get; set; }
    }
}
