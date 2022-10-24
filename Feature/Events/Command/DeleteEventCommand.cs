using EVENTS.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EVENTS.Feature.Events.Command
{
    public class DeleteEventCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
        {
            private readonly IEventService _EventService;
            public DeleteEventCommandHandler(IEventService EventService)
            {
                _EventService = EventService;
            }
            public async Task<int> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
            {
                var Event = await _EventService.GetEventById(command.Id);
                if (Event == null)
                    return default;

                return await _EventService.DeleteEvent(Event);
            }

        }
    
    }  
}
