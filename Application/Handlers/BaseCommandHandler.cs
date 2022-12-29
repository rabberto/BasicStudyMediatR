using BasicStudyMediatR.Application.Commands;
using System;
using System.Threading.Tasks;

namespace BasicStudyMediatR.Application.Handlers
{
    public class BaseCommandHandler<THandler> where THandler : class
    {
        public async Task<BaseCommandResponse> SafeExecuteAsync<TCommand>(Func<Task<object>> function, TCommand command)
            where TCommand : BaseCommand
        {
            try
            {
                var result = await function();

                return new BaseCommandResponse(true, result);
            }
            catch (Exception ex)
            {
                return new BaseCommandResponse(false, command, ex.Message);
            }
        }
    }
}
