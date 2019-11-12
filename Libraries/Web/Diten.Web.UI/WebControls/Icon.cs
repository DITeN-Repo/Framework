#region Using Directives

using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Security.Cryptography;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <summary>
	///     DITeN Icon object.
	/// </summary>
	/// <inheritdoc cref="http://help.diten.net/?Cat=Framework&Type=Diten_Enum" />
	[Meta]
	[ToolboxData("<{0}:Icon runat=\"server\"></{0}:Icon>")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class Icon : Image
	{
		/// <summary>
		///     Standard icon dimensions.
		/// </summary>
		public enum Dimensions
		{
			D16,
			D20,
			D24,
			D32,
			D40,
			D48,
			D60,
			D64,
			D72,
			D80,
			D96,
			D128,
			D256,
			D512,
			D768
		}


		private string ResourceUrl =>
			$@"{Constants.Default.TempFolderVirtualPath}/{Page.ResourceManager.Theme}_{Value}_Resource.png";

		private (string Url, string Name, Stream Resource) Resource =>
			ViewState.GetValue<(string Url, string Name, Stream Resource)>(this.GetFrameName(),
				Page.ResourceManager.GetIconResource(Value, true));

		/// <summary>
		///     Dimension of the icon.
		/// </summary>
		public Dimensions Dimension { get; set; }

		/// <summary>
		///     Get cls name of the icon.
		/// </summary>
		public string IconCls => $@"{Value}{Dimension.GetDimension()}";

		/// <summary>
		///     Icon from diten collection.
		/// </summary>
		public Icons Value { get; set; }

		/// <summary>
		///     Converting icon to base64 encrypted text.
		/// </summary>
		/// <returns></returns>
		public string ToBase64Text()
		{
			return Base64Text.Encrypt(ToStream());
		}

		/// <summary>
		///     Converting <see cref="Icon" /> into <see cref="Stream" />.
		/// </summary>
		/// <returns>An <see cref="Stream" /> from current <see cref="Icon" />.</returns>
		public Stream ToStream()
		{
			return Resource.Resource;
		}

		/// <summary>
		///     Converting <see cref="Icon" /> into <see cref="Bitmap" />.
		/// </summary>
		/// <returns>A <see cref="Bitmap" /> from current <see cref="Icon" />.</returns>
		public Bitmap ToBitmap()
		{
			return new Bitmap(ToStream());
		}

		/// <summary>
		///     Get icon string.
		/// </summary>
		/// <returns></returns>
		public new string ToString()
		{
			return IconCls;
		}

		/// <summary>
		///     Converting <see cref="Icon" /> into 16x16 dimension.
		/// </summary>
		/// <returns>An <see cref="Icon" /> with 16x16 dimension.</returns>
		public Icon ToD16()
		{
			return new Icon(Value, Dimensions.D16);
		}

		/// <summary>
		///     Converting <see cref="Icon" /> into <see cref="Dimensions" /> that you want.
		/// </summary>
		/// <returns>An <see cref="Icon" /> into <see cref="Dimensions" /> that you want.</returns>
		public Icon ToDimension(Dimensions dimension)
		{
			return new Icon(Value, dimension);
		}

		#region Constructors

		/// <inheritdoc />
		/// <summary>
		///     Constructor.
		/// </summary>
		public Icon() : this(Icons.Default)
		{
		}

		/// <inheritdoc />
		/// <summary>
		///     Constructor.
		/// </summary>
		/// <param name="icon">Icon form the icons collection.</param>
		public Icon(Icons icon) : this(icon, Dimensions.D16)
		{
		}

		/// <summary>
		///     Constructor.
		/// </summary>
		/// <param name="icon">Icon form the icons collection.</param>
		/// <param name="dimension">Dimension of the icon.</param>
		public Icon(Icons icon, Dimensions dimension)
		{
			Value = icon;
			Dimension = dimension;

			base.ImageUrl = Resource.Url; // $@"{ResourceUrl.Replace("_Resource.png", $@"_{Dimension.GetName()}.png")}";

			if (!Page.ResourceManager.ClientStyleBlockBag.Keys.Contains(IconCls))
				Page.ResourceManager.RegisterClientStyleBlock(IconCls,
					Dimension.GetDimension() >= 128
						? $@".{IconCls} {{" +
						  $@"background-image: url(data:image/svg+xml;base64,{ToBase64Text()}) !important;" +
						  "background-position: center;" +
						  "background-repeat: no-repeat;" +
						  "background-size: 70px;"
						: $@".{IconCls} {{ background-image: url(data:image/svg+xml;base64,{ToBase64Text()}') !important; }}");

			//base.ImageUrl
			//var resourceFilePath = Page.Server.MapPath(ResourceUrl);

			//if (System.IO.File.Exists(resourceFilePath)) return;

			//Diten.Security.Cryptography.Base64Text.Encrypt(Page.ResourceManager
			//    .GetThemeResource($"{Value.GetName()}.png").Resource);
			//var holder = new Bitmap(Page.ResourceManager.GetThemeResource($"{Value.GetName()}.png").Resource);
			//holder.Save(resourceFilePath ??
			//            throw new InvalidOperationException($@"Resource [{ResourceUrl}] not found."));
			//var filePath = Page.Server.MapPath(base.ImageUrl);

			//if (filePath != null && !System.IO.File.Exists(filePath))
			//    Drawing.Image.Resize(holder, Dimension.GetDimension(), Dimension.GetDimension()).Save(filePath);
		}

		#endregion
	}
}