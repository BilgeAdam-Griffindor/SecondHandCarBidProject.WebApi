using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("NotificationMessageUser")]
    public partial class NotificationMessageUser
    {
        public Guid Id { get; set; }

        public int NotificationMessageId { get; set; }

        public Guid SendToBaseUserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        public virtual NotificationMessage NotificationMessage { get; set; }
    }
}
