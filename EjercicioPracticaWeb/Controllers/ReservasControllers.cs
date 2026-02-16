using EjercicioPracticaWeb.Interface;
using EjercicioPracticaWeb.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPracticaWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservasControllers : ControllerBase
    {
        private readonly IReservasService _service;

        // Inyeccion de dependencias, si o si siempre. 
        public ReservasControllers(IReservasService service) {
            _service = service;
        }
        // Get: Api/Reservas 
        [HttpGet]
        public IActionResult Get()
        {
            var reserva = _service.GetAll();
            return Ok(reserva);
        }

        // Get: Api/Reserva + {id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var reserva = _service.GetById(id);

            if (reserva == null)
                return NotFound();
            return Ok(reserva);
        }

        // Post Api/Reserva
        [HttpPost]
        public IActionResult Create([FromBody] Reserva reserva)
        {
            var nueva_Reserva = _service.Create(reserva);

            return CreatedAtAction(nameof(GetById), new { id = nueva_Reserva.id_reserva }, nueva_Reserva)
        }

        //Put Api/Reserva + {id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Reserva reserva)
        {
            var reservaActualizada = _service.Update(id, reserva);
            if (reservaActualizada == null)
                return NotFound();
            return NoContent();
        }

        // Delete Api/Reserva + {id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            var eliminarReserva = _service.Delete(id);

            if (eliminarReserva == null)
                return NotFound();
            return NoContent();
        }
    }

}
