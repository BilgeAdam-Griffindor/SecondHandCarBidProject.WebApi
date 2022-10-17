using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.Security;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Concrete
{
    public class MongoEmailPasswordToken : IMongoEmailPasswordToken
    {
        IMongoCollection<EmailPasswordTokenModel> _mongoEmailPasswordTokenCollection;

        public MongoEmailPasswordToken(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(mongoSettings);

            var mongoDB = client.GetDatabase(MongoSettings.Value.DatabaseName);

            _mongoEmailPasswordTokenCollection = mongoDB.GetCollection<EmailPasswordTokenModel>(MongoSettings.Value.EmailPasswordTokenCollection);
        }

        /// <summary>
        /// Adds token for the specified operation.
        /// </summary>
        /// <param name="userId">Id of the user who made the token request.</param>
        /// <param name="tokenFor">email or password</param>
        /// <returns>Created token or empty string if there was a problem</returns>
        public async Task<string> AddToken(Guid userId, string tokenFor)
        {
            try
            {
                string tokenString = TokenCreator.CreateToken();

                EmailPasswordTokenModel tokenRequest = new EmailPasswordTokenModel()
                {
                    UserId = userId,
                    Token = tokenString,
                    TokenFor = tokenFor,
                    ExpirationDate = DateTime.Now.AddHours(1),
                };

                await _mongoEmailPasswordTokenCollection.InsertOneAsync(tokenRequest);

                return tokenString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the info of the specified token.
        /// </summary>
        /// <param name="token">Token whose information is needed.</param>
        /// <returns>Information related to the token or null.</returns>
        public async Task<GetTokenInfoDTO> GetTokenInfo(string token)
        {
            try
            {
                var documentCursor = await _mongoEmailPasswordTokenCollection.FindAsync(x => x.Token == token);

                EmailPasswordTokenModel document = documentCursor.First();

                return new GetTokenInfoDTO()
                {
                    Id = document.Id,
                    UserId = document.UserId,
                    TokenFor = document.TokenFor,
                    ExpirationDate = document.ExpirationDate
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes the token with the given token Id
        /// </summary>
        /// <param name="tokenId">Id of the token to be erased</param>
        /// <returns></returns>
        public async Task<bool> RemoveToken(string tokenId)
        {
            try
            {
                await _mongoEmailPasswordTokenCollection.DeleteOneAsync(x => x.Id == tokenId);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes expired tokens.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveExpiredTokens()
        {
            try
            {
                await _mongoEmailPasswordTokenCollection.DeleteManyAsync(x => x.ExpirationDate < DateTime.Now);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
