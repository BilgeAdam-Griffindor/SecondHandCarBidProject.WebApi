using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO.Temp;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.TrafficInsurance
{
    public class TrafficInsuranceDAL : ITrafficInsuranceDAL
    {
        DapperContext _context;
        public TrafficInsuranceDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceAddDto trafficInsuranceAddDto)
        {
            var query = @"INSERT INTO TrafficInsurance (Id,CarId,Cost,CreatedBy,IsActive,CreatedDate) 
                        VALUES (@id,@carid,@cost,
                        @createdId,1,@dateNow)";
            var parameters = new {
                id = Guid.NewGuid(),
                carid = trafficInsuranceAddDto.CarId,
                cost=trafficInsuranceAddDto.Cost,
                createdId=trafficInsuranceAddDto.CreatedId,
                dateNow=DateTime.Now
            };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.ExecuteAsync(query,parameters);
                ResponseModel<bool> responseModel = new ResponseModel<bool>()
                {
                    Data = (data == 1) ? true : false,
                    IsSuccess = true,
                };
                return responseModel;
            }
        }

        public async Task<ResponseModel<TrafficInsuranceAddGetDto>> AddGet()
        {
            var query = "SELECT Id,Id as [CarId] FROM Car Where IsActive=1";
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<TrafficInsuranceTempCar>(query);
                List<TrafficInsuranceTempCar> trafficInsuranceTempCars = data.ToList();
                TrafficInsuranceAddGetDto trafficInsuranceAddGetDto = new TrafficInsuranceAddGetDto();
                trafficInsuranceAddGetDto.trafficInsuranceTempCars = trafficInsuranceTempCars;
                ResponseModel<TrafficInsuranceAddGetDto> responseModel = new ResponseModel<TrafficInsuranceAddGetDto>();
                responseModel.Data = trafficInsuranceAddGetDto;
                responseModel.IsSuccess = true;
                return responseModel;
            }
           
        }

        public async Task<ResponseModel<bool>> Delete(Guid id)
        {
            var query = "UPDATE TrafficInsurance SET IsActive=0 WHERE Id=@id";
            var parameters = new { id = id };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.ExecuteAsync(query, parameters);
                ResponseModel<bool> responseModel = new ResponseModel<bool>()
                {
                    Data = (data == 1) ? true : false,
                    IsSuccess = true,
                };
                return responseModel;
            }
        }

        public async Task<ResponseModel<TrafficInsuranceListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query= @"SELECT Id,CarId,Cost FROM TrafficInsurance
                        WHERE IsActive = 1
                        ORDER BY Id offset(@page -1) *@itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page = page, itemPerPage = itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<TrafficInsuranceDto>(query, parameters);
                List<TrafficInsuranceDto> result = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM StatusType"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                TrafficInsuranceListDto trafficInsuranceListDto = new TrafficInsuranceListDto();
                trafficInsuranceListDto.trafficInsuranceListDtos = result;
                trafficInsuranceListDto.maxPages= maxPage;
                return new ResponseModel<TrafficInsuranceListDto> { 
                Data=trafficInsuranceListDto,
                IsSuccess=true
                };
            }
             
        }

        public async Task<ResponseModel<bool>> Update(TrafficInsuranceUpdateDto trafficInsuranceUpdateDto)
        {
            var query = "UPDATE TrafficInsurance SET CarId=@carId,Cost=@cost WHERE Id=@id";
            var parameters = new {
                carId= trafficInsuranceUpdateDto.CarId,
                cost = trafficInsuranceUpdateDto.Cost,
                id = trafficInsuranceUpdateDto.Id
            };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.ExecuteAsync(query, parameters);
                ResponseModel<bool> responseModel = new ResponseModel<bool>()
                {
                    Data = (data == 1) ? true : false,
                    IsSuccess = true,
                };
                return responseModel;
            }
        }

        public async Task<ResponseModel<TrafficInsuranceUpdateGetDto>> UpdateGet(Guid id)
        {
            var query = "SELECT Id,CarId,Cost FROM TrafficInsurance WHERE Id=@id";
            var parameters =new { id = id };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QuerySingleAsync<TrafficInsuranceUpdateGetDto>(query,parameters);
                var carList = await AddGet();
                data.trafficInsuranceTempCars = carList.Data.trafficInsuranceTempCars;
                return new ResponseModel<TrafficInsuranceUpdateGetDto>()
                {
                    Data = data,
                    IsSuccess=true,
                };
            }
                
        }
    }
}
