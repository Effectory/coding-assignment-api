using System.Collections.Generic;

namespace Effectory.Services.Questionnaire.Models
{
    public class PagedResult<T>
    {
        public long Count { get; set; }
        public IReadOnlyCollection<T> Records { get; set; }
    }
}
