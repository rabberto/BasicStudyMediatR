using MediatR;

namespace BasicStudyMediatR.Application.Commands.Person
{
    public class RemovePersonCommand : BaseCommand
    {
        public int Id { get; set; }
    }
}