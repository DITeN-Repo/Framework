// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 1:05 AM

#region Used Directives

using System.Net.Mail;
using System.Security.Cryptography;

#endregion

namespace Diten.Net.Mail
{
	public class Mail
	{
		public Mail() {}

		public Mail(string to,
		            string subject,
		            string body)
		{
			SHA1.Create().ComputeHash()
			//ToDo: Check Commented code.
			//var mailMessage = new MailMessage
			//{
			//	From = new MailAddress(Parameters.Local.NoReplyMailAddress,
			//		Parameters.SystemParams.Default.DefaultMailDisplayName),
			//	To = {to},
			//	Subject = subject,
			//	Body = body,
			//	IsBodyHtml = true
			//};

			//MailMessage = mailMessage;
		}

		/// <summary>
		///    Subject of e-mail.
		/// </summary>
		public MailMessage MailMessage {get; set;}

		/// <summary>
		///    Sending mail.
		/// </summary>
		public void SendMail()
		{
			//ToDo: Check Commented code.
			//var smtpClient = new SmtpClient
			//{
			//	Host = Application.Default.Credentials =
			//		new NetworkCredential(Parameters.Local.NoReplyMailAddress,
			//			Parameters.Local.SmtpPassword)
			//};

			//smtpClient.Send(MailMessage);
		}
	}
}