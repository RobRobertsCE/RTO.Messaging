using RTO.Messaging.Models;
using System;
using System.Collections.Generic;

namespace RTO.Messaging.Ports
{
    public interface IMessageService
    {
        IEnumerable<IMessage> GetSentMessages(IAddress sender);
        IEnumerable<IMessage> GetNewMessages(IAddress sender);
        IEnumerable<IMessage> GetAllMessages(IAddress sender);
        void SendMessage(IMessage message);
        IMessage MarkAsRead(IMessage message);
        void DeleteMessage(IMessage message);
        IMessage CreateNewMessage(IAddress sender);
        IAddress GetAddress(Guid id, string name);
    }
}
