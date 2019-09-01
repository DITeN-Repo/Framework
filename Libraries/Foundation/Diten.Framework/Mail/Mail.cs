#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 1:05 AM

#endregion

#region Used Directives

using System.Net;
using System.Net.Mail;

#endregion

namespace Diten.Net.Mail
{
	public class Mail
	{
		public Mail()
		{
		}

		public Mail(string to,
			string subject,
			string body)
		{
			var mailMessage = new MailMessage
			{
				From = new MailAddress(Parameters.Local.NoReplyMailAddress,
					Variables.System.Default.DefaultMailDisplayName),
				To = {to},
				Subject = subject,
				Body = body,
				IsBodyHtml = true
			};

			MailMessage = mailMessage;
		}

		/// <summary>
		///    Subject of e-mail.
		/// </summary>
		public MailMessage MailMessage { get; set; }

		/// <summary>
		///    Sending mail.
		/// </summary>
		public void SendMail()
		{
			var smtpClient = new SmtpClient
			{
				Host = Parameters.Local.SmtpServerAddress,
				Credentials =
					new NetworkCredential(Parameters.Local.NoReplyMailAddress,
						Parameters.Local.SmtpPassword)
			};

			smtpClient.Send(MailMessage);
		}
	}
}