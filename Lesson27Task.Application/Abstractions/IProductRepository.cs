using Lesson27Task.Data.Entities;
using Lesson27Task.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson27Task.Application.Abstractions
{
    public interface IProductRepository:IGenericRepository<Product>
    {
    }
}
