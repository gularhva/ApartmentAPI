using AutoMapper;
using Lesson27Task.Data;
using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;
using Lesson27Task.Services.Abstractions;

namespace Lesson27Task.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<IEnumerable<Product>> Get()
        {
            ResponseModel<IEnumerable<Product>> rm = new ResponseModel<IEnumerable<Product>>();
            try
            {
                rm.Data = _unitOfWork.ProductR.GetAll();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Product> Post(ProductDTO model)
        {
            ResponseModel<Product> rm = new ResponseModel<Product>();
            try
            {
                Product product = _mapper.Map<Product>(model);
                rm.Data = product;
                _unitOfWork.ProductR.Add(product);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Product> Delete(int id)
        {
            ResponseModel<Product> rm = new ResponseModel<Product>();
            try
            {
                var data = _unitOfWork.ProductR.GetById(id);
                _unitOfWork.ProductR.Delete(data);
                rm.Data = data;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Product> Update(int id, ProductDTO model)
        {
            ResponseModel<Product> rm = new ResponseModel<Product>();
            try
            {
                var data = _unitOfWork.ProductR.GetById(id);
                _mapper.Map<ProductDTO, Product>(model, data);
                _unitOfWork.ProductR.Update(data);
                rm.Data = data;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
    }
}
