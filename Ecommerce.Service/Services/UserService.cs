using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Helper;

namespace Ecommerce.Service.Services
{
    public class UserService : EcommerceServices<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IUserProfileRepository userProfileRepository, IMapper mapper) : base(userRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Register(UserDto userDto)
        {
            var acc = _userRepository.GetFirstOrDefaultAsync(x => x.Username.ToLower() == userDto.Username.ToLower());
            if (acc == null)
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                AuthenUserHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
                // Create user
                var user = new User
                {
                    Username = userDto.Username,
                    Roles = Role.Customer,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = Status.InActive,
                    IsConfirmation = false
                };

                await _userRepository.AddAsync(user,true);

                // Create user profile
                var userProfile = new UserProfile
                {
                    Name = userDto.Username,
                    Gender = (Common.Infrastructure.ViewModel.Admin.ViewModel.Gender)userDto.Gender,
                    Birthday = userDto.Birthday,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    UserId = user.Id,
                };

                await _userProfileRepository.AddAsync(userProfile,true);

                // Send mail

                // Thanh cong
                return userDto;
            }
            return null;
        }

        public async  Task<UserDto> Login(string username, string password)
        {
            var user = await _userRepository.Authenticate(username, password);
            if (user == null)
            {
                return null;
            }
            var userProfile =  _userProfileRepository.GetFirstOrDefaultAsync(x => x.UserId == user.Id);
            var userdto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                //Gender = userProfile.Gender,
                Birthday = userProfile.Birthday,
                Email = userProfile.Email,
                Phone = userProfile.Phone,
                Address = userProfile.Address,
                Avatar = userProfile.AvatarUrl
            };
            // map useDto
            return userdto;
        }

        public async Task<bool> ActiveUser(string username)
        {
            var acc = _userRepository.GetFirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());

            if (acc.IsConfirmation == false)
            {
                acc.IsConfirmation = true;
                acc.Status = Status.Active;
                await _userRepository.UpdateAsync(acc,true);
                return true;
            }

            return false;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user =  _userRepository.GetFirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
            return _mapper.Map<UserDto>(user);
        }
    }
}
