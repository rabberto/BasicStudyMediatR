using MediatR;

namespace BasicStudyMediatR.Application.Notifications
{
    public class PersonUpdateNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool Success { get; set; }
    }
}