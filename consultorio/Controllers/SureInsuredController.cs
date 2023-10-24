using consultorio.Models;
using consultorio.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace consultorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SureInsuredController : ControllerBase
    {
        private readonly ConsultorioDbContext _context;


        public SureInsuredController(ConsultorioDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSureInsured")]
        public IActionResult GetInsured()
        {
            var res = from m in _context.SureInsureds.ToList()
                      join s in _context.Sures on m.Idsure equals s.Idsure
                      join i in _context.Insureds on m.Idinsured equals i.Idinsured
                      select new SureInsuredDto
                      {
                          Idsure = s.Idsure,
                          Code = s.Code,
                          NameSure = s.Name,
                          Idinsured = i.Idinsured,
                          Identification = i.Identification,
                          NameInsured = i.Name
                      };

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }

        [HttpPost("SaveSureInsured")]
        public IActionResult SaveSureInsured([FromBody] JObject json)
        {
            try
            {
                var idinsured = (int)json["idinsured"];
                JArray valoresArray = (JArray)json["idsure"];
                List<int> valores = valoresArray.Select(v => (int)v).ToList();


                //eliminar
                var auxEliminar = from si in _context.SureInsureds.ToList()
                               where si.Idinsured == idinsured
                               select si.Idsure;

                List<int> valoresDistintosEnLista2 = auxEliminar.Except(valores).ToList();

                foreach (var item in valoresDistintosEnLista2)
                {

                    var data = _context.SureInsureds.FirstOrDefault(x => x.Idinsured == idinsured && x.Idsure == item);
     
                    _context.SureInsureds.Remove(data);
                    _context.SaveChanges();
                }

                //crear relacion
                var auxCrear = from si in _context.SureInsureds.ToList()
                               join v in valores on si.Idsure equals v
                               where si.Idinsured == idinsured
                               select si.Idsure;

                List<int> valoresDistintosEnLista1 = valores.Except(auxCrear).ToList();

                foreach (var item in valoresDistintosEnLista1)
                {
                    var aux = new SureInsured
                    {
                        Idinsured = idinsured,
                        Idsure = item
                    };
                    _context.SureInsureds.Add(aux);
                    _context.SaveChanges();
                }

                return Ok(new { code = 200, message = "Correcto" });
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { code = 404, message = "Asegurado no encontrado", data = e });
            }

        }

        [HttpGet("GetSureInsured/{idinsured}")]
        public IActionResult GetSureInsured(int idinsured)
        {
            var res = from m in _context.SureInsureds.ToList()
                      join s in _context.Sures on m.Idsure equals s.Idsure
                      join i in _context.Insureds on m.Idinsured equals i.Idinsured
                      where m.Idinsured == idinsured
                      select new SureInsuredDto
                      {
                          Idsure = s.Idsure,
                          Code = s.Code,
                          NameSure = s.Name,
                          Idinsured = i.Idinsured,
                          Identification = i.Identification,
                          NameInsured = i.Name
                      };

            return Ok(new { code = 200, message = "Consulta realizada", data = res });
        }
    }
}
