using CandidateTest.Api.Authentication;
using CandidateTest.Core.Entities;
using CandidateTest.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTest.Api.Controllers
{
    [Authorize]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Delare

        protected IBaseService<TokenAccount> _tokenAccountService;
        protected IAccountService _accountService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        #endregion

        #region Consstructor

        public AccountController(IBaseService<TokenAccount> tokenAccountService, IAccountService accountService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _tokenAccountService = tokenAccountService;
            _accountService = accountService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        #endregion

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Account account)
        {
            var token = _jwtAuthenticationManager.Authenticate(account.UserName, account.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new ResponseModel(1000, "OK", token ));
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] Account account)
        {
            var serviceResult = _accountService.Add(account);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add([FromBody] Account account)
        {
            var serviceResult = _accountService.Add(account); 
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{accountId}")]
        public IActionResult Update([FromBody] Account account, [FromRoute] Guid accountId)
        {
            var serviceResult = _accountService.Update(account, accountId); 
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetAccounts([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms, [FromQuery] string role)
        {
            var serviceResult = _accountService.GetAccounts(index, count, searchTerms, role);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{accountId}")]
        public IActionResult GetAccount([FromRoute] Guid accountId)
        {
            var serviceResult = _accountService.GetById(accountId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{accountId}")]
        public IActionResult Delete([FromRoute] Guid accountId)
        {
            var serviceResult = _accountService.Delete(accountId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
