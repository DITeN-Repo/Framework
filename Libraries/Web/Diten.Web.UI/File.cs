namespace Diten.Objects
{
	public class TmpFile
	{
		/// <summary>
		///     Type of the file.
		/// </summary>
		public FileType FileType { get; set; }

		public string IconCls => FileType.Icon.ToString();

		/// <summary>
		///     Name of the file
		/// </summary>
		public String Name { get; set; }
	}
}