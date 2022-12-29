using BasicStudyMediatR.Application.Commands;
using MediatR;

namespace BasicStudyMediatR.Application.Commands.Person
{
    public class CreatePersonCommand : BaseCommand
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}