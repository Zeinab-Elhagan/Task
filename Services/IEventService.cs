using EVENTS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVENTS.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsList();

        Task<Event> GetEventById(int id);
        Task<Event>CreateEvent(Event Event);
        Task<int> UpdateEvent(Event Event);
        Task<int> DeleteEvent(Event Event);
    }

    
}
