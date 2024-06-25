using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;

namespace Lesson27Task.Services.Abstractions
{
    public interface IApartmentService
    {
        public ResponseModel<IEnumerable<Apartment>> Get();
        public ResponseModel<Apartment> Post(ApartmentDTO model);
        public ResponseModel<Apartment> Delete(int id);
        public ResponseModel<Apartment> Update(int id, ApartmentDTO model);
        public Apartment GetById(int id);
    }
}
