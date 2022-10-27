using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusTypeDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IStatus;
using SecondHandCarBidProject.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.Status
{
    public class StatusTypeDAL : IStatusTypeDAL
    {
        private readonly DapperContext _context;
        public StatusTypeDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<bool>> Add(StatusTypeAddDTO statusTypeAddDto)
        {
            var query = "INSERT INTO StatusType (StatusTypeName,IsActive) VALUES (@statusname,1)";
            var parameters = new { statusname = statusTypeAddDto.StatusTypeName };
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
                var query = "UPDATE StatusType SET IsActive=0 WHERE Id=@id";
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

        public async Task<ResponseModel<StatusTypeListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = "SELECT Id,StatusTypeName FROM StatusType WHERE IsActive=1 ORDER BY Id  offset(@page - 1) * @itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page = page, itemPerPage = itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<StatusTypeDto>(query, parameters);
                List<StatusTypeDto> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM StatusType"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                StatusTypeListDto statusTypeListDTO = new StatusTypeListDto();
                statusTypeListDTO.statusTypeListDtos = newTableData;
                statusTypeListDTO.maxPages = maxPage;
                return new ResponseModel<StatusTypeListDto>()
                {
                    Data = statusTypeListDTO,
                    IsSuccess = true,
                    statusCode = Common.Validation.StatusCode.Success
                };
            }
        }

        public async Task<ResponseModel<bool>> Update(StatusTypeUpdateDto statusTypeUpdateDto)
        {
            var query = "UPDATE StatusType SET StatusTypeName=@statusname WHERE Id=@id";
            var parameters = new { statusname = statusTypeUpdateDto.StatusTypeName, id = statusTypeUpdateDto.Id };
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
