using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecondHandCarBidProject.Common.Security
{
    /// <summary>
    /// Token creation for email verification and forgot password operations.
    /// </summary>
    public static class TokenCreator
    {
        /// <summary>
        /// Creates a token.
        /// </summary>
        /// <returns>Url safe string token.</returns>
        public static string CreateToken()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] tokenBytes = new byte[48];

            rng.GetBytes(tokenBytes);

            return HttpUtility.UrlEncode(Convert.ToBase64String(tokenBytes));
        }
    }
}
