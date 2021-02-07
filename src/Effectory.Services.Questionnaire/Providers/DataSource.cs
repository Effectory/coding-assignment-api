using Effectory.Services.Questionnaire.Helpers;
using Effectory.Services.Questionnaire.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Providers
{
    internal class DataSource : IDataSource
    {
        private IReadOnlyCollection<QuestionnaireModel> _loadedData = null;        

        public async ValueTask<IReadOnlyCollection<QuestionnaireModel>> GetQuestionnaires(CancellationToken cancellationToken)
        {
            if (_loadedData != null)
                return _loadedData;

            using FileStream openStream = File.OpenRead(@"data/questionnaire.json");
            var data = await JsonSerializer.DeserializeAsync<QuestionnaireModel>(openStream, SerializationHelper.SerializerOptions.Value, cancellationToken);
            _loadedData = new List<QuestionnaireModel> { data };

            return _loadedData;
        }
    }
}
