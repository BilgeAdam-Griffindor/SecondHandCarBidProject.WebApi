using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            AdvertInfoes = new HashSet<AdvertInfo>();
            BidCars = new HashSet<BidCar>();
            CarBuys = new HashSet<CarBuy>();
            CarCarProperties = new HashSet<CarCarProperty>();
            CarCorporations = new HashSet<CarCorporation>();
            CarFavorites = new HashSet<CarFavorite>();
            CarImages = new HashSet<CarImage>();
            CarSoldToes = new HashSet<CarSoldTo>();
            CarStatusHistories = new HashSet<CarStatusHistory>();
            TrafficInsurances = new HashSet<TrafficInsurance>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Kilometre { get; set; }

        public short CarYear { get; set; }

        public bool IsCorporate { get; set; }

        [Required]
        [StringLength(1000)]
        public string CarDescription { get; set; }

        public short CarBrandId { get; set; }

        public int CarModelId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertInfo> AdvertInfoes { get; set; }

        public virtual BaseUser BaseUser { get; set; }

        public virtual BaseUser BaseUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCar> BidCars { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public virtual CarModel CarModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuy> CarBuys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCarProperty> CarCarProperties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCorporation> CarCorporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFavorite> CarFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarImage> CarImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSoldTo> CarSoldToes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarStatusHistory> CarStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsurance> TrafficInsurances { get; set; }
    }
}
