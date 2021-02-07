namespace Effectory.Services.Questionnaire.Models
{
    public class PostUserAnswerApiModel
    {
        public int QuestionId { get; set; }
        public AnswerType AnswerType { get; set; }
        
        public string Value { get; set; }
        public int AnswerId { get; set; }
    }
}
