using Effectory.Services.Questionnaire.Models;
using Effectory.Services.Questionnaire.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Repositories
{
    internal class QuestionnaireRepository : IQuestionnaireRepository
    {
        private static readonly IList<UserFilledQuestionnaireModel> _userFilledQuestionnaires = new List<UserFilledQuestionnaireModel>();

        private readonly IDataSource _dataSource;

        public QuestionnaireRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<PagedResult<QuestionModel>> GetQuestionsAsync(QuestionFilterModel filter, CancellationToken cancellationToken)
        {
            var questionnaires = await _dataSource.GetQuestionnaires(cancellationToken);
            var query = questionnaires.SelectMany(x => x.QuestionnaireItems).Where(x => x.SubjectId == filter.SubjectId).SelectMany(x => x.QuestionnaireItems);

            return new PagedResult<QuestionModel>
            {
                Count = query.LongCount(),
                Records = query.Skip(filter.Page * filter.PageSize)
                               .Take(filter.PageSize)
                               .ToList()
            };
        }

        public async Task SaveAnswerAsync(int userId, DepartmentType department, TextAnswerModel model, CancellationToken cancellationToken)
        {
            var questionnaires = await _dataSource.GetQuestionnaires(cancellationToken);

            var questionnair = questionnaires?.Where(x => x.QuestionnaireItems.Any(y => y.QuestionnaireItems.Any(z => z.QuestionId == model.QuestionId))).SingleOrDefault();

            if (questionnair == null)
            {
                throw new KeyNotFoundException($"No questionnair found having a question with the id {model.QuestionId}.");
            }

            var userQuestionnaire = _userFilledQuestionnaires.SingleOrDefault(x => x.Department == department && x.UserId == userId);

            if (userQuestionnaire == null)
            {
                userQuestionnaire = new UserFilledQuestionnaireModel { Department = department, UserId = userId };
                _userFilledQuestionnaires.Add(userQuestionnaire);
            }

            var answer = userQuestionnaire.Answers.SingleOrDefault(x => x.QuestionId == model.QuestionId) as TextAnswerModel;

            if (answer == null)
            {
                answer ??= new TextAnswerModel { QuestionId = model.QuestionId };
                userQuestionnaire.Answers.Add(answer);
            }

            answer.Value = model.Value;
        }
    }
}