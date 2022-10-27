using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.RoleTypeDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.Authorization
{
    public class RoleTypeDAL : IRoleTypeDAL
    {
        private readonly DapperContext _context;
        public RoleTypeDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<bool>> Add(RoleTypeAddDto roleTypeAddDto)
        {
            var query = "INSERT INTO RoleType (RoleName,IsActive) VALUES (@rolename,1)";
            var parameters = new {rolename=roleTypeAddDto.RoleName};
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
                var query = "UPDATE RoleType SET IsActive=0 WHERE Id=@id";
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

        public async Task<ResponseModel<RoleTypeListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = "SELECT Id,RoleName FROM RoleType WHERE IsActive=1 ORDER BY Id  offset(@page - 1) * @itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page=page, itemPerPage=itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<RoleTypeDto>(query, parameters);
                List<RoleTypeDto> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM RoleType"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                RoleTypeListDto roleTypeListDTO = new RoleTypeListDto();
                roleTypeListDTO.roleTypeListDto = newTableData;
                roleTypeListDTO.maxPages = maxPage;
                return new ResponseModel<RoleTypeListDto>()
                {
                    Data = roleTypeListDTO,
                    IsSuccess = true,
                    statusCode = Common.Validation.StatusCode.Success
                };
            }
        }

        public async Task<ResponseModel<bool>> Update(RoleTypeUpdateDto roleTypeUpdateDto)
        {
            var query = "UPDATE RoleType SET RoleName=@rolename WHERE Id=@id";
            var parameters = new { rolename = roleTypeUpdateDto.RoleName, id = roleTypeUpdateDto.Id };
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
