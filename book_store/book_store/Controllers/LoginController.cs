using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Text;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace book_store.Controllers
{
    public class LoginController : ApiController
    {
        private IUserRepository repository;

        public LoginController()
        {
            repository = new UserSqlImpl();
        }

        [HttpPost]
        public IHttpActionResult Login(UserDTO request)
        {
            User user = repository.GetUserByid(request.Email);
            if (user == null || user.Email != request.Email)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            string token = Createtoken(user);

            return Ok(token);
        }

        private string Createtoken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email as String, user.Email as String));
            claims.Add(new Claim(ClaimTypes.Role as String, user.Isadmin.ToString() as string));
            //Debug.WriteLine("\nappsetting token :" + ConfigurationManager.AppSettings["token"] + "\n");
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["token"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var token= new JwtSecurityToken(
                claims :claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Debug.WriteLine("PasswordHash = "+ passwordHash+"\n, ComputeHash = "+computeHash+"\n");
                return computeHash.SequenceEqual(passwordHash);
            }

        }
    }
}
