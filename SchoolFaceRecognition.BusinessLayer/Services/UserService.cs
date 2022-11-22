using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;

namespace SchoolFaceRecognition.BL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly HttpContext _httpContext;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager,
                            IHttpContextAccessor httpContextAccessor,
                            IMapper mapper)
        {
            _userManager = userManager;
            _httpContext = httpContextAccessor.HttpContext;
            _mapper = mapper;
        }

        public async Task<Response> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto is null)
                throw new DataNotFoundException();

            AppUser appUser = new()
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                City = createUserDto.City,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, createUserDto.Password);

            if (identityResult.Succeeded)
            {
                return new SuccessResponse<object>();
            }
            else
            {
                List<string> errors = identityResult.Errors.Select(x => x.Description).ToList();

                return new ErrorResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        public async Task<Response> GetUserAsync()
        {
            AppUser appUser = await _userManager.GetUserAsync(_httpContext.User);

            if (appUser is null)
                return new ErrorResponse(ConstantLiterals.UserNotFoundMessage);

            AppUserDto appUserDto = _mapper.Map<AppUserDto>(appUser);

            return new SuccessResponse<AppUserDto>(appUserDto);
        }
    }
}
