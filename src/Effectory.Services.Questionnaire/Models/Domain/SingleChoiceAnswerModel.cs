namespace Effectory.Services.Questionnaire.Models
{
    public class SingleChoiceAnswerModel : BaseUserAnswerModel
    {
        public int AnswerId { get; set; }
        public override AnswerType AnswerType => AnswerType.SingleChoice;
    }
}