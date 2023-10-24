using consultorio.Models;
using consultorio.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return new BadRequestObjectResult(new { code = 404, message = "Consulta realizada", data = "Asegurado no encontrado" });

        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await archivo.CopyToAsync(stream);

                    var fileUpload = new Document
                    {
                        Name = archivo.FileName,
                        Content = stream.ToArray()
                    };

                    // Guardar el archivo en la base de datos utilizando Entity Framework Core
                    _context.Documents.Add(fileUpload);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return Ok(new { code = 200, message = "Consulta realizada", data = "Documento Creado" });

        }



    }
}
