using System;
using Infraestructure.Core;
using Infraestructure.Core.Messaging;

namespace Infraestructure.CrossCutting.Contexts
{
    public sealed class RequestContext : IRequestContext
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ICommandSender _commandSender;

        public RequestContext(IDateTimeService dateTimeService, ICommandSender commandSender)
        {
            Id = Guid.NewGuid();
            _dateTimeService = dateTimeService;
            _commandSender = commandSender;
        }

        public Guid Id { get; }
        public DateTime CurrentDateTime => _dateTimeService.CurrentDateTime();
        public DateTime CurrentDate => _dateTimeService.CurrentDate();
        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            _commandSender.Send(command);
        }
    }
}