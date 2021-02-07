using System.Threading.Tasks;

namespace Effectory.Services.Questionnaire.Handlers
{
    public interface IHandler<T>
    {
        Task Handle(T message);
    }
}
