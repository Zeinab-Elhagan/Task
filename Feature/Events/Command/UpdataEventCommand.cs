using EVENTS.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVENTS.Feature.Events.Command
{
    public class UpdataEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string EventContent { get; set; }
        public string EventAddress { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventCoverphoto { get; set; }
        public string source { get; set; }
        public string albums { get; set; }
        public string Category { get; set; }
        public class UpdateEventCommandHandler : IRequestHandler<UpdataEventCommand, int>
        {
            private readonly IEventService _EventService;

            public UpdateEventCommandHandler(IEventService EventService)
            {
                _EventService = EventService;
            }
            public async Task<int> Handle(UpdataEventCommand command, CancellationToken cancellationToken)
            {
                var Event = await _EventService.GetEventById(command.Id);
                if (Event == null)
                    return default;

                Event.EventId = command.Id;
                Event.EventTitle = command.EventTitle;
                Event.EventContent = command.EventContent;
                Event.EventAddress = command.EventAddress;
                Event.EventStartDate = command.EventStartDate;
                Event.EventEndDate = command.EventEndDate;
                Event.EventCoverphoto = command.EventCoverphoto;
                Event.source = command.source;
                Event.albums = command.albums;
                Event.Category = command.Category;                  

                return await _EventService.UpdateEvent(Event);
            }
        }

    }
}
