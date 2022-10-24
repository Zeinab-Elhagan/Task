using EVENTS.Models;
using EVENTS.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVENTS.Feature.Events.Command
{
    public class CreateEventCommand : IRequest<Event>
    {
        public int? EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventContent { get; set; }
        public string EventAddress { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventCoverphoto { get; set; }
        public string source { get; set; }
        public string albums { get; set; }
        public string Category { get; set; }

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
        {
            private readonly IEventService _EventService;

            public CreateEventCommandHandler(IEventService EventService)
            {
                _EventService = EventService;
            }
            public async Task<Event> Handle(CreateEventCommand command, CancellationToken cancellationToken)
            {
                var Event = new Event()
                {
                    EventId = command.EventId,
                    EventTitle = command.EventTitle,
                    EventContent = command.EventContent,
                    EventAddress = command.EventAddress,
                    EventStartDate = command.EventStartDate,
                    EventEndDate = command.EventEndDate,    
                    EventCoverphoto = command.EventCoverphoto,
                    source = command.source,
                    albums= command.albums,
                    Category = command.Category,    

                };

                return await _EventService.CreateEvent(Event);
            }

        }
    }
}  