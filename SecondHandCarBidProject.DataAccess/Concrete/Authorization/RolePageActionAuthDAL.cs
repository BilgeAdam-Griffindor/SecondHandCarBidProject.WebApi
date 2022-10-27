using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto;
using SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto.TempDto;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.Authorization
{
    public class RolePageActionAuthDAL : IRolePageActionAuthDAL
    {
        private readonly DapperContext _context;
        public RolePageActionAuthDAL(DapperContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<RolePageActionAuthAddGetDTO>> AddGet()
        {
            var queryGetRole = "SELECT Id,RoleName FROM RoleType WHERE IsActive=1";
            var queryPageAuth = "SELECT ID,AuthorizationName FROM PageAuthType WHERE IsActive=1";
            var queryActionAuth = "SELECT Id,AuthorizationName FROM ActionAuthType WHERE IsActive=1";
            
            using (var connection = _context.CreateConnection())
            {
                var dataRole = await connection.QueryAsync<RoleTypeTempAddGetDto>(queryGetRole);
                List<RoleTypeTempAddGetDto> roleList = dataRole.ToList();
                var dataPageAuth = await connection.QueryAsync<PageAuthTypeTempAddGetDto>(queryPageAuth);
                List<PageAuthTypeTempAddGetDto> pageAuthList = dataPageAuth.ToList();
                var dataActionAuth = await connection.QueryAsync<ActionAuthTypeTempAddGetDto>(queryActionAuth);
                List<ActionAuthTypeTempAddGetDto> actionAuthList = dataActionAuth.ToList();
                RolePageActionAuthAddGetDTO rolePageActionAuthAddGetDTO = new RolePageActionAuthAddGetDTO()
                {
                    roleTypelistDtos = roleList,
                    actionauthTypelistDtos = actionAuthList,
                    pageauthTypelistDtos = pageAuthList
                };
                ResponseModel<RolePageActionAuthAddGetDTO> responseModel = new ResponseModel<RolePageActionAuthAddGetDTO>()
                {
                    Data = rolePageActionAuthAddGetDTO,
                    IsSuccess = true
                };
                return responseModel;
            }
            
        }

        public async Task<ResponseModel<bool>> AddPost(RolePageActionAuthAddDto rpa)
        {
            var query = "INSERT INTO RolePageActionAuth (RoleTypeId,ActionAuthTypeId,PageAuthTypeId,CreatedBy,IsActive,CreatedDate) VALUES (@roleTypeId,@actionAuthTypeId,@pageAuthTypeId,@createdGuidId,1,@createdDate)";
            var parameters = new
            {
                roleTypeId = rpa.RoleTypeId,
                actionAuthTypeId = rpa.ActionAuthTypeId,
                pageAuthTypeId = rpa.PageAuthTypeId,
                createdGuidId = rpa.CreatedBy,
                createdDate = DateTime.Now
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

        public async Task<ResponseModel<RolePageActionAuthListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var query = @"SELECT r.RoleName as [roleTypeName],pa.AuthorizationName AS [pageAuthTypeName],aa.AuthorizationName as [actionAuthTypeName] FROM RolePageActionAuth rp
                            INNER JOIN RoleType r ON r.Id = rp.RoleTypeId
                            INNER JOIN PageAuthType pa ON pa.Id = rp.PageAuthTypeId
                            INNER JOIN ActionAuthType aa ON aa.Id = rp.ActionAuthTypeId
                            WHERE rp.IsActive = 1
                            ORDER BY RP.RoleTypeId  offset(@page - 1) * @itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new {page=page, itemPerPage =itemPerPage};
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<RolePageActionAuthDTO>(query, parameters);
                List<RolePageActionAuthDTO> newTableData = data.ToList();
                int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM RolePageActionAuth"));
                maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);
                RolePageActionAuthListDto pageAuthTypeListDTO = new RolePageActionAuthListDto();
                pageAuthTypeListDTO.pageAuthTypeDtos = newTableData;
                pageAuthTypeListDTO.maxPages = maxPage;
                ResponseModel<RolePageActionAuthListDto> model = new ResponseModel<RolePageActionAuthListDto>()
                {
                    Data= pageAuthTypeListDTO,
                    IsSuccess= true
                    
                };
                return model;
            }
        }
    }
}
