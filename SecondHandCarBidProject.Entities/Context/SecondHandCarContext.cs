using Microsoft.EntityFrameworkCore;
using SecondHandCarBidProject.Entities.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace SecondHandCarBidProject.Entities.Context
{
    public partial class SecondHandCarContext : DbContext
    {
        public SecondHandCarContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<ActionAuthType> ActionAuthTypes { get; set; }
        public virtual DbSet<AddressInfo> AddressInfoes { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<AdvertFavorite> AdvertFavorites { get; set; }
        public virtual DbSet<AdvertInfo> AdvertInfoes { get; set; }
        public virtual DbSet<BaseUser> BaseUsers { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<BidAdditionlFee> BidAdditionlFees { get; set; }
        public virtual DbSet<BidCar> BidCars { get; set; }
        public virtual DbSet<BidCorporation> BidCorporations { get; set; }
        public virtual DbSet<BidOffer> BidOffers { get; set; }
        public virtual DbSet<BidResult> BidResults { get; set; }
        public virtual DbSet<BidStatusHistory> BidStatusHistories { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarBuy> CarBuys { get; set; }
        public virtual DbSet<CarBuyAdditionalFee> CarBuyAdditionalFees { get; set; }
        public virtual DbSet<CarBuyHistory> CarBuyHistories { get; set; }
        public virtual DbSet<CarCarProperty> CarCarProperties { get; set; }
        public virtual DbSet<CarCorporation> CarCorporations { get; set; }
        public virtual DbSet<CarFavorite> CarFavorites { get; set; }
        public virtual DbSet<CarImage> CarImages { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarPropertyValue> CarPropertyValues { get; set; }
        public virtual DbSet<CarSoldTo> CarSoldToes { get; set; }
        public virtual DbSet<CarStatusHistory> CarStatusHistories { get; set; }
        public virtual DbSet<CommissionFee> CommissionFees { get; set; }
        public virtual DbSet<CorporatePackageType> CorporatePackageTypes { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<CorporationType> CorporationTypes { get; set; }
        public virtual DbSet<CorporationUser> CorporationUsers { get; set; }
        public virtual DbSet<ExpertInfo> ExpertInfoes { get; set; }
        public virtual DbSet<FavoriteUserSearch> FavoriteUserSearches { get; set; }
        public virtual DbSet<NotaryFee> NotaryFees { get; set; }
        public virtual DbSet<NotificationMessage> NotificationMessages { get; set; }
        public virtual DbSet<NotificationMessageUser> NotificationMessageUsers { get; set; }
        public virtual DbSet<PageAuthType> PageAuthTypes { get; set; }
        public virtual DbSet<RolePageActionAuth> RolePageActionAuths { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<StatusValue> StatusValues { get; set; }
        public virtual DbSet<TrafficInsurance> TrafficInsurances { get; set; }
        public virtual DbSet<TrafficInsuranceCarComponent> TrafficInsuranceCarComponents { get; set; }
        public virtual DbSet<TrafficInsuranceTrafficInsuranceCarComponent> TrafficInsuranceTrafficInsuranceCarComponents { get; set; }
        public virtual DbSet<UserAutoBid> UserAutoBids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionAuthType>()
                .HasMany(e => e.RolePageActionAuths)
                .WithOne(e => e.ActionAuthType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<AddressInfo>()
                .HasMany(e => e.AddressInfo1)
                .WithOne(e => e.AddressInfo2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.TopAddressInfoId);

            modelBuilder.Entity<AddressInfo>()
                .HasMany(e => e.Corporations)
                .WithOne(e => e.AddressInfo).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<AddressInfo>()
                .HasMany(e => e.ExpertInfoes)
                .WithOne(e => e.AddressInfo).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<AdvertInfo>()
                .HasMany(e => e.AdvertFavorites)
                .WithOne(e => e.AdvertInfo).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.AdvertFavorites)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.AdvertInfoes)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.AdvertInfoes1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BaseUser1)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ApprovedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BaseUser11)
                .WithOne(e => e.BaseUser3).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BaseUser12)
                .WithOne(e => e.BaseUser4).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Bids)
                .WithOne(e => e.BaseUser).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ApproverAdminId);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Bids1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Bids2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidAdditionlFees)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidAdditionlFees1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidCars)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidCars1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidCorporations)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidCorporations1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidOffers)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidOffers1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidOffers2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidResults)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidResults1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.BidStatusHistories)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Cars)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Cars1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarBuys)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarBuys1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarBuyAdditionalFees)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarBuyAdditionalFees1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarBuyHistories)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarCarProperties)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarCarProperties1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarCorporations)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarCorporations1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarFavorites)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarFavorites1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarFavorites2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarSoldToes)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.SoldToBaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarSoldToes1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarSoldToes2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CarStatusHistories)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CommissionFees)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CommissionFees1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Corporations)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.Corporations1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CorporationUsers)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CorporationUsers1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.CorporationUsers2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.ExpertInfoes)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.ExpertInfoes1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.FavoriteUserSearches)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.NotaryFees)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.NotaryFees1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.NotificationMessages)
                .WithOne(e => e.BaseUser).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.NotificationMessageUsers)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.SendToBaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.NotificationMessageUsers1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.RolePageActionAuths)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.RolePageActionAuths1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.TrafficInsurances)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.TrafficInsurances1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.TrafficInsuranceTrafficInsuranceCarComponents)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.TrafficInsuranceTrafficInsuranceCarComponents1)
                .WithOne(e => e.BaseUser1).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.UserAutoBids)
                .WithOne(e => e.BaseUser).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BaseUserId);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.UserAutoBids1)
                .WithOne(e => e.BaseUser1).IsRequired().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CreatedBy);


            modelBuilder.Entity<BaseUser>()
                .HasMany(e => e.UserAutoBids2)
                .WithOne(e => e.BaseUser2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidAdditionlFees)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidCars)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidCorporations)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidOffers)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Bid>()
                .HasMany(e => e.BidStatusHistories)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Bid>()
                .HasMany(e => e.UserAutoBids)
                .WithOne(e => e.Bid).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BidCar>()
                .Property(e => e.BidStartPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BidCar>()
                .Property(e => e.MinimumBuyPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BidOffer>()
                .Property(e => e.OfferAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BidOffer>()
                .HasMany(e => e.BidResults)
                .WithOne(e => e.BidOffer).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.AdvertInfoes)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.BidCars)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarBuys)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarCarProperties)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarCorporations)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarFavorites)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarImages)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarSoldToes)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarStatusHistories)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Car>()
                .HasMany(e => e.TrafficInsurances)
                .WithOne(e => e.Car).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarBrand>()
                .HasMany(e => e.Cars)
                .WithOne(e => e.CarBrand).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarBrand>()
                .HasMany(e => e.CarModels)
                .WithOne(e => e.CarBrand).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarBuy>()
                .Property(e => e.PreValuationPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CarBuy>()
                .Property(e => e.BidPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CarBuy>()
                .HasMany(e => e.CarBuyAdditionalFees)
                .WithOne(e => e.CarBuy).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarBuy>()
                .HasMany(e => e.CarBuyHistories)
                .WithOne(e => e.CarBuy).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarModel>()
                .HasMany(e => e.Cars)
                .WithOne(e => e.CarModel).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarPropertyValue>()
                .HasMany(e => e.CarCarProperties)
                .WithOne(e => e.CarPropertyValue).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CarPropertyValue>()
                .HasMany(e => e.CarPropertyValue1)
                .WithOne(e => e.CarPropertyValue2).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.TopPropertyValueId);

            modelBuilder.Entity<CarSoldTo>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CommissionFee>()
                .Property(e => e.FeeAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CommissionFee>()
                .Property(e => e.MinPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CommissionFee>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CommissionFee>()
                .HasMany(e => e.BidAdditionlFees)
                .WithOne(e => e.CommissionFee).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CommissionFee>()
                .HasMany(e => e.CarBuyAdditionalFees)
                .WithOne(e => e.CommissionFee).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CorporatePackageType>()
                .HasMany(e => e.Corporations)
                .WithOne(e => e.CorporatePackageType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Corporation>()
                .HasMany(e => e.BidCorporations)
                .WithOne(e => e.Corporation).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Corporation>()
                .HasMany(e => e.CarCorporations)
                .WithOne(e => e.Corporation).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Corporation>()
                .HasMany(e => e.CorporationUsers)
                .WithOne(e => e.Corporation).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CorporationType>()
                .HasMany(e => e.Corporations)
                .WithOne(e => e.CorporationType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ExpertInfo>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<ExpertInfo>()
                .Property(e => e.Latitude)
                .HasPrecision(8, 6);

            modelBuilder.Entity<NotaryFee>()
                .Property(e => e.FeeAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NotaryFee>()
                .HasMany(e => e.BidAdditionlFees)
                .WithOne(e => e.NotaryFee).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<NotaryFee>()
                .HasMany(e => e.CarBuyAdditionalFees)
                .WithOne(e => e.NotaryFee).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<NotificationMessage>()
                .HasMany(e => e.NotificationMessageUsers)
                .WithOne(e => e.NotificationMessage).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<PageAuthType>()
                .HasMany(e => e.RolePageActionAuths)
                .WithOne(e => e.PageAuthType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<RoleType>()
                .HasMany(e => e.RolePageActionAuths)
                .WithOne(e => e.RoleType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StatusType>()
                .HasMany(e => e.StatusValues)
                .WithOne(e => e.StatusType).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StatusValue>()
                .HasMany(e => e.BidStatusHistories)
                .WithOne(e => e.StatusValue).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StatusValue>()
                .HasMany(e => e.CarBuyHistories)
                .WithOne(e => e.StatusValue).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StatusValue>()
                .HasMany(e => e.CarStatusHistories)
                .WithOne(e => e.StatusValue).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StatusValue>()
                .HasMany(e => e.TrafficInsuranceTrafficInsuranceCarComponents)
                .WithOne(e => e.StatusValue).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TrafficInsurance>()
                .HasMany(e => e.TrafficInsuranceTrafficInsuranceCarComponents)
                .WithOne(e => e.TrafficInsurance).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TrafficInsuranceCarComponent>()
                .HasMany(e => e.TrafficInsuranceTrafficInsuranceCarComponents)
                .WithOne(e => e.TrafficInsuranceCarComponent).IsRequired().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<UserAutoBid>()
                .Property(e => e.MaximumOffer)
                .HasPrecision(19, 4);

            modelBuilder.Entity<UserAutoBid>()
                .Property(e => e.IncrementAmount)
                .HasPrecision(19, 4);
        }
    }
}
