using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NoInc.BusinessLogic.Interfaces;
using NoInc.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NoInc.TestProject
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            UserEntity user;

            try
            {
                var credentials = GetCredentialsFromHeader();
                var username = credentials[0];
                var password = credentials[1];
                user = await _userService.Authenticate(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Error Occured.Authorization failed.");
            }

            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid Credentials");
            }

            var claims = CreateClaims();
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);

            string[] GetCredentialsFromHeader()
            {
                var authorizationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var authorizationHeaderByteArray = Convert.FromBase64String(authorizationHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(authorizationHeaderByteArray).Split(new[] { ':' }, 2);
                return credentials;
            }

            IEnumerable<Claim> CreateClaims()
            {
                return new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                };
            }
        }

    }
}
