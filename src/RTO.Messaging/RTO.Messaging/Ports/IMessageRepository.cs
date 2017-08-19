using RTO.Messaging.Models;
using System.Collections.Generic;

namespace RTO.Messaging.Ports
{
    public interface IMessageRepository
    {
        IEnumerable<IMessage> GetInboxMessages(IAddress sender, bool? unreadOnly);
        IEnumerable<IMessage> GetSentMessages(IAddress sender);
        IMessage AddMessage(IMessage message);
        IMessage UpdateMessage(IMessage message);
        void DeleteMessage(IMessage message);
        void SaveChanges();
    }
}
