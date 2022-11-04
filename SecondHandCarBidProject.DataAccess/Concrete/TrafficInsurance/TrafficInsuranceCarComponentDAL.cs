using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceCarComponentDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.TrafficInsurance
{
    public class TrafficInsuranceCarComponentDAL : ITrafficInsuranceCarComponentDAL
    {
        DapperContext _context;
        public TrafficInsuranceCarComponentDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceCarComponentAddDto trafficInsuranceCarComponentAddDto)
        {
            var query = "INSERT INTO TrafficInsuranceCarComponent (ComponentName,IsActive) VALUES (@componentName,1)";
            var parameters = new { componentName = trafficInsuranceCarComponentAddDto.ComponentName };
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

        public async Task<ResponseModel<bool>> Delete(short id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UPDATE TrafficInsuranceCarComponent SET IsActive=0 WHERE Id=@id";
                var parameters = new { id = id };
                var data = await connection.ExecuteAsync(query, parameters);
                ResponseModel<bool> responseModel = new ResponseModel<bool>()
                {
                    Data = (data == 1) ? true : false,
                    IsSuccess = true,
                };
                return responseModel;
            }
        }

        public async Task<ResponseModel<TrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = @"SELECT Id,ComponentName FROM TrafficInsuranceCarComponent WHERE IsActive=1
                          ORDER BY Id offset(@page -1) *@itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page = page, itemPerPage = itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<TrafficInsuranceCarComponentDto>(query, parameters);
                List<TrafficInsuranceCarComponentDto> list = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM TrafficInsuranceCarComponent"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                TrafficInsuranceCarComponentListDto trafficInsuranceCarComponentListDto = new TrafficInsuranceCarComponentListDto();
                trafficInsuranceCarComponentListDto.maxPages = maxPage;
                trafficInsuranceCarComponentListDto.trafficInsuranceCarComponentListDtos = list;

                return new ResponseModel<TrafficInsuranceCarComponentListDto>()
                {
                    Data = trafficInsuranceCarComponentListDto,
                    IsSuccess = true
                };
            }

        }

        public async Task<ResponseModel<bool>> Update(TrafficInsuranceCarComponentUpdateDto trafficInsuranceCarComponentUpdateDto)
        {
            var query = "UPDATE TrafficInsuranceCarComponent SET ComponentName=@componentName WHERE Id=@id";
            var parameters = new { componentName = trafficInsuranceCarComponentUpdateDto.ComponentName, id = trafficInsuranceCarComponentUpdateDto.Id };
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
    }
}
