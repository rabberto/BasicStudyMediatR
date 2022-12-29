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
    public class UpdatePersonCommandHandler : BaseCommandHandler<UpdatePersonCommand>, IRequestHandler<UpdatePersonCommand, BaseCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;
        public UpdatePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () =>
            {
                var person = new Person { Name = request.Name, Age = request.Age, Gender = request.Gender };

                var result = await _repository.Edit(person);

                await _mediator.Publish(new PersonCreateNotification { Id = result.Id, Name = result.Name, Age = result.Age, Gender = result.Gender });

                return result;

            }, request);
        }
    }
}