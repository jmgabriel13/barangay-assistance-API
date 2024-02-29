using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Implementation.Mailer
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestDTO mailRequest);
    }
}
