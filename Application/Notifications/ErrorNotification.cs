using MediatR;

namespace BasicStudyMediatR.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}