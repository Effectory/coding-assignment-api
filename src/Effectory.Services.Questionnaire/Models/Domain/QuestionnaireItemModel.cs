using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public abstract class QuestionnaireItemModel
    {
        public int OrderNumber { get; set; }
        public Dictionary<string, string> Texts { get; set; }
        public abstract ItemType ItemType { get; }
    }
}
