using BasicStudyMediatR.Application.Commands;
using BasicStudyMediatR.Application.Commands.Person;
using BasicStudyMediatR.Application.Models;
using BasicStudyMediatR.Application.Notifications;
using BasicStudyMediatR.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BasicStudyMediatR.Application.Handlers
{
    public class RemovePersonCommandHandler : BaseCommandHandler<RemovePersonCommand>, IRequestHandler<RemovePersonCommand, BaseCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;
        public RemovePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<BaseCommandResponse> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () =>
            {
                var result = await _repository.Delete(request.Id);

                await _mediator.Publish(new PersonRemoveNotification { Id = request.Id, Success = true });

                return new { delete = result };

            }, request);
        }
    }
}