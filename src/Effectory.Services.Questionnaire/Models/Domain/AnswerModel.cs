namespace Effectory.Services.Questionnaire.Models
{
    public class AnswerModel : QuestionnaireItemModel
    {
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public AnswerType AnswerType { get; set; }
        public override ItemType ItemType => ItemType.Answer;
    }
}