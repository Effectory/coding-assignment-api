namespace Effectory.Services.Questionnaire.Messages
{
    public class SingleChoiceAnswerMessage : BaseUserAnswerMessage
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
