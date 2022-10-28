using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Interface.Token;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class AuthDAL : IAuthDAL
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly DapperContext _context;
        public AuthDAL(DapperContext context, ITokenHandler tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }
        public async Task<ResponseModel<UserResponseDTO>> LoginAsync(string Username, string password, int accessTokenLifeTime)
        {
            TokenDTO tokenDTO = null;
            UserResponseDTO userResponse = new UserResponseDTO();
            //check user
            //if user exists;

            var query = "SELECT * FROM BaseUser WHERE Email= @Username and PasswordSalt = @password";
            var parameters = new DynamicParameters();
            parameters.Add("password", password, System.Data.DbType.String);
            parameters.Add("Username", Username, System.Data.DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<BaseUserDTO>(query, parameters);
                if (user != null && (user.Email == Username && user.PasswordSalt == password))
                {
                    tokenDTO = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);//todo:user parameter                
                    userResponse.Token = tokenDTO;
                    userResponse.User = user;
                    //TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(accessTokenLifeTime);//todo:user parameter
                    //then update refreshtoken
                    await _tokenHandler.UpdateRefreshToken(tokenDTO.RefreshToken, user, tokenDTO.Expiration, 5);
                    var responseModel = new ResponseModel<UserResponseDTO>()
                    {
                        //  statusCode = StatusCode.Success,
                        IsSuccess = true,
                        Data = userResponse,
                        Errors = null
                    };
                    return responseModel;
                }
                else
                {

                    var responseModel = new ResponseModel<UserResponseDTO>()
                    {
                        // statusCode = StatusCode.Unauthorized,
                        IsSuccess = false,
                        Data = userResponse,
                        Errors = new List<string>() { "Girilen bilgilere ait kullanıcı bulunamadı" }
                    };


                    return responseModel;
                }
            }
        }

        public async Task<ResponseModel<TokenDTO>> RefreshTokenLoginAsync(string refreshToken)
        {
            //if user exists and refresh token duration is valid;
            //if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            //{
            //    TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(30);//todo:user parameter
            //    await _tokenHandler.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);
            //    ResponseModel<TokenDTO> response = new ResponseModel<TokenDTO>()
            //    {
            //        Data = tokenDTO,
            //        IsSuccess = true
            //        businessValidationRule = Common.Validation.BusinessValidationRule.Success,
            //        Errors = null
            //    };
            //    return response;
            //}
            //else
            //    return null;

            return null;
        }

        public async Task<ResponseModel<bool>> RegisterAsync(BaseUserAddDTO user)
        {
            var query = "insert into BaseUser (Id,FirstName,LastName,Username,PasswordHash,PasswordSalt,Email,PhoneNumber,AddressInfoId,IsApproved,ApprovedBy,EmailVerified,IsCorporate,KVKKChecked,RoleTypeId,IsActive,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy) values(@id,@firstname,@lastname,@username,@passwordhash,@passwordsalt,@email,@phonenumber,@addressinfoid,@isapproved,@approvedby,@emailverified,@iscorporate,@kvkkchecked,@roletypeid,@isactive,@createddate,@modifieddate,@createdby,@modifiedby)";
            var parameters = new DynamicParameters();
            parameters.Add("id", Guid.NewGuid(), System.Data.DbType.Guid);
            parameters.Add("firstname", user.FirstName, System.Data.DbType.String);
            parameters.Add("lastname", user.LastName, System.Data.DbType.String);
            parameters.Add("username", user.Username, System.Data.DbType.String);
            parameters.Add("passwordhash", user.PasswordHash, System.Data.DbType.String);
            parameters.Add("passwordsalt", user.PasswordSalt, System.Data.DbType.String);
            parameters.Add("email", user.Email, System.Data.DbType.String);
            parameters.Add("phonenumber", user.PhoneNumber, System.Data.DbType.String);
            parameters.Add("addressinfoid", user.AddressInfoId, System.Data.DbType.Int32);
            parameters.Add("isapproved", user.IsApproved, System.Data.DbType.Boolean);
            parameters.Add("approvedby", user.ApprovedBy, System.Data.DbType.Guid);
            parameters.Add("emailverified", user.EmailVerified, System.Data.DbType.Boolean);
            parameters.Add("iscorporate", user.isCorporate, System.Data.DbType.Boolean);
            parameters.Add("kvkkchecked", user.KVKKChecked, System.Data.DbType.Boolean);
            parameters.Add("roletypeid", user.RoleTypeId, System.Data.DbType.Int16);
            parameters.Add("isactive", user.IsActive, System.Data.DbType.Boolean);
            parameters.Add("createddate", user.CreatedDate, System.Data.DbType.DateTime);
            parameters.Add("modifieddate", user.ModifiedDate, System.Data.DbType.DateTime);
            parameters.Add("createdby", user.CreatedBy, System.Data.DbType.Guid);
            parameters.Add("modifiedby", user.ModifiedBy, System.Data.DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return new ResponseModel<bool>()
                {
                    Data = result > 0,
                    IsSuccess = true,
                    Errors = null
                };
            }
        }
    }
}
