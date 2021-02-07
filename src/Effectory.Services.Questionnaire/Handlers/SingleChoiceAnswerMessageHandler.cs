using Effectory.Services.Questionnaire.Messages;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Handlers
{
    public class SingleChoiceAnswerMessageHandler : IHandler<SingleChoiceAnswerMessage>
    {
        public Task Handle(SingleChoiceAnswerMessage message)
        {
            return Task.CompletedTask;
        }
    }
}
