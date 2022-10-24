using EVENTS.Models;
using EVENTS.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EVENTS.Feature.Events.Queries
{
    public class GetEventByIdquery : IRequest<Event>
    {
        public int Id { get; set; }
        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdquery, Event>
        {
            private readonly IEventService _EventService;
            public GetEventByIdQueryHandler(IEventService EventService)
            {
                _EventService = EventService;
            }
            public async Task<Event> Handle(GetEventByIdquery query, CancellationToken cancellationToken)
            {
                return await _EventService.GetEventById(query.Id);
            }

        }
    }
}
