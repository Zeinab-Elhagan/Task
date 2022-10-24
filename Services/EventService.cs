using EVENTS.Data;
using EVENTS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVENTS.Services
{
    public class EventService : IEventService  
    {
        private readonly EventDbContext _context;

        public EventService(EventDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Event>> GetEventsList()
        {
            return await _context.Events
                .ToListAsync();
        }
        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events
                .FirstOrDefaultAsync(x => x.EventId == id);
        }
        public async Task<Event> CreateEvent(Event Event)
        {
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();
            return Event;
        }
        public async Task<int> UpdateEvent(Event Event)
        {
            _context.Events.Update(Event);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEvent(Event Event)
        {
            _context.Events.Remove(Event);
            return await _context.SaveChangesAsync();
        }
    }
}
