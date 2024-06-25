using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;

namespace Lesson27Task.Services.Abstractions
{
    public interface IProductService
    {
        public ResponseModel<IEnumerable<Product>> Get();
        public ResponseModel<Product> Post(ProductDTO model);
        public ResponseModel<Product> Delete(int id);
        public ResponseModel<Product> Update(int id, ProductDTO model);
    }
}
