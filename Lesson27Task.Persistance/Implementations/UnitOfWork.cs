using Lesson27Task.Application.Abstractions;
using Lesson27Task.Data;
using Lesson27Task.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lesson27Task.Services.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
            ApartmentR=new ApartmentRepository(_context);
        }
        public IApartmentRepository ApartmentR {  get; private set; }

        public IProductRepository ProductR { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
