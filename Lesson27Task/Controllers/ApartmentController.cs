using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;
using Lesson27Task.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson27Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apService;
        public ApartmentController(IApartmentService apService)
        {
            _apService = apService;
        }
        [HttpGet]
        public ResponseModel<IEnumerable<Apartment>> Get()
        {
            var data = _apService.Get();
            return data;
        }
        [HttpPost]
        public ResponseModel<Apartment> Post([FromQuery] ApartmentDTO model)
        {
            var data = _apService.Post(model);
            return data;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseModel<Apartment> Delete([FromRoute] int id)
        {
            var data = _apService.Delete(id);
            return data;
        }
        [HttpPut]
        [Route("Put/{id}")]
        public ResponseModel<Apartment> Put([FromRoute] int id, ApartmentDTO model)
        {
            var data = _apService.Update(id, model);
            return data;
        }
    }
}
