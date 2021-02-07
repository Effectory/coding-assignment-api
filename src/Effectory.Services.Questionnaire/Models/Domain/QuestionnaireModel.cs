using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public class QuestionnaireModel
    {
        public int QuestionnaireId { get; set; }
        public ICollection<SubjectModel> QuestionnaireItems { get; set; }
    }    
}
