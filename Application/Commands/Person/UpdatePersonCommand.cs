using MediatR;

namespace BasicStudyMediatR.Application.Commands.Person
{
    public class UpdatePersonCommand : BaseCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}