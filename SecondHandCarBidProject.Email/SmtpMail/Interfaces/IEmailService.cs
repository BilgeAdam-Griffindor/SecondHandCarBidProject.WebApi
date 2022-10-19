using SecondHandCarBidProject.Email.MailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Email.SmtpMail.Interfaces
{
    public interface IEmailService
    {
        bool SendInformationEmail(EmailDto emailDto);
        bool SendErrorEmail(EmailDto emailDto);
    }
}
