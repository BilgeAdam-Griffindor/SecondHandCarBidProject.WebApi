using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO.Temp;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.Status
{
    public class StatusValueDAL : IStatusValueDAL
    {
        private readonly DapperContext _context;
        public StatusValueDAL(DapperContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<bool>> Add(StatusValueAddDto statusValueAddDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StatusValueAddGetDto>> AddGet()
        {
            var query = "SELECT Id,StatusTypeName FROM StatusType WHERE IsActive=1";
            using (var connection = _context.CreateConnection())
            { 
                var data = await connection.QueryAsync<StatusTypeTempDto>(query);
                List<StatusTypeTempDto> statusValueListDtos = data.ToList();

                StatusValueAddGetDto statusValueAddGetDto = new StatusValueAddGetDto();
                statusValueAddGetDto.statusTypeTempDtos = statusValueListDtos;
                ResponseModel<StatusValueAddGetDto> responseModel = new ResponseModel<StatusValueAddGetDto>();
                responseModel.Data = statusValueAddGetDto;
                responseModel.IsSuccess = true;
                return responseModel;
            }

             
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            var query = "UPDATE StatusValue SET IsActive=0 WHERE Id=@id";
            var parameters = new { id=id };
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

        public async Task<ResponseModel<StatusValueListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = @"SELECT sv.Id,StatusName,st.StatusTypeName FROM StatusValue sv
                        INNER JOIN StatusType st ON st.Id = sv.StatusTypeId
                        WHERE sv.IsActive = 1
                        ORDER BY Id offset(@page -1) *@itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page = page, itemPerPage = itemPerPage};
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<StatusValueDto>(query, parameters);
                List<StatusValueDto> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM StatusValue"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                StatusValueListDto statusTypeValueDTO = new StatusValueListDto();
                statusTypeValueDTO.statusValueListDtos = newTableData;
                statusTypeValueDTO.maxPages = maxPage;
                return new ResponseModel<StatusValueListDto>()
                {
                    Data = statusTypeValueDTO,
                    IsSuccess = true
                };
            }
           
        }

        public async Task<ResponseModel<bool>> Update(StatusValueUpdateDto statusValueUpdateDto)
        {
            var query = "UPDATE StatusValue SET StatusName=@statusname,StatusTypeId=@statusid WHERE Id=@id";
            var parameters = new
            {
                statusname = statusValueUpdateDto.StatusName,
                statusid = statusValueUpdateDto.StatusTypeId,
                id = statusValueUpdateDto.Id
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

        public async Task<ResponseModel<StatusValueUpdateGetDto>> UpdateGet(int id)
        {

            var data = await AddGet();
            var query = "SELECT Id,StatusName,StatusTypeId FROM StatusValue WHERE IsActive=1 AND Id=@id";
            var parameters = new { id = id };
            using (var connection = _context.CreateConnection())
            {
                var updateData = await connection.QueryFirstAsync<StatusValueUpdateGetDto>(query, parameters);
                updateData.statusTypeTempDtos = data.Data.statusTypeTempDtos;
                return new ResponseModel<StatusValueUpdateGetDto>()
                {
                    Data = updateData,
                    IsSuccess = true
                };

            }

                
        }
    }
}
