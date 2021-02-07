namespace Effectory.Services.Questionnaire.Models
{
    public class TextAnswerModel : BaseUserAnswerModel
    {
        public string Value { get; set; }
        public override AnswerType AnswerType => AnswerType.Text;
    }
}