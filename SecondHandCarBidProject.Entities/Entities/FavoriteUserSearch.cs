using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    public partial class FavoriteUserSearch
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SearchText { get; set; }

        public Guid BaseUserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual BaseUser BaseUser { get; set; }
    }
}
