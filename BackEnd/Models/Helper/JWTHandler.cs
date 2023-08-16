using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using assignment_tess.Models;

namespace assignment_tess.Models.Helper
{
    public class JWTHandler
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        string key = "tr0VgXUIoQOyb9FNH8D31YAeUZ1I3HRcH7cws5DTPxqYm0e0MYVqVORzLurHQ8rUQBO44WGu";
        string issuer = "";

        public string CreateToken(AuthDto auth, out string err)
        {
            string jwt = "";
            err = "";

            try
            {
                string maxSession = new ConfigFile().GetAppSetting("maxSession");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim("userlogin", JsonConvert.SerializeObject(auth)));

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddHours(int.Parse(maxSession)),
                        signingCredentials: credential
                    );
                jwt = new JwtSecurityTokenHandler().WriteToken(token);
            } catch (Exception ex) 
            {
                err = "Terjadi Kesalahan. Cobalah beberapa saat lagi.";
            }
            return jwt;
        }

        public AuthDto? GetPrincipal(string token, out bool expired)
        {
            expired = false;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwt == null) return null;

                var symmetricKey = Encoding.UTF8.GetBytes(key);

                var validatinParameter = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validatinParameter, out _);
                var identity = principal?.Identity as ClaimsIdentity;

                if (identity == null) return null;
                if (!identity.IsAuthenticated) return null;

                AuthDto userLogin = new AuthDto();
                userLogin = JsonConvert.DeserializeObject<AuthDto>(identity.FindFirst("userlogin")!.Value);

                return userLogin;
            }
            catch (Exception x)
            {
                if (x.Message.ToString().Contains("expired"))
                {
                    expired = true;
                }
                Logger.Error(x, string.Format("{0}", JsonConvert.SerializeObject(token)));
                return null;
            }
        }
    }
}
