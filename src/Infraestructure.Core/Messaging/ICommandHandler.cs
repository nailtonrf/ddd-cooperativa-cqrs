﻿namespace Infraestructure.Core.Messaging
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}