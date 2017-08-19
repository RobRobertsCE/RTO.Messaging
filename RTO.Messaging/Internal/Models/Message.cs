using RTO.Messaging.Models;
using System;
using System.Collections.Generic;

namespace RTO.Messaging.Internal.Models
{
    class Message : IMessage
    {
        #region properties
        public Guid Id { get; private set; }
        public IAddress Sender { get; private set; }
        public IList<IAddress> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; internal set; }
        public bool HasBeenRead { get; internal set; }
        #endregion

        #region ctor
        protected Message()
        {
            Recipients = new List<IAddress>();
        }

        protected Message(IAddress sender)
            : this()
        {
            Sender = sender;
        }
        #endregion

        #region factory
        public static IMessage GetNewMessage(IAddress sender)
        {
            var message = new Message(sender)
            {
                Id = Guid.NewGuid()
            };
            return message;
        }
        #endregion
    }
}
