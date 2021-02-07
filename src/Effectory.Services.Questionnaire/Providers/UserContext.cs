using Effectory.Services.Questionnaire.Models;

namespace Effectory.Services.Questionnaire.Providers
{
    public class UserContext : IUserContext
    {
        public int UserId => 10;
        public DepartmentType Department => DepartmentType.Marketing;
    }
}
