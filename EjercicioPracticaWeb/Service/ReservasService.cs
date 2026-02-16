using EjercicioPracticaWeb.Interface;
using EjercicioPracticaWeb.Models;

namespace EjercicioPracticaWeb.Service
{
    public class ReservasService : IReservasService
    {
        private static List<Reserva> _reservas = new List<Reserva>();

        //Obtener todas las reservas activas 
        public List<Reserva> GetAll()
        {
            return _reservas.Where(r => r.isActive == 1).ToList();
        }

        // Obtener todas las reservas por id
        public Reserva GetById(Guid id)
        {
            return _reservas.FirstOrDefault(r => r.id_reserva == id && r.isActive == 1);
        }

        // Crear reserva 
        public Reserva Create(Reserva reserva)
        {
            reserva.id_reserva = Guid.NewGuid();
            reserva.isActive = 1;

            _reservas.Add(reserva);
            return reserva;
        }

        // Actualizar reserva 
        public Reserva Updated(Guid id, Reserva reserva)
        {
            var reservaExistente = _reservas.FirstOrDefault(r => r.id_reserva == id && r.isActive == 1);

            if (reservaExistente == null)
            {
                return null;
            }

            reservaExistente.nombre_cliente = reserva.nombre_cliente;
            reservaExistente.destino = reserva.destino;
            reservaExistente.fecha_viaje = reserva.fecha_viaje;
            reservaExistente.cantidad_pasajes = reserva.cantidad_pasajes;

            return reservaExistente;
        }

        // Cancelar reserva 
        public Reserva Delete(Guid id)
        {
            var reservaExistente = _reservas.FirstOrDefault(r => r.id_reserva == id && r.isActive == 1);

            if (reservaExistente == null)
            {
                return null;
            }
            reservaExistente.isActive = 0; // Cambia estado, no se elimina

            return reservaExistente;

        }


    }


}
