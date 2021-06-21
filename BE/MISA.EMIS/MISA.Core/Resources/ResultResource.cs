using System.Collections.Generic;

namespace MISA.Core.Resources
{
    public class ResultResource
    {
        public bool Success { get; private set; }
        public List<string> Message { get; private set; }

        public ResultResource(List<string> messages, bool flag = false)
        {
            this.Message = messages ?? new List<string>();
            this.Success = flag;
        }

        public ResultResource(string message, bool flag = false)
        {
            this.Message = new List<string>();
            this.Success = flag;
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Message.Add(message);
            }
        }
    }
}
