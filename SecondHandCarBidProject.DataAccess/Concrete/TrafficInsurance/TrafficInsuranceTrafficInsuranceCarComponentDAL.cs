using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceTrafficInsuranceCarComponentDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.TrafficInsurance
{
    public class TrafficInsuranceTrafficInsuranceCarComponentDAL : ITrafficInsuranceTrafficInsuranceCarComponentDAL
    {
        DapperContext _context;
        public TrafficInsuranceTrafficInsuranceCarComponentDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceTrafficInsuranceCarComponentAddDto titiccad)
        {
            var query = @"INSERT INTO TrafficInsuranceTrafficInsuranceCarComponent 
                        (TrafficInsuranceId, TrafficInsuranceCarComponentId, StatusValueId, IsActive, CreatedBy)
                        VALUES(@trafficInsuranceId, @trafficInsuranceCarComponentId, @statusValueId, 1, @createdBy)";
            var parameters = new
            {
                trafficInsuranceId = titiccad.TrafficInsuranceId,
                trafficInsuranceCarComponentId = titiccad.TrafficInsuranceCarComponentId,
                statusValueId = titiccad.StatusValueId,
                createdBy = titiccad.CreatedBy
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

        public async Task<ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = @"SELECT TrafficInsuranceId,TrafficInsuranceCarComponentId,StatusValueId FROM TrafficInsuranceTrafficInsuranceCarComponent
                        WHERE IsActive = 1
                        ORDER BY TrafficInsuranceId offset(@page -1) *@itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page = page, itemPerPage = itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<TrafficInsuranceTrafficInsuranceCarComponentDto>(query, parameters);
                List<TrafficInsuranceTrafficInsuranceCarComponentDto> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM RoleType"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                TrafficInsuranceTrafficInsuranceCarComponentListDto titiccListDTO = new TrafficInsuranceTrafficInsuranceCarComponentListDto();
                titiccListDTO.trafficInsuranceTrafficInsuranceCarComponentListDtos=newTableData;
                titiccListDTO.maxPages = maxPage;
                return new ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentListDto>()
                {
                    Data = titiccListDTO,
                    IsSuccess = true
                    //statusCode = Common.Validation.StatusCode.Success
                };
            }
                
        }
    }
}
