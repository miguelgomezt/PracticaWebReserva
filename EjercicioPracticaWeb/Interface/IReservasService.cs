using EjercicioPracticaWeb.Models;

namespace EjercicioPracticaWeb.Interface
{
    public interface IReservasService
    {
        List<Reserva> GetAll();
        Reserva GetById(Guid id); 
        Reserva Create(Reserva reserva);
        bool Update(Guid id, Reserva reserva);
        bool Cancel(Guid id);
    }
}
