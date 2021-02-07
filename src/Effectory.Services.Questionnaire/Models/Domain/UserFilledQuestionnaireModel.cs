using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public class UserFilledQuestionnaireModel
    {
        public int Questionnaire { get; set; }
        public int UserId { get; set; }
        public DepartmentType Department { get; set; }
        public ICollection<BaseUserAnswerModel> Answers { get; set; } = new List<BaseUserAnswerModel>();
    }
}