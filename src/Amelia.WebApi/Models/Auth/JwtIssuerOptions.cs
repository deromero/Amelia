using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Amelia.WebApi.Models.Auth
{
    public class JwtIssuerOptions
    {
        /// <summary>
        /// "iss" (Issuer) Claim
        /// </summary>
        /// <returns></returns>
        public string Issuer { get; set; }

        /// <summary>
        /// "sub" (Subject) Claim
        /// </summary>
        /// <returns></returns>
        public string Subject { get; set; }

        /// <summary>
        /// "add" (Audience) Claim
        /// </summary>
        /// <returns></returns>
        public string Audience { get; set; }

        /// <summary>
        /// "nbf" (Not Before) Claim (default is UTC NOW)
        /// </summary>
        /// <returns></returns>
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// "iat" (Issued At) Claim (default is UTC NOW)
        /// </summary>
        /// <returns></returns>
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Set the timespan the token will be valid for (default is 5 min/300 seconds)
        /// </summary>
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// "exp" (Expiration Time) Claim (returns IssuedAt + ValidFor)
        /// </summary>
        /// <returns></returns>
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        /// <summary>
        /// "jti" (JWT ID) Claim (default ID is a GUID)
        /// </summary>
        public Func<Task<string>> JtiGenerator =>
                    () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }
    }
}