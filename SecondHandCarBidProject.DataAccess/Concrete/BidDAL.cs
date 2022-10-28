using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.Bid;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class BidDAL : IBidDAL
    {
        private readonly DapperContext _context;

        public BidDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BidAddPageUserDTO>> AddGetUser(Guid userId, bool isCorporate)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    string carQuery;
                    if (!isCorporate)
                        carQuery = @"select c.Id, (cb.BrandName + ' - ' + cm.ModelName + ' - ' + cast(c.CreatedDate as nvarchar(20))) as Name
                            from Car c
                            join CarBrand cb on c.CarBrandId = cb.Id
                            join CarModel cm on c.CarModelId = cm.Id
                            join CarStatusHistory csh on c.Id = csh.CarId
                            WHERE csh.Id = (SELECT TOP 1 Id FROM CarStatusHistory WHERE CarId = c.Id AND IsActive = 1 ORDER BY CreatedDate DESC) 
                            AND c.IsActive = 1
                            AND csh.StatusValueId = 1
                            AND c.CreatedBy = @userId";
                    else
                        carQuery = @"select c.Id, (cb.BrandName + ' - ' + cm.ModelName + ' - ' + cast(c.CreatedDate as nvarchar(20))) as Name
                            from Car c
                            join CarBrand cb on c.CarBrandId = cb.Id
                            join CarModel cm on c.CarModelId = cm.Id
                            join CarStatusHistory csh on c.Id = csh.CarId
                            join CarCorporation cc on cc.CorporationId = (select top 1 CorporationId from CorporationUser where BaseUserId = @userId)
                            WHERE csh.Id = (SELECT TOP 1 Id FROM CarStatusHistory WHERE CarId = c.Id AND IsActive = 1 ORDER BY CreatedDate DESC) 
                            AND c.IsActive = 1
                            AND csh.StatusValueId = 1";

                    var parameters = new { userId = userId };
                    var carResult = await connection.QueryAsync<IdNameListDTO>(carQuery, parameters);
                    List<IdNameListDTO> carList = carResult.ToList();

                    BidAddPageUserDTO responseDTO = new BidAddPageUserDTO()
                    {
                        CarList = carList
                    };

                    return new ResponseModel<BidAddPageUserDTO>()
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

                return new ResponseModel<BidAddPageUserDTO>()
                {
                    Data = new BidAddPageUserDTO()
                    {
                        CarList = new List<IdNameListDTO>()
                    },
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPostUser(BidAddSendUserDTO dto)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));

                for (int i = 0; i < dto.CarIds.Count; i++)
                {
                    DataRow row = dataTable.NewRow();
                    row["Id"] = dto.CarIds[i];
                    dataTable.Rows.Add(row);
                }

                var query = "EXEC AddNewBidSimpler @bidName, @isCorporate, @corporationId, @bidStartDate, @bidEndDate, @createdBy, @bidCarsList, @explanation";
                var parameters = new { bidName = dto.BidName, isCorporate = dto.CorporationId != null, corporationId = dto.CorporationId, bidStartDate = dto.StartDate, bidEndDate = dto.EndDate, createdBy = dto.CreatedBy, bidCarsList = dataTable.AsTableValuedParameter("GuidIdList"), explanation = "Yeni ihale."};
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
    }
}
