using System;

namespace RTO.Messaging.Models
{
    public interface IAddress
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
