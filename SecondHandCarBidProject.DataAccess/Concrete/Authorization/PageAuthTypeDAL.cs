using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.Authorization
{
    public class PageAuthTypeDAL : IPageAuthTypeDal
    {
        private readonly DapperContext _context;
        public PageAuthTypeDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> AddGet(PageAuthTypeAddDTO pageAuthTypeAddDTO)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "INSERT INTO PageAuthType (AuthorizationName,IsActive) VALUES (@authorizationname,1)";
                var parameters = new { authorizationname=pageAuthTypeAddDTO.AuthorizationName };
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
                var query = "UPDATE PageAuthType SET IsActive=0 WHERE Id=@id";
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

        public async Task<ResponseModel<PageAuthTypeListDTO>> List(int page = 1, int itemPerPage = 10)
        {
            var query = "SELECT Id,AuthorizationName FROM PageAuthType WHERE IsActive=1 ORDER BY Id  offset(@page - 1) * @itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page, itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<PageAuthTypeDto>(query,parameters);
                List<PageAuthTypeDto> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM PageAuthType"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                PageAuthTypeListDTO pageAuthTypeListDTO = new PageAuthTypeListDTO(newTableData, maxPage);
                return new ResponseModel<PageAuthTypeListDTO>()
                {
                    Data = pageAuthTypeListDTO,
                    IsSuccess = true,
                    statusCode = Common.Validation.StatusCode.Success
                };
            }
        }

        public async Task<ResponseModel<bool>> Update(PageAuthTypeUpdateDTO pageAuthTypeUpdateDTO)
        {
            var query = "UPDATE PageAuthType SET AuthorizationName=@authorizationname WHERE Id=@id";
            var parameters = new { authorizationname = pageAuthTypeUpdateDTO.AuthorizationName, id = pageAuthTypeUpdateDTO.Id };
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
