using MediatR;

namespace BasicStudyMediatR.Application.Notifications
{
    public class PersonCreateNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}