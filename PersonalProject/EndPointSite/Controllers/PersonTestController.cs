using Application.Personal.DTO;
using Application.Personal.ServiceTest;
using Domain.Personal;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace EndPointSite.Controllers
{
    public class PersonTestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonServices _personServices;

        public PersonTestController(IMapper mapper, IPersonServices personServices)
        {
            _mapper = mapper;
            _personServices = personServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _personServices.GetAllAsync();
            if (res.Any())
            {
                var mapRes = _mapper.Map<IEnumerable<ResponsePersonDTO>>(res);
                return Ok(mapRes);
            }
            return NoContent();
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _personServices.GetByIdAsync(id);
            if (res is not null)
            {
                var mapRes = _mapper.Map<ResponsePersonDTO>(res);
                return Ok(mapRes);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPersonViewModel createPostDTO)
        {
            var mapInput = _mapper.Map<Person>(createPostDTO);
            var res = await _personServices.AddAsync(mapInput);
            if (res is not null)
            {
                var mapRes = _mapper.Map<ResponsePersonDTO>(res);

                // It is better to pass CreatedAtAction
                return CreatedAtAction(nameof(GetById), new { id = mapRes.Id }, mapRes);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditPersonViewModel updatePostDTO)
        {
            var mapInput = _mapper.Map<Person>(updatePostDTO);
            var res = await _personServices.EditAsync(mapInput);
            if (res is not null)
            {
                var mapRes = _mapper.Map<ResponsePersonDTO>(res);
                return Ok(mapRes);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _personServices.DeleteAsync(id);
            if (res is true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
