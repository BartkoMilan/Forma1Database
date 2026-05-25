using Forma1Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forma1Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotakController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPilotak()
        {
            using (var cx = new Forma1Context())
            {
                try
                {
                    var pilotak = cx.Pilotaks.ToList();
                    return Ok(pilotak);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        //[HttpGet("csapatokkal")]
        //public IActionResult GetPilotakCsapatokkal()
        //{
        //    using (var cx = new Forma1Context())
        //    {
        //        try
        //        {
        //            var pilotak = cx.Pilotaks
        //                .Include(p => p.CsapatNavigation)
        //                .ToList();
        //            return Ok(pilotak);
        //        }A
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, ex.Message);
        //        }
        //    }
        //}

        [HttpPost]
        public IActionResult PostPilota([FromBody] Pilotak pilota)
        {
            using (var cx = new Forma1Context())
            {
                try
                {
                    cx.Pilotaks.Add(pilota);
                    cx.SaveChanges();
                    return StatusCode(201, pilota);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult PutPilota([FromBody] Pilotak pilota)
        {
            using (var cx = new Forma1Context())
            {
                try
                {
                    var existingPilota = cx.Pilotaks.Find(pilota.Pazon);
                    if (existingPilota == null)
                    {
                        return NotFound("A pilóta nem található.");
                    }

                    existingPilota.Pnev = pilota.Pnev;
                    existingPilota.Szev = pilota.Szev;
                    existingPilota.Csapat = pilota.Csapat;

                    cx.SaveChanges();
                    return Ok(existingPilota);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePilota(int id)
        {
            using (var cx = new Forma1Context())
            {
                try
                {
                    var pilota = cx.Pilotaks.Find(id);
                    if (pilota == null)
                    {
                        return NotFound("A pilóta nem található.");
                    }

                    cx.Pilotaks.Remove(pilota);
                    cx.SaveChanges();
                    return Ok("A pilóta sikeresen törölve.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    } 
}
