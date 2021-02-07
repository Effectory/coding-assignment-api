using Effectory.Services.Questionnaire.Messages;
using Effectory.Services.Questionnaire.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Handlers
{
    public class TextAnswerMessageHandler : IHandler<TextAnswerMessage>
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public TextAnswerMessageHandler(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public Task Handle(TextAnswerMessage message)
        {
            return _questionnaireRepository.SaveAnswerAsync(message.UserId, message.Department, new Models.TextAnswerModel
            {
                QuestionId = message.QuestionId,
                Value = message.Value
            }, CancellationToken.None);
        }
    }
}
