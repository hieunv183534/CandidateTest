using CandidateTest.Core.Entities;
using CandidateTest.Core.Enums;
using CandidateTest.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTest.Api.Controllers
{
    [Authorize]
    [Route("api/Question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [Authorize(Roles = "admin")]
        //[AllowAnonymous]
        [HttpPost]
        public IActionResult Add([FromBody] Question question)
        {
            var serviceResult = _questionService.Add(question);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetQuestions([FromQuery] int count, [FromQuery] int index, [FromQuery] QuestionTypeEnum type, [FromQuery] QuestionCategoryEnum category)
        {
            var serviceResult = _questionService.GetQuestions(index, count, type, category);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{questionId}")]
        public IActionResult GetQuestion([FromRoute] Guid questionId)
        {
            var serviceResult = _questionService.GetById(questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{questionId}")]
        public IActionResult UpdateQuestion([FromRoute] Guid questionId,[FromBody] Question question)
        {
            var serviceResult = _questionService.Update(question, questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{questionId}")]
        public IActionResult Delete([FromRoute] Guid questionId)
        {
            var serviceResult = _questionService.Delete(questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
