using MediatR;

namespace BasicStudyMediatR.Application.Notifications
{
    public class PersonRemoveNotification : INotification
    {
        public int Id { get; set; }
        public bool Success { get; set; }
    }
}