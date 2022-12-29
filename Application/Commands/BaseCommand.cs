using MediatR;
using System;

namespace BasicStudyMediatR.Application.Commands
{
    public class BaseCommand : IRequest<BaseCommandResponse>
    {
        public Guid CorrelationId = Guid.NewGuid();
    }
}
