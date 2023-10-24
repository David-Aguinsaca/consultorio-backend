using consultorio.Models;
using consultorio.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SureController : ControllerBase
    {
        private readonly ConsultorioDbContext _context;
        public SureController(ConsultorioDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateSure")]
        public IActionResult CreateSure([FromBody] JObject json)
        {

            SureDto i = JsonConvert.DeserializeObject<SureDto>(json.ToString());

            var newSuere = new Sure
            {
                Code = i.Code,
                Name = i.Name,
                Sumassured = i.Sumassured,
                Prima = i.Prima
            };

            _context.Sures.Add(newSuere);
            _context.SaveChanges();

            return Ok(new { message = "Consulta realizada", data = newSuere });
        }

        [HttpGet("GetSure")]
        public IActionResult GetSure()
        {
            var res = from i in _context.Sures.ToList()
                      select i;

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }

        [HttpGet("GetSure/{Idsure}")]
        public IActionResult GetInsured(int Idsure)
        {
            var res = (from i in _context.Sures.ToList()
                       where i.Idsure == Idsure
                       select i).FirstOrDefault();

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }

        [HttpPut("UpdateSure/{Idsure}")]
        public IActionResult UpdateInsured(int Idsure, [FromBody] JObject json)
        {
            var res = (from i in _context.Sures.ToList()
                       where i.Idsure == Idsure
                       select i).FirstOrDefault();

            if (res != null)
            {

                SureDto i = JsonConvert.DeserializeObject<SureDto>(json.ToString());

                var updateSure = new Sure
                {
                    Code = i.Code,
                    Name = i.Name,
                    Sumassured = i.Sumassured,
                    Prima = i.Prima
                };

                res.Code = updateSure.Code;
                res.Name = updateSure.Name;
                res.Sumassured = updateSure.Sumassured;
                res.Prima = updateSure.Prima;

                _context.SaveChanges();

                return Ok(new { code = 200, message = "Consulta realizada", data = updateSure });

            }
            return new BadRequestObjectResult(new { code = 404, message = "Seguro no encontrado", });

        }

        [HttpDelete("DeleteSure")]
        public IActionResult DeleteInsured(int Idsure)
        {
            var sureToDelete = _context.Sures.FirstOrDefault(f => f.Idsure == Idsure);

            if (sureToDelete != null)
            {
                _context.Sures.Remove(sureToDelete);
                _context.SaveChanges();

                return Ok(new { code = 200, message = "Consulta realizada", data = "Seguro eliminado" });
            }

            return Ok(new { code = 404, message = "Consulta realizada", data = "Seguro no encontrado" });

        }
    }
}
