using Core.Entites;
using FEEWebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")] // api/authmanagement
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly FEEDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthManagementController(
            UserManager<ApplicationUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            TokenValidationParameters tokenValidationParameters,
            FEEDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParameters = tokenValidationParameters;
            _db = db;
            _roleManager = roleManager;
        }


        [HttpPost]
        [Route("Register")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto user)
        {
            // Check if the incoming request is valid
            if (ModelState.IsValid)
            {
                // check i the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                    {
                       "Email already exist"
                    }
                    });
                }

                var newUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Email,
                    Phone = user.Phone,
                    Image = user.Image,
                    ArabicName = user.ArabicName,
                    EnglishName = user.EnglishName,
                    DepartmentId = user.DepartmentId,
                    EmailConfirmed = true,
                    DataOfBirth = user.DataOfBirth,
                    AcademicNumber = user.AcademicNumber
                };
                var role = _roleManager.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();
                if (role.Name.Trim() == Core.Enums.Roles.Student.ToString())
                    user.Title = "طالب";
                if (role.Name.Trim() == Core.Enums.Roles.Staff.ToString())
                    user.Title = "أعضاء هيئة التدريس";

                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var createdUser = await _userManager.FindByIdAsync(newUser.Id);

                    if (createdUser != null)
                    {
                        var result = await _userManager.AddToRoleAsync(createdUser, role.Name);
                      
                        await _userManager.UpdateAsync(createdUser);

                        if (result.Succeeded)
                        {
                            return Ok(new RegistrationResponse()
                            {
                                Success = true,
                            });
                        }
                    }

                }

                return new JsonResult(new RegistrationResponse()
                {
                    Success = false,
                    Errors = isCreated.Errors.Select(x => x.Description).ToList()
                }
                        )
                { StatusCode = 500 };
            }

            return BadRequest(new RegistrationResponse()
            {
                Success = false,
                Errors = new List<string>(){
                                            "Invalid payload"
                                        }
            });
        }


        #region GenerateTokenDocumentations
        //private string GenerateJwtToken(IdentityUser user)
        //{
        //    // Now its ime to define the jwt token which will be responsible of creating our tokens
        //    var jwtTokenHandler = new JwtSecurityTokenHandler();

        //    // We get our secret from the appsettings
        //    var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        //    // we define our token descriptor
        //    // We need to utilise claims which are properties in our token which gives information about the token
        //    // which belong to the specific user who it belongs to
        //    // so it could contain their id, name, email the good part is that these information
        //    // are generated by our server and identity framework which is valid and trusted
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim("Id", user.Id),
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        // the JTI is used for our refresh token which we will be convering in the next video
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    }),
        //        // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
        //        // but since this is a demo app we can extend it to fit our current need
        //        Expires = DateTime.UtcNow.AddSeconds(30),
        //        // here we are adding the encryption alogorithim information which will be used to decrypt our token
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        //    };

        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        //    var jwtToken = jwtTokenHandler.WriteToken(token);

        //    return jwtToken;
        //}
        #endregion


        private async Task<AuthResult> GenerateJwtToken(IdentityUser user, List<string> roles)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var claims = new List<Claim>()
                {
                 new Claim("Id", user.Id),
                 new Claim(ClaimTypes.NameIdentifier,user.Id),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
                var identityRole = _roleManager.Roles.Where(x => x.Name == role).FirstOrDefault();
                var permissions = _roleManager.GetClaimsAsync(identityRole).Result;
                foreach (var item in permissions)
                {
                    claims.Add(new Claim("Permission", item.Value));
                }
            });
           
            var claimsIdentity = new ClaimsIdentity(claims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsUsed = false,
                UserId = user.Id,
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(1),
                IsRevoked = false,
                Token = RandomString(25) + Guid.NewGuid()
            };

            await _db.RefreshTokens.AddAsync(refreshToken);
            await _db.SaveChangesAsync();

            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
                RefreshToken = refreshToken.Token
            };
        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                // check if the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    // We dont want to give to much information on why the request has failed for security reasons
                    return BadRequest(new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>(){
                                        "Invalid authentication request"
                                    }
                    });
                }

                // Now we need to check if the user has inputed the right password
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (isCorrect)
                {
                    var userRoles = await _userManager.GetRolesAsync(existingUser);

                    var jwtToken = await GenerateJwtToken(existingUser, userRoles.ToList());

                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken.Token
                    });
                }
                else
                {
                    // We dont want to give to much information on why the request has failed for security reasons
                    return BadRequest(new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>(){
                                         "Invalid authentication request"
                                    }
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Success = false,
                Errors = new List<string>(){
                                        "Invalid payload"
                                    }
            });
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var res = await VerifyToken(tokenRequest);

                if (res == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                    "Invalid tokens"
                },
                        Success = false
                    });
                }

                return Ok(res);
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                "Invalid payload"
            },
                Success = false
            });
        }

        private async Task<AuthResult> VerifyToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // This validation function will make sure that the token meets the validation parameters
                // and its an actual jwt token not just a random string
                var principal = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

                // Now we need to check if the token has a valid security algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false)
                    {
                        return null;
                    }
                }

                // Will get the time stamp in unix time
                var utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                // we convert the expiry date from seconds to the date
                var expDate = UnixTimeStampToDateTime(utcExpiryDate);

                if (expDate > DateTime.UtcNow)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "We cannot refresh this since the token has not expired" },
                        Success = false
                    };
                }

                // Check the token we got if its saved in the db
                var storedRefreshToken = _db.RefreshTokens.FirstOrDefault(x => x.Token == tokenRequest.RefreshToken);

                if (storedRefreshToken == null)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "refresh token doesnt exist" },
                        Success = false
                    };
                }

                // Check the date of the saved token if it has expired
                if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has expired, user needs to relogin" },
                        Success = false
                    };
                }

                // check if the refresh token has been used
                if (storedRefreshToken.IsUsed)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been used" },
                        Success = false
                    };
                }

                // Check if the token is revoked
                if (storedRefreshToken.IsRevoked)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been revoked" },
                        Success = false
                    };
                }

                // we are getting here the jwt token id
                var jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                // check the id that the recieved token has against the id saved in the db
                if (storedRefreshToken.JwtId != jti)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "the token doenst mateched the saved token" },
                        Success = false
                    };
                }

                storedRefreshToken.IsUsed = true;
                _db.RefreshTokens.Update(storedRefreshToken);
                await _db.SaveChangesAsync();

                var dbUser = await _userManager.FindByIdAsync(storedRefreshToken.UserId);
                var userRoles = await _userManager.GetRolesAsync(dbUser);

                return await GenerateJwtToken(dbUser, userRoles.ToList());
            }
            catch
            {
                return null;
            }
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
    }
}
