using System;

namespace Infraestructure.Core.Notifications
{
    public class DomainNotification
    {
        public DomainNotification()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public DomainNotification(string key, string value) : this()
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            Date = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
    }
}