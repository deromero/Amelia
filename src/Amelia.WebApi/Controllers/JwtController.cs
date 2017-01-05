using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Amelia.WebApi.Models.Auth;
using Amelia.WebApi.Models.Contracts.Repositories;
using Amelia.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace Amelia.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class JwtController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUserRepository _userRepository;

        public JwtController(IOptions<JwtIssuerOptions> jwtOptions, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);

            _logger = loggerFactory.CreateLogger<JwtController>();
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public async Task<IActionResult> Get([FromForm] LoginViewModel loginViewModel)
        {
            var identity = await GetClaimsIdentity(loginViewModel);
            if (identity == null)
            {
                _logger.LogInformation($"Invalid username ({loginViewModel.Username}) or password ({loginViewModel.Password})");
                return BadRequest("Invalid credentials");
            }

            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, loginViewModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("FirstName")
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }


        private Task<ClaimsIdentity> GetClaimsIdentity(LoginViewModel loginViewModel)
        {
            var hashedPassword = Helper.GetHash(loginViewModel.Password);
            var user = _userRepository.Find(loginViewModel.Username, hashedPassword);
            if (user != null)
            {
                var identity = new GenericIdentity(user.Username, "Token");
                var claimsIdentity = new ClaimsIdentity(identity, new[]{
                    new Claim("FirstName",user.FirstName)
                });
            }

            return Task.FromResult<ClaimsIdentity>(null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

        /// <summary>
        /// /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}