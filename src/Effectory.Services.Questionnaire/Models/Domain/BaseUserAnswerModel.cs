namespace Effectory.Services.Questionnaire.Models
{
    public abstract class BaseUserAnswerModel
    {
        public int QuestionId { get; set; }
        public abstract AnswerType AnswerType { get; }
    }
}