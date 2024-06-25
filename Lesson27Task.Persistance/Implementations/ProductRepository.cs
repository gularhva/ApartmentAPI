using Lesson27Task.Application.Abstractions;
using Lesson27Task.Data;
using Lesson27Task.Data.Entities;
using Lesson27Task.Services.Abstractions;
using Lesson27Task.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson27Task.Persistance.Implementations
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
