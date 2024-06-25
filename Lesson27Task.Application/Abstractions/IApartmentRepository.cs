using Lesson27Task.Data.Entities;

namespace Lesson27Task.Services.Abstractions
{
    public interface IApartmentRepository:IGenericRepository<Apartment>
    {
        void MyMethod(int id);
    }
}
