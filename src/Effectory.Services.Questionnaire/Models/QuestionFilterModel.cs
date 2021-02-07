namespace Effectory.Services.Questionnaire.Models
{
    public class QuestionFilterModel
    {
        public int QuestionnaireId { get; set; }
        public int SubjectId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
