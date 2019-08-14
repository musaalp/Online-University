using System.Collections.Generic;

namespace OnlineUniversity.Application.Contracts.Bus
{
    public interface IBusMessage
    {
        IDictionary<string, object> Properties { get; set; }
    }
}
