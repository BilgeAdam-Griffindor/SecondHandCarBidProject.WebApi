using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarBidProject.Entities.Entities
{


    [Table("BaseUser")]
    public partial class BaseUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseUser()
        {
            AdvertFavorites = new HashSet<AdvertFavorite>();
            AdvertInfoes = new HashSet<AdvertInfo>();
            AdvertInfoes1 = new HashSet<AdvertInfo>();
            BaseUser1 = new HashSet<BaseUser>();
            BaseUser11 = new HashSet<BaseUser>();
            BaseUser12 = new HashSet<BaseUser>();
            Bids = new HashSet<Bid>();
            Bids1 = new HashSet<Bid>();
            Bids2 = new HashSet<Bid>();
            BidAdditionlFees = new HashSet<BidAdditionlFee>();
            BidAdditionlFees1 = new HashSet<BidAdditionlFee>();
            BidCars = new HashSet<BidCar>();
            BidCars1 = new HashSet<BidCar>();
            BidCorporations = new HashSet<BidCorporation>();
            BidCorporations1 = new HashSet<BidCorporation>();
            BidOffers = new HashSet<BidOffer>();
            BidOffers1 = new HashSet<BidOffer>();
            BidOffers2 = new HashSet<BidOffer>();
            BidResults = new HashSet<BidResult>();
            BidResults1 = new HashSet<BidResult>();
            BidStatusHistories = new HashSet<BidStatusHistory>();
            Cars = new HashSet<Car>();
            Cars1 = new HashSet<Car>();
            CarBuys = new HashSet<CarBuy>();
            CarBuys1 = new HashSet<CarBuy>();
            CarBuyAdditionalFees = new HashSet<CarBuyAdditionalFee>();
            CarBuyAdditionalFees1 = new HashSet<CarBuyAdditionalFee>();
            CarBuyStatusHistories = new HashSet<CarBuyStatusHistory>();
            CarCarProperties = new HashSet<CarCarProperty>();
            CarCarProperties1 = new HashSet<CarCarProperty>();
            CarCorporations = new HashSet<CarCorporation>();
            CarCorporations1 = new HashSet<CarCorporation>();
            CarFavorites = new HashSet<CarFavorite>();
            CarFavorites1 = new HashSet<CarFavorite>();
            CarFavorites2 = new HashSet<CarFavorite>();
            CarSoldToes = new HashSet<CarSoldTo>();
            CarSoldToes1 = new HashSet<CarSoldTo>();
            CarSoldToes2 = new HashSet<CarSoldTo>();
            CarStatusHistories = new HashSet<CarStatusHistory>();
            CommissionFees = new HashSet<CommissionFee>();
            CommissionFees1 = new HashSet<CommissionFee>();
            Corporations = new HashSet<Corporation>();
            Corporations1 = new HashSet<Corporation>();
            CorporationUsers = new HashSet<CorporationUser>();
            CorporationUsers1 = new HashSet<CorporationUser>();
            CorporationUsers2 = new HashSet<CorporationUser>();
            ExpertInfoes = new HashSet<ExpertInfo>();
            ExpertInfoes1 = new HashSet<ExpertInfo>();
            FavoriteUserSearches = new HashSet<FavoriteUserSearch>();
            NotaryFees = new HashSet<NotaryFee>();
            NotaryFees1 = new HashSet<NotaryFee>();
            NotificationMessages = new HashSet<NotificationMessage>();
            NotificationMessageUsers = new HashSet<NotificationMessageUser>();
            NotificationMessageUsers1 = new HashSet<NotificationMessageUser>();
            RolePageActionAuths = new HashSet<RolePageActionAuth>();
            RolePageActionAuths1 = new HashSet<RolePageActionAuth>();
            TrafficInsurances = new HashSet<TrafficInsurance>();
            TrafficInsurances1 = new HashSet<TrafficInsurance>();
            TrafficInsuranceTrafficInsuranceCarComponents = new HashSet<TrafficInsuranceTrafficInsuranceCarComponent>();
            TrafficInsuranceTrafficInsuranceCarComponents1 = new HashSet<TrafficInsuranceTrafficInsuranceCarComponent>();
            UserAutoBids = new HashSet<UserAutoBid>();
            UserAutoBids1 = new HashSet<UserAutoBid>();
            UserAutoBids2 = new HashSet<UserAutoBid>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(150)]
        public string PasswordSalt { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int AddressInfoId { get; set; }

        public bool IsApproved { get; set; }

        public Guid? ApprovedBy { get; set; }

        public bool EmailVerified { get; set; }

        public bool IsCorporate { get; set; }

        public bool KVKKChecked { get; set; }

        public short? RoleTypeId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertFavorite> AdvertFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertInfo> AdvertInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertInfo> AdvertInfoes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseUser> BaseUser1 { get; set; }

        public virtual BaseUser BaseUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseUser> BaseUser11 { get; set; }

        public virtual BaseUser BaseUser3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseUser> BaseUser12 { get; set; }

        public virtual BaseUser BaseUser4 { get; set; }

        public virtual RoleType RoleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidAdditionlFee> BidAdditionlFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidAdditionlFee> BidAdditionlFees1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCar> BidCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCar> BidCars1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCorporation> BidCorporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidCorporation> BidCorporations1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidOffer> BidOffers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidOffer> BidOffers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidOffer> BidOffers2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidResult> BidResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidResult> BidResults1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BidStatusHistory> BidStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuy> CarBuys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuy> CarBuys1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyAdditionalFee> CarBuyAdditionalFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyAdditionalFee> CarBuyAdditionalFees1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarBuyStatusHistory> CarBuyStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCarProperty> CarCarProperties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCarProperty> CarCarProperties1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCorporation> CarCorporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarCorporation> CarCorporations1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFavorite> CarFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFavorite> CarFavorites1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFavorite> CarFavorites2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSoldTo> CarSoldToes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSoldTo> CarSoldToes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSoldTo> CarSoldToes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarStatusHistory> CarStatusHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionFee> CommissionFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommissionFee> CommissionFees1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporation> Corporations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporation> Corporations1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporationUser> CorporationUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporationUser> CorporationUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporationUser> CorporationUsers2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertInfo> ExpertInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertInfo> ExpertInfoes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteUserSearch> FavoriteUserSearches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotaryFee> NotaryFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotaryFee> NotaryFees1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificationMessage> NotificationMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificationMessageUser> NotificationMessageUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificationMessageUser> NotificationMessageUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolePageActionAuth> RolePageActionAuths { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolePageActionAuth> RolePageActionAuths1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsurance> TrafficInsurances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsurance> TrafficInsurances1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAutoBid> UserAutoBids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAutoBid> UserAutoBids1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAutoBid> UserAutoBids2 { get; set; }
    }
}
