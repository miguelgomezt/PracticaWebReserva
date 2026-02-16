using System.ComponentModel.DataAnnotations;

namespace EjercicioPracticaWeb.Models
{
    public class Reserva
    {
        public Guid id_reserva {  get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string nombre_cliente { get; set; }

        [Required(ErrorMessage = "El destino debe ser obligatorio")]
        public string destino { get; set; }

        [Required(ErrorMessage = "La fecha del viaje debe ser obligatoria")]
        public string fecha_viaje { get; set; }

        [Range (1, int.MaxValue, ErrorMessage = "La cantidad de pasajes debe ser mayor a 0")]
        public int cantidad_pasajes { get; set; }
        public int isActive { get; set; }
    }
}
