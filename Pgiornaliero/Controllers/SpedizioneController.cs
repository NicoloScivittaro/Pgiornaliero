using Microsoft.AspNetCore.Mvc;
using SpedizioniApp.Models;
using SpedizioniApp.Services;

namespace SpedizioniApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpedizioneController : ControllerBase
    {
        private readonly SpedizioneService _spedizioneService;

        public SpedizioneController(SpedizioneService spedizioneService)
        {
            _spedizioneService = spedizioneService;
        }

        [HttpGet]
        public IActionResult GetSpedizioni()
        {
            var spedizioni = _spedizioneService.GetSpedizioni();
            return Ok(spedizioni);
        }

        [HttpGet("{id}")]
        public IActionResult GetSpedizioneById(int id)
        {
            var spedizione = _spedizioneService.GetSpedizioneById(id);
            if (spedizione == null)
            {
                return NotFound();
            }
            return Ok(spedizione);
        }

        [HttpPost]
        public IActionResult AddSpedizione([FromBody] Spedizione spedizione)
        {
            _spedizioneService.AddSpedizione(spedizione);
            return CreatedAtAction(nameof(GetSpedizioneById), new { id = spedizione.Id }, spedizione);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpedizione(int id, [FromBody] Spedizione spedizione)
        {
            if (id != spedizione.Id)
            {
                return BadRequest();
            }

            _spedizioneService.UpdateSpedizione(spedizione);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpedizione(int id)
        {
            _spedizioneService.DeleteSpedizione(id);
            return NoContent();
        }

        [HttpGet("in-consegna-oggi")]
        public IActionResult GetSpedizioniInConsegnaOggi()
        {
            var spedizioni = _spedizioneService.GetSpedizioniInConsegnaOggi();
            return Ok(spedizioni);
        }

        [HttpGet("in-attesa-di-consegna")]
        public IActionResult GetSpedizioniInAttesaDiConsegna()
        {
            var count = _spedizioneService.GetSpedizioniInAttesaDiConsegna();
            return Ok(new { Count = count });
        }

        [HttpGet("per-citta")]
        public IActionResult GetSpedizioniPerCittaDestinataria()
        {
            var spedizioniPerCitta = _spedizioneService.GetSpedizioniPerCittaDestinataria();
            return Ok(spedizioniPerCitta);
        }
    }
}
