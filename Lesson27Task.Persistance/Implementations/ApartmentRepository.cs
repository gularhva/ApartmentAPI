using Lesson27Task.Data;
using Lesson27Task.Data.Entities;
using Lesson27Task.Services.Abstractions;

namespace Lesson27Task.Services.Implementations
{
    public class ApartmentRepository : GenericRepository<Apartment>,IApartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public ApartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void MyMethod(int id)
        {
            _context.Apartments.Find(id);
        }
    }
}
