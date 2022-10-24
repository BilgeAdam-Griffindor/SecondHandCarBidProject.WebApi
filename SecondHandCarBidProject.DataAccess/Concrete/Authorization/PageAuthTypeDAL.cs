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
            
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<PageAuthTypeListDTO>> List(int page = 1, int itemPerPage = 10)
        {
            var query = @"SELECT Id,AuthorizationName FROM PageAuthType WHERE IsActive=1 ORDER BY Id  offset(@page - 1) * @itemPerPage rows fetch next @itemPerPage rows only";
            var parameters = new { page, itemPerPage };
            using (var connection = _context.CreateConnection())
            {
                var data = await connection.QueryAsync<PageAuthTypeDto>(query,parameters);
                List<PageAuthTypeDto> newTableData = data.ToList();
                PageAuthTypeListDTO pageAuthTypeListDTO = new PageAuthTypeListDTO(newTableData, itemPerPage);
                return new ResponseModel<PageAuthTypeListDTO>()
                {
                    Data = pageAuthTypeListDTO,
                    IsSuccess = true,
                    statusCode = Common.Validation.StatusCode.Success
                };
            }
            
            
        }
    }
}
