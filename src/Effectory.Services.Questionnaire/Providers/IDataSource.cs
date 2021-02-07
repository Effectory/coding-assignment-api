using Effectory.Services.Questionnaire.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Providers
{
    public interface IDataSource
    {
        /// <summary>
        /// Loads the questionnaires
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        ValueTask<IReadOnlyCollection<QuestionnaireModel>> GetQuestionnaires(CancellationToken cancellationToken);
    }
}
