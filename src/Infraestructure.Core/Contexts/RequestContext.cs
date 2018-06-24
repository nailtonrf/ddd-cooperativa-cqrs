﻿using System;
using Infraestructure.Core.Messaging;

namespace Infraestructure.Core.Contexts
{
    public sealed class RequestContext : IRequestContext
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ICommandSender _commandSender;
        private readonly IEventPublisher _eventPublisher;

        public RequestContext(IDateTimeService dateTimeService, ICommandSender commandSender, IEventPublisher eventPublisher)
        {
            Id = Guid.NewGuid();
            _dateTimeService = dateTimeService;
            _commandSender = commandSender;
            _eventPublisher = eventPublisher;
        }

        public Guid Id { get; }

        public DateTime CurrentDateTime => _dateTimeService.CurrentDateTime();

        public DateTime CurrentDate => _dateTimeService.CurrentDate();

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            _commandSender.Send(command);
        }

        public void PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _eventPublisher.Publish(@event);
        }
    }
}