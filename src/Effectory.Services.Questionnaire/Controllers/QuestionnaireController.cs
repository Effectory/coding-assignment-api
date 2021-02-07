using EasyNetQ;
using Effectory.Services.Questionnaire.Messages;
using Effectory.Services.Questionnaire.Models;
using Effectory.Services.Questionnaire.Providers;
using Effectory.Services.Questionnaire.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly ILogger<QuestionnaireController> _logger;
        private readonly IUserContext _userContext;
        private readonly IBus _bus;
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public QuestionnaireController(ILogger<QuestionnaireController> logger,
            IUserContext userContext,
            IBus bus,
            IQuestionnaireRepository questionnaireRepository)
        {
            _logger = logger;
            _userContext = userContext;
            _bus = bus;
            _questionnaireRepository = questionnaireRepository;
        }

        /// <summary>
        /// Returns a paged list of the questions and answers
        /// </summary>
        /// <param name="questionnaireId">The questionnaire id</param>
        /// <param name="subjectId">The subject id</param>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="PagedResult<QuestionModel>"/></returns>
        [HttpGet]
        [Route("{questionnaireId:int}/subjects/{subjectId:int}/questions")]
        public Task<PagedResult<QuestionModel>> GetQuestions([FromRoute] int questionnaireId, [FromRoute] int subjectId, [FromQuery] int page = 0, [FromQuery] int pageSize = 5, CancellationToken cancellationToken = default)
        {
            return _questionnaireRepository.GetQuestionsAsync(new QuestionFilterModel
            {
                QuestionnaireId = questionnaireId,
                SubjectId = subjectId,
                Page = page,
                PageSize = pageSize
            }, cancellationToken);
        }

        /// <summary>
        /// Posts an answer for a question
        /// </summary>
        /// <param name="model">The user's answer model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A status 201 created</returns>
        [HttpPost]
        [Route("text")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult> PostUserAnswer([FromBody] PostUserAnswerApiModel model, CancellationToken cancellationToken)
        {
            switch (model.AnswerType)
            {
                case AnswerType.SingleChoice:
                    await _bus.PubSub.PublishAsync(new SingleChoiceAnswerMessage
                    {
                        UserId = _userContext.UserId,
                        Department = _userContext.Department,
                        QuestionId = model.QuestionId,
                        AnswerId = model.AnswerId
                    }, cancellationToken);
                    break;
                case AnswerType.Text:
                    await _bus.PubSub.PublishAsync(new TextAnswerMessage
                    {
                        UserId = _userContext.UserId,
                        Department = _userContext.Department,
                        QuestionId = model.QuestionId,
                        Value = model.Value
                    }, cancellationToken);
                    break;
                default:
                    _logger.LogWarning($"The {nameof(model.AnswerType)} of {model.AnswerType} is not supported.");
                    return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Accepted();
        }
    }
}
