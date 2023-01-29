using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env; 
        private string localDirectoryPath = "files/CategoryImages/";

        public UserController(IMapper mapper, IGenericService genericService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _genericService = genericService;
            _env = env;
        }

        #region User

        // Method to get the list of the users
        [HttpGet(Name = "GetUsers")]
        public async Task<IResult> GetUser()
        {
            var result = await _genericService.GetUserList();
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(result);
        }

        #endregion
    }
}
