using BLL.IService;
using BLL.Service;
using DAL.Entities;
using Football.Models.AuthVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sendmail.NewFolder;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly ISendMailService _sendMailService;

        public AuthController(UserManager<ApplicationUser> userManager,IAuthService authService, ISendMailService sendMailService)
        {
            _userManager = userManager;
            _authService = authService;
            _sendMailService = sendMailService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(registerModel);
            return Ok(result);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var result = await _authService.LoginAsync(loginUser);
            return Ok(result);
        }
        //[HttpPost]
        //public async Task<IActionResult> sendMail(MailVM mailVM)
        //{
        //    await _sendMailService.sendEmailAsync(mailVM.ToMail,mailVM.subject,mailVM.body);
        //    return Ok("send");
        //}
    }
}
