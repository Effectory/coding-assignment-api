using Effectory.Services.Questionnaire.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Repositories
{
    public interface IQuestionnaireRepository
    {
        /// <summary>
        /// Returns a list of the questions along with their answers based on the provided filter <see cref="QuestionFilterModel"/>
        /// </summary>
        /// <param name="filter">The filter to apply on the questions</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<PagedResult<QuestionModel>> GetQuestionsAsync(QuestionFilterModel filter, CancellationToken cancellationToken);

        /// <summary>
        /// Saves a new answer
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="department">The department of the user</param>
        /// <param name="model">The answer model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task SaveAnswerAsync(int userId, DepartmentType department, TextAnswerModel model, CancellationToken cancellationToken);
    }
}
