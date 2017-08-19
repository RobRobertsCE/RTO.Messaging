using System;
using System.Collections.Generic;

namespace RTO.Messaging.Models
{
    public interface IMessage
    {
        Guid Id { get; }
        string Subject { get; set; }
        string Body { get; set; }
        IList<IAddress> Recipients { get; set; }
        IAddress Sender { get; }
        DateTime Created { get; }
        bool HasBeenRead { get; }
    }
}