using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public class SubjectModel : QuestionnaireItemModel
    {
        public int SubjectId { get; set; }
        public override ItemType ItemType => ItemType.Subject;
        public ICollection<QuestionModel> QuestionnaireItems { get; set; }
    }
}
