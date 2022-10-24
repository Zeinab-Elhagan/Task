using EVENTS.Models;
using EVENTS.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EVENTS.Feature.Events.Queries
{
    public class GetAllEventsquery : IRequest<IEnumerable<Event>>
    {
          public int EventId { get; set; }

        public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsquery, IEnumerable<Event>>
        {
            private readonly IEventService _EventService;
            //private readonly IMapper _Mapper;

            public GetAllEventsQueryHandler(IEventService EventService)
            {
                _EventService = EventService;
               // _Mapper = Mapper;
            }
            public async Task<IEnumerable<Event>> Handle(GetAllEventsquery query, CancellationToken cancellationToken)
            {
                //var allEvents = await _EventService.GetAllEventqurey(true);
                
                return await _EventService.GetEventsList();
            }
            //public async Task<IEnumerable<Event>> Handle(GetAllEventsquery query, CancellationToken cancellationToken){return await _EventService.GetEventsList();}
           
            //public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsquery, IEnumerable<vent>>
        }
        
            //private readonly IEventService _EventService;
           
        
    }
}