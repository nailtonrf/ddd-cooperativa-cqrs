using System;

namespace Infraestructure.Core.Saga
{
    public class SagaCoordinatorData
    {
        public Guid Id { get; }
        public Guid SagaId { get; }
        public Guid AggegateId { get; }
        public string MessageType { get; }
        public string MessageContent { get; }
        public Enumeration State { get; }
        public DateTime Executed { get; }

        private SagaCoordinatorData()
        {
        }

        public SagaCoordinatorData(Guid sagaId, Guid aggegateId, string messageType, string messageContent, Enumeration state, DateTime executed) : this()
        {
            Id = Guid.NewGuid();
            SagaId = sagaId;
            AggegateId = aggegateId;
            MessageType = messageType;
            MessageContent = messageContent;
            State = state;
            Executed = executed;
        }
    }
}