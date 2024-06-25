using Lesson27Task.Application.Abstractions;

namespace Lesson27Task.Services.Abstractions
{
    public interface IUnitOfWork:IDisposable
    {
        IApartmentRepository ApartmentR { get; }
        IProductRepository ProductR { get; }
        void Save();
    }
}
