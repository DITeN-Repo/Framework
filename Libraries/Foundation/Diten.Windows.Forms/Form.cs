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
// Creation Date: 2019/09/04 10:05 PM

#region Used Directives

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Diten.Globalization;
using Diten.IO;
using Diten.Parameters;
using Application = System.Windows.Forms.Application;
using File = System.IO.File;

#endregion

namespace Diten.Windows.Forms
{
	public class Form: System.Windows.Forms.Form
	{
		public bool AskQuestions {get; set;}

		public string DestinationFolder =>
			$@"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory)}\{Application.ProductName}\{Text}";

		private string Exp =>
			$@"{
					Environment.SpecialFolders.MyDocuments
				}\Windows Tools\{
					Name.Replace("Form",
					             string.Empty)
				}\Exports";

		public string ExportPath =>
			AskQuestions
				? AskQuestion(
				              $@"Are you sure about creating Exports folder for [{
						              Name.Replace("Form",
						                           string.Empty)
					              }] form?") ? Directory.Windows.CreateDirectory(Exp).FullName : string.Empty
				: Directory.Windows.CreateDirectory(Exp).FullName;

		private string Imp =>
			$@"{
					Environment.SpecialFolders.MyDocuments
				}\Windows Tools\{
					Name.Replace("Form",
					             string.Empty)
				}\{
					Name.Replace("Form",
					             string.Empty)
				}.imp";

		public List<string> ImportPath =>
			File.Exists(Imp)
				? AskQuestions ? AskQuestion(
				                             $@"Are you sure about loading import file [{
						                             Name.Replace("Form",
						                                          string.Empty)
					                             }.imp]?") ? File.ReadAllLines(Imp).ToList() : null : File.ReadAllLines(Imp).ToList()
				: null;

		public bool AskQuestion(System.String question)
		{
			return MessageBox.Show(
			                       Cultures.Translate(
			                                          question),
			                       Dictionary.Default.Warning,
			                       MessageBoxButtons.YesNo,
			                       MessageBoxIcon.Question,
			                       MessageBoxDefaultButton.Button1) ==
			       DialogResult.Yes;
		}
	}
}