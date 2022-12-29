using System.Collections.Generic;

namespace BasicStudyMediatR.Application.Commands
{
    public class BaseCommandResponse
    {
        public BaseCommandResponse(bool success, object data, string error = null)
        {
            Success = success;
            Data = data;
            Error = error;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }
    }
}
