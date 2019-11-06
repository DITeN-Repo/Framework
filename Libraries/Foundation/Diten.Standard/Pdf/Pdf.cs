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
// Creation Date: 2019/09/02 9:08 PM

#region Used Directives

using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

namespace Diten.Pdf
{
	public static class Tools
	{
		/// <summary>
		///    Merge pdf files.
		/// </summary>
		/// <param name="sourceFiles">PDF files being merged.</param>
		/// <param name="watermark">Write watermark or not.</param>
		/// <returns>Content of merged pdf.</returns>
		public static byte[] Merge(IEnumerable<byte[]> sourceFiles,
		                           bool watermark)
		{
			var document = new Document();

			using (var memoryStream = new MemoryStream())
			{
				var copy = new PdfCopy(document,
				                       memoryStream);
				document.Open();
				var documentPageCounter = 0;

				// Iterate through all pdf documents
				foreach (var sourceFile in sourceFiles)
				{
					if (sourceFile.Length <= 0) continue;

					// Create pdf reader
					var reader = new PdfReader(sourceFile);
					var numberOfPages = reader.NumberOfPages;
					// Iterate through all pages
					for (var currentPageIndex = 1;
					     currentPageIndex <= numberOfPages;
					     currentPageIndex++)
					{
						documentPageCounter++;
						var importedPage = copy.GetImportedPage(reader,
						                                        currentPageIndex);
						var pageStamp = copy.CreatePageStamp(importedPage);

						if (watermark)
						{
							// Write header
							ColumnText.ShowTextAligned(pageStamp.GetOverContent(),
							                           Element.ALIGN_CENTER,
							                           new Phrase("DITeN PDF Tool"),
							                           importedPage.Width / 2,
							                           importedPage.Height - 30,
							                           importedPage.Width < importedPage.Height ? 0 : 1);

							// Write footer
							ColumnText.ShowTextAligned(pageStamp.GetOverContent(),
							                           Element.ALIGN_CENTER,
							                           new Phrase($"Page {documentPageCounter}"),
							                           importedPage.Width / 2,
							                           30,
							                           importedPage.Width < importedPage.Height ? 0 : 1);
						}

						pageStamp.AlterContents();

						copy.AddPage(importedPage);
					}

					copy.FreeReader(reader);
					reader.Close();
				}

				document.Close();

				return memoryStream.GetBuffer();
			}
		}

		/// <summary>
		///    Merge pdf files.
		/// </summary>
		/// <param name="sourceFiles">Full path of PDF files being merged.</param>
		/// <param name="watermark">Write watermark or not.</param>
		/// <returns>Content of merged pdf.</returns>
		public static byte[] Merge(IEnumerable<string> sourceFiles,
		                           bool watermark = false)
		{
			return Merge(sourceFiles.Select(File.ReadAllBytes).ToList(),
			             watermark);
		}

		public static byte[] Merge(string file1,
		                           string file2,
		                           bool watermark = false)
		{
			return Merge(new Collections.Generic.List<string> {file1, file2},
			             watermark);
		}

		public static void Merge(string file1,
		                         string file2,
		                         string exportFile,
		                         bool watermark = false)
		{
			File.WriteAllBytes(exportFile,
			                   Merge(file1,
			                         file2,
			                         watermark));
		}
	}
}