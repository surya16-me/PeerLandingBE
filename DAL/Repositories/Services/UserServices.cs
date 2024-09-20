using DAL.DTO.Req;
using DAL.DTO.Res;
using DAL.Models;
using DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ResLoginDto> Login(ReqLoginUserDto reqLoginUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(ReqRegisterUserDto reqRegisterUser)
        {
            var isAnyEmail = await _context.MstUsers.SingleOrDefaultAsync(u =>  u.Email == reqRegisterUser.Email);
            if (isAnyEmail != null) 
            {
                throw new Exception("Email already used");
            }
            var newUser = new MstUser
            {
                Name = reqRegisterUser.Name,
                Email = reqRegisterUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(reqRegisterUser.Password),
                Role = reqRegisterUser.Role,

            };

            await _context.MstUsers.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser.Name;

        }
    }
}
