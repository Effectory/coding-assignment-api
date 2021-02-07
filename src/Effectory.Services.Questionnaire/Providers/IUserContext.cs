using Effectory.Services.Questionnaire.Models;

namespace Effectory.Services.Questionnaire.Providers
{
    public interface IUserContext
    {
        /// <summary>
        /// The current user id
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// The department of the current user
        /// </summary>
        DepartmentType Department { get; }
    }
}
