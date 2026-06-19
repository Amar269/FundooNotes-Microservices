using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces
{
    public  interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail,string userName);
        
    }
}
