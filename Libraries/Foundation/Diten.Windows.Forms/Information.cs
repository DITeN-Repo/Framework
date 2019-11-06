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

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Diten.Text;
using Directory = Diten.IO.Directory;

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten.Windows.Forms
{
	public sealed class Information: RichTextBox
	{
		public Information()
		{
			ReadOnly = true;
			BackColor = Color.Black;
			ForeColor = Color.LimeGreen;
			Dock = DockStyle.Fill;
			Multiline = true;
			ScrollBars = RichTextBoxScrollBars.Vertical;
		}

		public bool DoReport {get; set;}

		private int LinesCount {get; set;}

		public new Color SelectionColor
		{
			get => base.SelectionColor;
			set => SetSelectionColor(value);
		}

		public new string Text
		{
			get => base.Text;
			set => SetText(value);
		}

		public void AddSeparator()
		{
			AppendText(Tools.Repeat("-",
			                        Width / 4 - 7),
			           Color.Yellow);
		}

		public void AppendText(String text,
		                       bool newLine,
		                       params String[] parameters)
		{
			if (text.Color == default) text.Color = ForeColor;

			if (Diten.String.IsNullString(text))
				throw new ArgumentNullException(nameof(text),
				                                @"Argument [text] can not be null or empty");

			var splitter = Environment.TextValuingSeparator;
			var count = 0;

			if (parameters != null)
				for (var i = 0;
				     i < parameters.Length;
				     i++)
					if (text.Value.Contains($@"{{{i}}}"))
					{
						var colorHolder = text.Color;
						text = text.Value.Replace($@"{{{i}}}",
						                          splitter.ToString());
						text.Color = colorHolder;
					}
			//else
			//    throw new ArgumentOutOfRangeException(nameof(parameters), @"Parameters count is more than selected posts.");

			void SetValue(string part)
			{
				SelectionColor = text.Color;
				SetText(part);

				if (parameters != null &&
				    count < parameters.Length)
				{
					SelectionColor = parameters[count].Color;
					SetText(parameters[count]);
				}

				count++;
			}

			foreach (var part in text.Value.Split(splitter)) SetValue(part);

			if (!newLine) return;

			if (parameters != null) SelectionColor = parameters[parameters.Length - 1].Color;
			SetText($@".{Environment.NewLine}");
			LinesCount++;
		}

		public void AppendText(String text,
		                       String value,
		                       bool newLine = true)
		{
			AppendText(text,
			           value,
			           new String(":") {Color = Color.Red},
			           newLine);
		}

		public void AppendText(String text,
		                       String value,
		                       String divider,
		                       bool newLine = true)
		{
			//if (text.Color.Equals(default(Color)))
			text.Color = Color.LimeGreen;

			//if (divider.Color.Equals(default(Color)))
			divider.Color = Color.Red;

			//if (value.Color.Equals(default(Color)))
			value.Color = Color.Orange;

			AppendText(new String(@"{0}:{2}") {Color = default},
			           newLine,
			           text,
			           divider,
			           value);
		}

		public void AppendText(String text,
		                       bool newLine = true)
		{
			AppendText(text,
			           newLine,
			           null);
		}

		public void AppendText(string text,
		                       Color color,
		                       bool newLine = true)
		{
			AppendText(new String(text) {Color = color},
			           newLine);
		}

		public void SaveResult()
		{
			File.WriteAllText(
			                  $@"{
					                  Directory.Windows
					                           .CreateDirectory($@"{Application.CommonAppDataPath}\Diten\Result\{Application.ProductName}")
					                           .FullName
				                  }\{
					                  (FindForm() != null ? FindForm()?.Name : Application.ProductName)
				                  }.Result.txt",
			                  Text);
		}

		private void SetSelectionColor(Color value)
		{
			if (InvokeRequired)
				Invoke(new SelectionColorDelegate(SetSelectionColor),
				       value);
			else base.SelectionColor = value;
		}

		private void SetText(String value)
		{
			if (InvokeRequired)
			{
				Invoke(new TextDelegate(SetText),
				       value);
			}
			else
			{
				if (Diten.String.IsNullString(value)) return;
				if (!DoReport && TextLength + value.Value.Length > MaxLength ||
				    LinesCount > Height / 12 - 7)
				{
					LinesCount = 0;
					base.Text = string.Empty;
				}

				SuspendLayout();
				SelectionFont = value.Font;
				base.AppendText(value);

				if (value.Value.Contains(Environment.NewLine))
				{
					ScrollToCaret();
					ResumeLayout();
				}

				Application.DoEvents();
			}
		}

		private delegate void SelectionColorDelegate(Color value);

		private delegate void TextDelegate(String text);
	}
}