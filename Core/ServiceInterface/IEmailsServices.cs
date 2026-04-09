using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dto;

namespace Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDTO dto);
    }
}
