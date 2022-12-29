using BasicStudyMediatR.Application.Commands;
using BasicStudyMediatR.Application.Commands.Person;
using BasicStudyMediatR.Application.Handlers;
using BasicStudyMediatR.Application.Models;
using BasicStudyMediatR.Application.Notifications;
using BasicStudyMediatR.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CreatePersonCommandHandler : BaseCommandHandler<CreatePersonCommandHandler>, IRequestHandler<CreatePersonCommand, BaseCommandResponse>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Person> _repository;
    public CreatePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<BaseCommandResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        return await SafeExecuteAsync(async () =>
        {
            var person = new Person { Name = request.Name, Age = request.Age, Gender = request.Gender };

            var result = await _repository.Add(person);

            await _mediator.Publish(new PersonCreateNotification { Id = result.Id, Name = result.Name, Age = result.Age, Gender = result.Gender });

            return result;

        }, request);
    }
}