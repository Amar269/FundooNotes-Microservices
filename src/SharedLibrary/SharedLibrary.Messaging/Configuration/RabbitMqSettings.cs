using System;
using System.Collections.Generic;
using System.Text;
namespace SharedLibrary.Messaging.Configuration;

public class RabbitMqSettings
{
    public string HostName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
