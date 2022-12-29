using System;
using System.Threading;
using System.Threading.Tasks;
using BasicStudyMediatR.Application.Notifications;
using MediatR;

namespace BasicStudyMediatR.Application.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<PersonCreateNotification>,
                                INotificationHandler<PersonUpdateNotification>,
                                INotificationHandler<PersonRemoveNotification>,
                                INotificationHandler<ErrorNotification>
    {
        public Task Handle(PersonCreateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender}'");
            });
        }

        public Task Handle(PersonUpdateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender} - {notification.Success}'");
            });
        }

        public Task Handle(PersonRemoveNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.Success}'");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Exception} \n {notification.StackTrace}'");
            });
        }
    }
}