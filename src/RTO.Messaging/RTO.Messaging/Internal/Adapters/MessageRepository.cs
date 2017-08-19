using Newtonsoft.Json;
using RTO.Messaging.Internal.Models;
using RTO.Messaging.Models;
using RTO.Messaging.Ports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RTO.Messaging.Internal.Adapters
{
    class MessageRepository : IMessageRepository
    {
        #region consts
        private const string DataFile = "messages";
        #endregion

        #region fields
        private IList<IMessage> _messages;
        #endregion

        #region properties
        protected IList<IMessage> Messages
        {
            get
            {
                if (null == _messages)
                {
                    _messages = LoadMessages();
                }

                return _messages;
            }
        }
        #endregion

        #region ctor
        public MessageRepository()
        {

        }
        #endregion

        #region public methods
        public IEnumerable<IMessage> GetInboxMessages(IAddress sender, bool? unreadOnly)
        {
            var messages = Messages.Where(m => m.Recipients.Contains(sender));
            if (unreadOnly.HasValue && unreadOnly.Value == true)
            {
                messages = messages.Where(m => m.HasBeenRead == false);
            }
            return messages;
        }

        public IEnumerable<IMessage> GetSentMessages(IAddress sender)
        {
            return Messages.Where(m => m.Sender == sender);
        }

        public IMessage AddMessage(IMessage message)
        {
            ((Message)message).Created = DateTime.Now;
            Messages.Add(message);
            return message;
        }

        public void DeleteMessage(IMessage message)
        {
            var existing = _messages.FirstOrDefault(m => m.Id == message.Id);
            if (null != existing)
                Messages.Remove(existing);
        }

        public IMessage UpdateMessage(IMessage message)
        {
            var existing = _messages.FirstOrDefault(m => m.Id == message.Id);
            if (null != existing)
                _messages.Remove(existing);
            Messages.Add(message);
            return message;
        }

        public void SaveChanges()
        {
            SaveMessages(Messages);
        }
        #endregion

        #region protected virtual methods
        protected virtual IList<IMessage> LoadMessages()
        {
            if (File.Exists(DataFile))
            {
                var json = File.ReadAllText(DataFile);
                return JsonConvert.DeserializeObject<IList<IMessage>>(json);
            }
            else
            {
                return new List<IMessage>();
            }
        }
        protected virtual void SaveMessages(IList<IMessage> messages)
        {
            var json = JsonConvert.SerializeObject(messages);
            File.WriteAllText(DataFile, json);
        }
        #endregion
    }
}
