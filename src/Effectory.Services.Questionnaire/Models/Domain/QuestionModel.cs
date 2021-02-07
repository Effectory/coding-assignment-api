using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public class QuestionModel : QuestionnaireItemModel
    {
        public int SubjectId { get; set; }
        public int QuestionId { get; set; }
        public AnswerCategoryType AnswerCategoryType { get; set; }
        public override ItemType ItemType => ItemType.Question;
        public ICollection<AnswerModel> QuestionnaireItems { get; set; }
    }
}
