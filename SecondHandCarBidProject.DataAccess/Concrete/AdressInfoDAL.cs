using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.AddressInfo;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class AdressInfoDAL : IAdressInfoDAL
    {
        private readonly DapperContext _context;
        public AdressInfoDAL(DapperContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<AddressInfoListDTO>>> GetAllAdresses()
        {
            var query = "SELECT * from AddressInfo";
            using (var connection = _context.CreateConnection())
            {
                var adresses = await connection.QueryAsync<AddressInfoListDTO>(query);
                List<AddressInfoListDTO> adressesList = adresses.ToList();
                var responseModel = new ResponseModel<List<AddressInfoListDTO>>()
                {
                    //  statusCode = StatusCode.Success,
                    IsSuccess = true,
                    Data = adressesList,
                    Errors = null
                };
                return responseModel;
            }
        }
    }
}
