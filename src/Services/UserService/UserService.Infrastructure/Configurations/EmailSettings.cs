using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Infrastructure.Configurations
{
    public  class EmailSettings
    {
        public string SenderEmail { get; set; } = string.Empty;

        public string SenderName { get; set; } = string.Empty;

        public string SmtpServer { get; set; } = string.Empty;

        public int Port { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
