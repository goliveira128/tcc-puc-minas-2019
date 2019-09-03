using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace EventBusRabbitMQSGQ.Interface
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
