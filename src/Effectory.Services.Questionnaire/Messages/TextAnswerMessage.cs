namespace Effectory.Services.Questionnaire.Messages
{
    public class TextAnswerMessage : BaseUserAnswerMessage
    {
        public int QuestionId { get; set; }
        public string Value { get; set; }
    }
}
