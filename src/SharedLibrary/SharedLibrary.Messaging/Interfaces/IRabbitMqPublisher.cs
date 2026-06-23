using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Messaging.Interfaces
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync<T>(string queueName, T message);
    }
}
