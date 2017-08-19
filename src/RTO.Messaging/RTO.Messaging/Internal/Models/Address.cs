using RTO.Messaging.Models;
using System;

namespace RTO.Messaging.Internal.Models
{
    class Address : IAddress
    {
        #region properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region public overrides
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Address a = (Address)obj;
            return (Id == a.Id) && (Name == a.Name);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }
        #endregion
    }
}
