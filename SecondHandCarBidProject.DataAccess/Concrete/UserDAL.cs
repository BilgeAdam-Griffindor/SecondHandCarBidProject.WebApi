using Microsoft.Extensions.Configuration;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Interface.Token;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class UserDAL : IUserDAL
    {
        private IConfiguration _configuration;
        private ITokenHandler _tokenHandler;

        public UserDAL(IConfiguration configuration, ITokenHandler tokenHandler)
        {
            _configuration = configuration;
            _tokenHandler = tokenHandler;
        }

        //esranın donus tipi gelecek
        public Task<ExampleDTO> Authenticate(TokenUserRequestDTO req)
        {
            ResponseModel<ExampleDTO> responseModel = new ResponseModel<ExampleDTO>();
            if (string.IsNullOrWhiteSpace(req.LoginUser) ||
             string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            //dbden user bilgisi gelecek

            //İşte burada exampleDTO yerine kendi dto doldurulacak.

            /* Db'ye gittik ve girilen inputlara uygun bir kayıt bulamadık mesela :
                responseModel.businessValidationRule = BusinessValidationRule.BadRequest;
                responseModel.IsSuccess = false;
            */

            //login olunca token bilgisini dönücez
            //TokenDTO token = _tokenHandler.CreateAccessToken(30);
            //_tokenHandler.UpdateRefreshToken(token.RefreshToken, userid.userid, token.Expiration, 45);

            return null;
        }
        //esranın donus tipi gelecek
        public Task<ExampleDTO> RefreshTokenAuthenticate(TokenUserRequestDTO req)
        {
            ResponseModel<ExampleDTO> responseModel = new ResponseModel<ExampleDTO>();
            if (string.IsNullOrWhiteSpace(req.LoginUser) ||
             string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            //dbden user bilgisi gelecek

            //İşte burada exampleDTO yerine kendi dto doldurulacak.

            /* Db'ye gittik ve girilen inputlara uygun bir kayıt bulamadık mesela :
                responseModel.businessValidationRule = BusinessValidationRule.BadRequest;
                responseModel.IsSuccess = false;
            */

            //dbden userı alıcaz eğer user varsa ve refreshtoken tablosundaki refreshtokenenddate datetimenowdan büyükse
            //accesstoken olusturup refreshtokeni update edicez
            //TokenDTO token = _tokenHandler.CreateAccessToken(30);
            //_tokenHandler.UpdateRefreshToken(token.RefreshToken, userid.userid, token.Expiration, 45);

            return null;
        }
    }
}
