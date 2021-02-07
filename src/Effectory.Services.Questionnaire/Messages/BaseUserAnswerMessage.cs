using Effectory.Services.Questionnaire.Models;

namespace Effectory.Services.Questionnaire.Messages
{
    public abstract class BaseUserAnswerMessage
    {
        public int UserId { get; set; }
        public DepartmentType Department { get; set; }
    }
}
