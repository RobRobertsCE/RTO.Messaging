using RTO.Messaging.Internal.Models;
using RTO.Messaging.Models;
using RTO.Messaging.Ports;
using System;
using System.Collections.Generic;

namespace RTO.Messaging.Internal.Adapters
{
    class MessageService : IMessageService
    {
        #region fields
        private IMessageRepository _messageRepository;
        #endregion

        #region ctor
        public MessageService()
            : this(new MessageRepository())
        {

        }
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        #endregion

        #region public methods
        public IEnumerable<IMessage> GetAllMessages(IAddress sender)
        {
            return _messageRepository.GetInboxMessages(sender, null);
        }

        public IEnumerable<IMessage> GetNewMessages(IAddress sender)
        {
            return _messageRepository.GetInboxMessages(sender, true);
        }

        public IEnumerable<IMessage> GetSentMessages(IAddress sender)
        {
            return _messageRepository.GetSentMessages(sender);
        }

        public IMessage CreateNewMessage(IAddress sender)
        {
            return Message.GetNewMessage(sender);
        }

        public void DeleteMessage(IMessage message)
        {
            _messageRepository.DeleteMessage(message);
        }

        public IMessage MarkAsRead(IMessage message)
        {
            ((Message)message).HasBeenRead = true;
            return _messageRepository.UpdateMessage(message);
        }

        public void SendMessage(IMessage message)
        {
            if (message.Sender == null)
            {
                throw new InvalidOperationException("No Sender");
            }
            if (message.Recipients == null || message.Recipients.Count == 0)
            {
                throw new InvalidOperationException("No Recipients");
            }
            if (String.IsNullOrEmpty(message.Body))
            {
                throw new InvalidOperationException("No Body");
            }
            if (String.IsNullOrEmpty(message.Subject))
            {
                throw new InvalidOperationException("No Subject");
            }
            _messageRepository.AddMessage(message);
        }

        public IAddress GetAddress(Guid id, string name)
        {
            return new Address() { Id = id, Name = name };
        }
        #endregion
    }
}
