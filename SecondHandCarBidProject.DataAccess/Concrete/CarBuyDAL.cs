using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidOffer;
using SecondHandCarBidProject.Common.DTOs.CarBuy;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class CarBuyDAL : ICarBuyDAL
    {
        private readonly DapperContext _context;

        public CarBuyDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CarDetailAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var brandQuery = @"SELECT Id, BrandName as Name FROM CarBrand";
                    var brandResult = await connection.QueryAsync<IdNameListDTO>(brandQuery);
                    List<IdNameListDTO> brandList = brandResult.ToList();

                    var modelQuery = @"SELECT Id, ModelName as Name FROM CarModel";
                    var modelResult = await connection.QueryAsync<IdNameListDTO>(modelQuery);
                    List<IdNameListDTO> modelList = modelResult.ToList();

                    var statusValueQuery = "SELECT Id, StatusName as Name FROM StatusValue WHERE StatusTypeId = 3";
                    var statusValueResult = await connection.QueryAsync<IdNameListDTO>(statusValueQuery);
                    List<IdNameListDTO> statusValueList = statusValueResult.ToList();

                    var corporationQuery = @"SELECT Id, CompanyName as Name FROM Corporation ORDER BY CompanyName";
                    var corporationResult = await connection.QueryAsync<IdNameListDTO>(corporationQuery);
                    List<IdNameListDTO> corporationList = corporationResult.ToList();

                    //var bodyQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'BodyType')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var bodyResult = await connection.QueryAsync<IdNameListDTO>(bodyQuery);
                    //List<IdNameListDTO> bodyList = bodyResult.ToList();

                    //var fuelQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'FuelType')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var fuelResult = await connection.QueryAsync<IdNameListDTO>(fuelQuery);
                    //List<IdNameListDTO> fuelList = fuelResult.ToList();

                    //var gearQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'GearType')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var gearResult = await connection.QueryAsync<IdNameListDTO>(gearQuery);
                    //List<IdNameListDTO> gearList = gearResult.ToList();

                    //var versionQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'Version')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var versionResult = await connection.QueryAsync<IdNameListDTO>(versionQuery);
                    //List<IdNameListDTO> versionList = versionResult.ToList();

                    //var colorQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'Color')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var colorResult = await connection.QueryAsync<IdNameListDTO>(colorQuery);
                    //List<IdNameListDTO> colorList = colorResult.ToList();

                    //var optionalHardwareQuery = @"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = 'OptionalHardware')
                    // SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
                    //var optionalHardwareResult = await connection.QueryAsync<IdNameListDTO>(optionalHardwareQuery);
                    //List<IdNameListDTO> optionalHardwareList = optionalHardwareResult.ToList();

                    CarDetailAddPageDTO responseDTO = new CarDetailAddPageDTO(
                        brandList,
                        modelList,
                        statusValueList,
                        corporationList,
                        CarPropertyListByType(connection, "BodyType").Result,
                        CarPropertyListByType(connection, "FuelType").Result,
                        CarPropertyListByType(connection, "GearType").Result,
                        CarPropertyListByType(connection, "Version").Result,
                        CarPropertyListByType(connection, "Color").Result,
                        CarPropertyListByType(connection, "OptionalHardware").Result);

                    return new ResponseModel<CarDetailAddPageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarDetailAddPageDTO>()
                {
                    Data = new CarDetailAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(CarBuyAddSendDTO dto)
        {
            try
            {
                var query = @"BEGIN TRAN
	                BEGIN TRY
		                IF(@isCorporate = 1 AND @corporationId IS NULL)
		                BEGIN
			                RAISERROR('Kurumsal araçlar için kurum seçilmesi zorunludur.', 16, 1);
		                END
		
		                declare @newCarId uniqueidentifier = NEWID()

		                INSERT INTO Car(Id, Price, Kilometre, CarYear, IsCorporate, CarDescription, CarBrandId, CarModelId, CreatedBy) VALUES
		                (@newCarId, @price, @kilometre, @carYear, @isCorporate, @carDescription, @brandId, @modelId, @createdBy)

		                INSERT INTO CarStatusHistory(Id, CarId, StatusValueId, Explanation, CreatedBy) VALUES
		                (NEWID(), @newCarId, @statusId, N'İlk Kayıt', @createdBy)

		                INSERT INTO CarCarProperty(CarId, CarPropertyValueId, CreatedBy) SELECT @newCarId, Id, @createdBy FROM @propertyList

		                INSERT INTO CarImages(Id, CarId, CarImage) SELECT NEWID(), @newCarId, Picture FROM @pictures

		                IF(@isCorporate = 1)
		                BEGIN
			                INSERT INTO CarCorporation(CarId, CorporationId, CreatedBy) VALUES(@newCarId, @corporationId, @createdBy)
		                END

		                --difference from CarAdd procedure
		                INSERT INTO CarBuy(Id, CarId, CreatedBy) VALUES(NEWID(), @newCarId, @createdBy)
		
		                COMMIT TRAN
	                END TRY
	                BEGIN CATCH
		                ROLLBACK TRAN
		                RAISERROR('İşlem Başarısız', 16, 1)
	                END CATCH";

                List<Guid> fullPropertyList = new List<Guid>();
                fullPropertyList.Add(dto.BodyTypeId);
                fullPropertyList.Add(dto.ColorId);
                fullPropertyList.Add(dto.FuelTypeId);
                fullPropertyList.Add(dto.GearTypeId);
                fullPropertyList.Add(dto.VersionId);
                fullPropertyList.AddRange(dto.OptionalHardwareIds);

                //TODO Remove unnecesary values, fix statusId
                var parameters = new { price = 0, kilometre = dto.Kilometre, carYear = dto.CarYear, isCorporate = false, carDescription = dto.CarDescription, brandId = dto.CarBrandId, modelId = dto.CarModelId, statusId = 14, propertyList = fullPropertyList, pictures = dto.CarImages, createdBy = dto.CreatedBy };

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy)
        {
            try
            {
                var query = @"BEGIN TRAN
	                BEGIN TRY
		                DELETE FROM CarBuy where Id = @id

		                UPDATE CarBuy SET ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id

		                COMMIT TRAN
	                END TRY
	                BEGIN CATCH
		                ROLLBACK TRAN
		                RAISERROR('İşlem Başarısız', 16, 1)
	                END CATCH";
                var parameters = new { id = id, modifiedBy = modifiedBy };
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<CarBuyListPageDTO>> List(short? brandId = null, int? modelId = null, int? statusId = null, int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT cbsh.Id, cBr.BrandName, cm.ModelName, cb.PreValuationPrice, cb.BidPrice, sv.StatusName, bu.Username as CarOwner, cbsh.Explanation, cbsh.CreatedDate
	                FROM CarBuy cb 
	                JOIN CarBuyStatusHistory cbsh on cb.Id = cbsh.CarBuyId
	                JOIN Car c on cb.CarId = c.Id
	                JOIN CarBrand cBr on c.CarBrandId = cBr.Id
	                JOIN CarModel cm on c.CarModelId = cm.Id
	                JOIN BaseUser bu on c.CreatedBy = bu.Id
	                JOIN StatusValue sv on cbsh.StatusValueId = sv.Id
	                WHERE cbsh.Id = (SELECT TOP 1 Id FROM CarBuyStatusHistory WHERE CarBuyId = cb.Id AND IsActive = 1 ORDER BY CreatedDate DESC) AND cbsh.IsActive = 1
	                AND (@brandId is null or c.CarBrandId = @brandId)
	                AND (@modelId is null or c.CarModelId = @modelId)
	                AND (@statusId is null or c.CarBrandId = @statusId)
	                ORDER BY cbsh.CreatedDate DESC
	                OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY";
                var parameters = new { brandId = brandId, modelId = modelId, statusId = statusId, page = page, itemPerPage = itemPerPage };
                using (var connection = _context.CreateConnection())
                {
                    var brandQuery = @"SELECT Id, BrandName as Name FROM CarBrand";
                    var brandResult = await connection.QueryAsync<IdNameListDTO>(brandQuery);
                    List<IdNameListDTO> brandList = brandResult.ToList();

                    var modelQuery = @"SELECT Id, ModelName as Name FROM CarModel";
                    var modelResult = await connection.QueryAsync<IdNameListDTO>(modelQuery);
                    List<IdNameListDTO> modelList = modelResult.ToList();

                    var statusValueQuery = "SELECT Id, StatusName as Name FROM StatusValue WHERE StatusTypeId = 3";
                    var statusValueResult = await connection.QueryAsync<IdNameListDTO>(statusValueQuery);
                    List<IdNameListDTO> statusValueList = statusValueResult.ToList();

                    var carBuyResult = await connection.QueryAsync<CarBuyListTableRowDTO>(query, parameters);
                    List<CarBuyListTableRowDTO> carBuyList = carBuyResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BidOffer"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    CarBuyListPageDTO responseDTO = new CarBuyListPageDTO(brandList, modelList, statusValueList, carBuyList, maxPage);

                    return new ResponseModel<CarBuyListPageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBuyListPageDTO>()
                {
                    Data = new CarBuyListPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<CarBuyListTableRowDTO>(), 0),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<CarBuyUpdatePageDTO>> UpdateGet(Guid id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = @"select cb.Id, cb.CarId, bu.Username, cb.PreValuationPrice, cb.BidPrice, c.Kilometre, c.CarYear, c.CarDescription, c.CarBrandId, c.CarModelId, cbsh.StatusValueId, ccp.CarPropertyValueId, cvpTop.PropertyValue as TopProperty
                        from CarBuy cb
                        join BaseUser bu on cb.CreatedBy = bu.Id
                        join Car c on cb.CarId = c.Id
                        join CarBuyStatusHistory cbsh on cb.Id = cbsh.CarBuyId
                        join CarCarProperty ccp on c.Id = ccp.CarId
                        join CarPropertyValue cpv on ccp.CarPropertyValueId = cpv.Id
                        join CarPropertyValue cvpTop on cpv.TopPropertyValueId = cvpTop.Id
                        WHERE cbsh.Id = (SELECT TOP 1 Id FROM CarBuyStatusHistory WHERE CarBuyId = cb.Id AND IsActive = 1 ORDER BY CreatedDate DESC) AND cbsh.IsActive = 1
                        AND cb.Id = @id";
                    var parameters = new { id = id };
                    var initialInfo = (from info in connection.Query(query, parameters)
                                       group info by info.Id into grp
                                       select new CarBuyUpdatePageMainInfoDTO(
                                           new Guid(grp.Key),
                                           grp.Select(x => new Guid(x.Id)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToString(x.Username)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToDecimal(x.PrevaluationPrice)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToDecimal(x.BidPrice)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToInt32(x.Kilometre)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToInt16(x.CarYear)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToString(x.CarDescription)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToInt16(x.CarBrandId)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToInt32(x.CarModelId)).FirstOrDefault(),
                                           grp.Select(x => Convert.ToInt32(x.StatusValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "BodyType").Select(x => new Guid(x.CarPropertyValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "FuelType").Select(x => new Guid(x.CarPropertyValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "GearType").Select(x => new Guid(x.CarPropertyValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "Version").Select(x => new Guid(x.CarPropertyValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "Color").Select(x => new Guid(x.CarPropertyValueId)).FirstOrDefault(),
                                           grp.Where(x => x.TopProperty == "OptionalHardware").Select(x => new Guid(x.CarPropertyValueId)).ToList()
                                           )).FirstOrDefault();

                    var carImageQuery = @"select Id, CarImage as Image from CarImages where CarId=@carId";
                    var carImageParam = new { carId = initialInfo.CarId };
                    var carImageResult = await connection.QueryAsync<CarImageListDTO>(carImageQuery);
                    List<CarImageListDTO> carImageList = carImageResult.ToList();

                    var brandQuery = @"SELECT Id, BrandName as Name FROM CarBrand";
                    var brandResult = await connection.QueryAsync<IdNameListDTO>(brandQuery);
                    List<IdNameListDTO> brandList = brandResult.ToList();

                    var modelQuery = @"SELECT Id, ModelName as Name FROM CarModel";
                    var modelResult = await connection.QueryAsync<IdNameListDTO>(modelQuery);
                    List<IdNameListDTO> modelList = modelResult.ToList();

                    var statusValueQuery = "SELECT Id, StatusName as Name FROM StatusValue WHERE StatusTypeId = 3";
                    var statusValueResult = await connection.QueryAsync<IdNameListDTO>(statusValueQuery);
                    List<IdNameListDTO> statusValueList = statusValueResult.ToList();

                    CarBuyUpdatePageDTO responseDTO = new CarBuyUpdatePageDTO(
                        initialInfo.Id,
                        initialInfo.CarId,
                        initialInfo.UserFullName,
                        initialInfo.PreValuationPrice,
                        initialInfo.BidPrice,
                        initialInfo.Kilometre,
                        initialInfo.CarYear,
                        initialInfo.CarDescription,
                        initialInfo.CarBrandId,
                        initialInfo.CarModelId,
                        initialInfo.StatusId,
                        initialInfo.BodyTypeId,
                        initialInfo.FuelTypeId,
                        initialInfo.GearTypeId,
                        initialInfo.VersionId,
                        initialInfo.ColorId,
                        initialInfo.OptionalHardwareIds,
                        carImageList,
                        brandList,
                        modelList,
                        statusValueList,
                        CarPropertyListByType(connection, "BodyType").Result,
                        CarPropertyListByType(connection, "FuelType").Result,
                        CarPropertyListByType(connection, "GearType").Result,
                        CarPropertyListByType(connection, "Version").Result,
                        CarPropertyListByType(connection, "Color").Result,
                        CarPropertyListByType(connection, "OptionalHardware").Result);

                    return new ResponseModel<CarBuyUpdatePageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBuyUpdatePageDTO>()
                {
                    Data = new CarBuyUpdatePageDTO(Guid.Empty, Guid.Empty, "", 0, 0, 0, 0, "", 0, 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, new List<Guid>(), new List<CarImageListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdatePost(CarBuyUpdateSendDTO dto)
        {
            try
            {
                var query = @"BEGIN TRAN
	                BEGIN TRY
		                UPDATE CarBuy SET PreValuationPrice = @preValuationPrice, BidPrice = @bidPrice, ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() WHERE Id = @carBuyId

		                declare @lastStatusId int = (SELECT TOP 1 StatusValueId FROM CarBuyStatusHistory WHERE CarBuyId = @carBuyId AND IsActive = 1 ORDER BY CreatedDate DESC)
		                IF(@lastStatusId != @statusId)
		                BEGIN
			                INSERT INTO CarBuyStatusHistory(Id, CarBuyId, StatusValueId, Explanation, CreatedBy) VALUES
			                (NEWID(), @carBuyId, @statusId, N'Yeni durum.', @modifiedBy)
		                END
		
		                COMMIT TRAN
	                END TRY
	                BEGIN CATCH
		                ROLLBACK TRAN
		                RAISERROR('İşlem Başarısız', 16, 1)
	                END CATCH";
                var parameters = new { carBuyId = dto.Id, preValuationPrice = dto.PreValuationPrice, bidPrice = dto.BidPrice, statusId = dto.StatusId, modifiedBy = dto.ModifiedBy };

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        private async Task<List<IdNameListDTO>> CarPropertyListByType(IDbConnection connection, string type)
        {
            var query = $@"DECLARE @typeId uniqueidentifier = (SELECT TOP 1 Id FROM CarPropertyValue WHERE PropertyValue = '{type}')
	                    SELECT Id, PropertyValue as Name FROM CarPropertyValue WHERE TopPropertyValueId = @typeId";
            var result = await connection.QueryAsync<IdNameListDTO>(query);

            return result.ToList();
        }
    }
}
