#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Diten.Text
{
	public static class RegularExpressions
	{
		public enum PasswordScore
		{
			Blank = 0,
			VeryWeak = 1,
			Weak = 2,
			Medium = 3,
			Strong = 4,
			VeryStrong = 5
		}

		public static PasswordScore IsPasswordStrengthPassed(string password)
		{
			var score = 0;

			if(password.Length<1)
				return PasswordScore.Blank;
			if(password.Length<8)
				return PasswordScore.VeryWeak;

			if(password.Length>=8)
				score++;
			if(password.Length>=12)
				score++;
			if(Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
				score++;
			if(Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success&&
				 Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
				score++;
			if(Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,�,(,)]", RegexOptions.ECMAScript).Success)
				score++;

			return (PasswordScore)score;
		}

		/// <summary>
		///    Check is valid computer name.
		/// </summary>
		/// <param name="computerName">Computer name for validation.</param>
		/// <returns>True if user name is valid.</returns>
		public static bool IsValidComputerName(string computerName)
		{
			return Regex.IsMatch(computerName, @"^[a-zA-Z0-9_\-]*$");
		}

		/// <summary>
		///    Check is valid domain name.
		/// </summary>
		/// <param name="domainName">Domain name for validation.</param>
		/// <returns>True if domain name is valid.</returns>
		public static bool IsValidDomainName(string domainName)
		{
			return Regex.IsMatch(domainName, @"/^[^\.].*/^[a-zA-Z0-9_\-\.]*$");
		}

		/// <summary>
		///    Check is valid email addres.
		/// </summary>
		/// <param name="emailAddress">Email address for validation.</param>
		/// <returns>True if email address is valid.</returns>
		public static bool IsValidEMailAddress(string emailAddress)
		{
			return Regex.IsMatch(emailAddress, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
		}

		/// <summary>
		///    Check is valid group name.
		/// </summary>
		/// <param name="groupName">Group name for validation.</param>
		/// <returns>True if domain name is valid.</returns>
		public static bool IsValidGroupName(string groupName)
		{
			return Regex.IsMatch(groupName, @"^[a-zA-Z0-9_\-]*$");
		}

		/// <summary>
		///    Check is national code valid.
		/// </summary>
		/// <param name="nationalCode">National code for validation.</param>
		/// <returns>True if national code is valid.</returns>
		public static bool IsValidNationalCode(string nationalCode)
		{
			if(string.IsNullOrEmpty(nationalCode))
				throw new InvalidDataException("Lotfan yek code melli sahih vared namaaeid.");

			if(nationalCode.Length!=10)
				throw new InvalidOperationException("Code melli baayad hadeaghal 10 kaaraakter daashteh baashad.");

			var regex = new Regex(@"\d{10}");

			if(!regex.IsMatch(nationalCode))
				throw new InvalidCastException(
					"Code melli baayad 10 ragham eadadi baashad. lotfan code sahih vared namaaeid.");

			var allDigitEqual = new[]
			{
				"0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555",
				"6666666666",
				"7777777777", "8888888888", "9999999999"
			};

			if(allDigitEqual.Contains(nationalCode))
				return false;

			var chArray = nationalCode.ToCharArray();
			var num0 = System.Convert.ToInt32(chArray[0].ToString())*10;
			var num2 = System.Convert.ToInt32(chArray[1].ToString())*9;
			var num3 = System.Convert.ToInt32(chArray[2].ToString())*8;
			var num4 = System.Convert.ToInt32(chArray[3].ToString())*7;
			var num5 = System.Convert.ToInt32(chArray[4].ToString())*6;
			var num6 = System.Convert.ToInt32(chArray[5].ToString())*5;
			var num7 = System.Convert.ToInt32(chArray[6].ToString())*4;
			var num8 = System.Convert.ToInt32(chArray[7].ToString())*3;
			var num9 = System.Convert.ToInt32(chArray[8].ToString())*2;
			var a = System.Convert.ToInt32(chArray[9].ToString());

			var b = num0+num2+num3+num4+num5+num6+num7+num8+num9;
			var c = b%11;

			return c<2&&a==c||c>=2&&11-c==a;
		}

		/// <summary>
		///    Check is valid password.
		/// </summary>
		/// <param name="password">Password for validation.</param>
		/// <returns>True if user name is valid.</returns>
		public static bool IsValidPassword(string password)
		{
			return Regex.IsMatch(password, @"^([a-zA-Z0-9_\.~!@#$%^&*()\-+=<>,\\|{}\[\]'/`?\:\;]{8,20})*$");
		}

		/// <summary>
		///    Check is valid system word.
		/// </summary>
		/// <param name="word">Word for validation.</param>
		/// <returns>True if word is system word.</returns>
		public static bool IsValidSystemWord(string word)
		{
			return Regex.IsMatch(word, @"\[*[A-Z0-9_]*\]");
		}

		/// <summary>
		///    Check is valid user name.
		/// </summary>
		/// <param name="userName">User name for validation.</param>
		/// <returns>True if user name is valid.</returns>
		public static bool IsValidUserName(string userName)
		{
			return Regex.IsMatch(userName, @"^[a-zA-Z0-9_\.]*$");
		}
	}
}