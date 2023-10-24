using consultorio.Models;
using consultorio.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredController : ControllerBase
    {
        private readonly ConsultorioDbContext _context;


        public InsuredController(ConsultorioDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateInsured")]
        public IActionResult CreateInsured([FromBody] JObject json)
        {

            InsuredDto i = JsonConvert.DeserializeObject<InsuredDto>(json.ToString());

            var newInsured = new Insured
            {
                Identification = i.Identification,
                Name = i.Name,
                Phone = i.Phone,
                Age = i.Age
            };

            _context.Insureds.Add(newInsured);
            _context.SaveChanges();


            return Ok(new { message = "Consulta realizada", data = newInsured });
        }

        [HttpGet("GetInsured")]
        public IActionResult GetInsured()
        {
            var res = from i in _context.Insureds.ToList()
                      select i;

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }

        [HttpGet("GetInsured/{IdInsured}")]
        public IActionResult GetInsured(int IdInsured)
        {
            var res = (from i in _context.Insureds.ToList()
                       where i.Idinsured == IdInsured
                       select i).FirstOrDefault();

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }

        [HttpPut("UpdateInsured/{Idinsured}")]
        public IActionResult UpdateInsured(int Idinsured, [FromBody] JObject json)
        {
            var res = (from i in _context.Insureds.ToList()
                       where i.Idinsured == Idinsured
                       select i).FirstOrDefault();

            if (res != null)
            {

                InsuredDto i = JsonConvert.DeserializeObject<InsuredDto>(json.ToString());

                var updateInsured = new Insured
                {
                    Identification = i.Identification,
                    Name = i.Name,
                    Phone = i.Phone,
                    Age = i.Age
                };

                res.Identification = updateInsured.Identification;
                res.Name = updateInsured.Name;
                res.Phone = updateInsured.Phone;
                res.Age = updateInsured.Age;

                _context.SaveChanges();

                return Ok(new { code = 200, message = "Consulta realizada", data = updateInsured });

            }
            return new BadRequestObjectResult(new { code = 404, message = "Asegurado no encontrado", });

        }

        [HttpDelete("DeleteInsured")]
        public IActionResult DeleteInsured(int IdInsured)
        {
            var insuredToDelete = _context.Insureds.FirstOrDefault(f => f.Idinsured == IdInsured);

            if (insuredToDelete != null)
            {
                _context.Insureds.Remove(insuredToDelete);
                _context.SaveChanges();

                return Ok(new { code = 200, message = "Consulta realizada", data = "Asegurado eliminado" });
            }

            return Ok(new { code = 204, message = "Consulta realizada", data = "Asegurado no encontrado" });

        }


    }
}
