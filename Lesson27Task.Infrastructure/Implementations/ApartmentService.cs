using AutoMapper;
using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;
using Lesson27Task.Services.Abstractions;

namespace Lesson27Task.Services.Implementations
{
    public class ApartmentService : IApartmentService
    {
        private readonly IMapper _mapper;
        //private readonly IApartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            //_repository = repository;
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<IEnumerable<Apartment>> Get()
        {
            ResponseModel<IEnumerable<Apartment>> rm = new ResponseModel<IEnumerable<Apartment>>();
            try
            {
                //rm.Data = _repository.GetAll();
                rm.Data=_unitOfWork.ApartmentR.GetAll();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Apartment> Post(ApartmentDTO model)
        {
            ResponseModel<Apartment> rm = new ResponseModel<Apartment>();
            try
            {
                Apartment apartment = _mapper.Map<Apartment>(model);
                rm.Data = apartment;
                //_repository.Add(apartment);
                //_repository.Save();
                _unitOfWork.ApartmentR.Add(apartment);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Apartment> Delete(int id)
        {
            ResponseModel<Apartment> rm = new ResponseModel<Apartment>();
            try
            {
                var data = _unitOfWork.ApartmentR.GetById(id);
                //_repository.Delete(data);
                _unitOfWork.ApartmentR.Delete(data);
                rm.Data = data;
                //_repository.Save();
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<Apartment> Update(int id, ApartmentDTO model)
        {
            ResponseModel<Apartment> rm = new ResponseModel<Apartment>();
            try
            {
                var data = _unitOfWork.ApartmentR.GetById(id);
                _mapper.Map<ApartmentDTO, Apartment>(model, data);
                //_repository.Update(data);
                _unitOfWork.ApartmentR.Update(data);
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

        public Apartment GetById(int id)
        {
            var data = _unitOfWork.ApartmentR.GetById(id);
            return data;
        }
    }
}
