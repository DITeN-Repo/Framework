#region Using Directives

using System;
using System.Collections.Generic;
using Diten.Objects;
using Diten.Text;
using Diten.Web.UI.WebControls;

// ReSharper disable All

#endregion

// ReSharper disable once CheckNamespace
namespace Diten.Data
{
	public static class Sample
	{
		public static List<TmpFile> Files
		{
			get
			{
				var _return = new List<TmpFile>();

				for (var i = 0; i < new Random().Next(20, 200); i++)
				{
					var file = new TmpFile
					{
						FileType = new FileType
						{
							Icon = new Icon(Icons.File),
							Extension = "tst",
							Title = "Test File"
						},
						Name = Tools.GetRandomText(Tools.AlphabetTypes.Simple, 10)
					};
					_return.Add(file);
				}

				return _return;
			}
		}
	}

	/// <summary>
	///     Sample data helper.
	/// </summary>
	public class SampleCompany
	{
		public static List<Company> GetData()
		{
			var today = DateTime.Today;

			return new List<Company>
			{
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "3m Co",
					Price = 71.72,
					Change = 0.02,
					PctChange = 0.03,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Alcoa Inc",
					Price = 29.01,
					Change = 0.42,
					PctChange = 1.47,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Altria Group Inc",
					Price = 83.81,
					Change = 0.28,
					PctChange = 0.34,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "American Express Company",
					Price = 52.55,
					Change = 0.01,
					PctChange = 0.02,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "American International Group, Inc.",
					Price = 64.13,
					Change = 0.31,
					PctChange = 0.49,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "AT&T Inc.",
					Price = 31.61,
					Change = -0.48,
					PctChange = -1.54,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Boeing Co.",
					Price = 75.43,
					Change = 0.53,
					PctChange = 0.71,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Caterpillar Inc.",
					Price = 67.27,
					Change = 0.92,
					PctChange = 1.39,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Citigroup, Inc.",
					Price = 49.37,
					Change = 0.02,
					PctChange = 0.04,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "E.I. du Pont de Nemours and Company",
					Price = 40.48,
					Change = 0.51,
					PctChange = 1.28,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Exxon Mobil Corp",
					Price = 68.1,
					Change = -0.43,
					PctChange = -0.64,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "General Electric Company",
					Price = 34.14,
					Change = -0.08,
					PctChange = -0.23,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "General Motors Corporation",
					Price = 30.27,
					Change = 1.09,
					PctChange = 3.74,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Hewlett-Packard Co.",
					Price = 36.53,
					Change = -0.03,
					PctChange = -0.08,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Honeywell Intl Inc",
					Price = 38.77,
					Change = 0.05,
					PctChange = 0.13,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Intel Corporation",
					Price = 19.88,
					Change = 0.31,
					PctChange = 1.58,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "International Business Machines",
					Price = 81.41,
					Change = 0.44,
					PctChange = 0.54,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Johnson & Johnson",
					Price = 64.72,
					Change = 0.06,
					PctChange = 0.09,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "JP Morgan & Chase & Co",
					Price = 45.73,
					Change = 0.07,
					PctChange = 0.15,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "McDonald\"s Corporation",
					Price = 36.76,
					Change = 0.86,
					PctChange = 2.40,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Merck & Co., Inc.",
					Price = 40.96,
					Change = 0.41,
					PctChange = 1.01,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Microsoft Corporation",
					Price = 25.84,
					Change = 0.14,
					PctChange = 0.54,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Pfizer Inc",
					Price = 27.96,
					Change = 0.4,
					PctChange = 1.45,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "The Coca-Cola Company",
					Price = 45.07,
					Change = 0.26,
					PctChange = 0.58,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "The Home Depot, Inc.",
					Price = 34.64,
					Change = 0.35,
					PctChange = 1.02,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "The Procter & Gamble Company",
					Price = 61.91,
					Change = 0.01,
					PctChange = 0.02,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "United Technologies Corporation",
					Price = 63.26,
					Change = 0.55,
					PctChange = 0.88,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Verizon Communications",
					Price = 35.57,
					Change = 0.39,
					PctChange = 1.11,
					LastChange = today
				},
				new Company
				{
					Id = Guid.NewGuid(),
					Name = "Wal-Mart Stores, Inc.",
					Price = 45.45,
					Change = 0.73,
					PctChange = 1.63,
					LastChange = today
				}
			};
		}

		public class Company
		{
			public double Change { get; set; }
			public Guid Id { get; set; }
			public DateTime LastChange { get; set; }
			public string Name { get; set; }
			public double PctChange { get; set; }
			public double Price { get; set; }
		}
	}

	public class Entity
	{
		public DateTime CreationDate { get; set; }
		public DateTime DateModified { get; set; }
		public string Description { get; set; }
		public string EntityType { get; set; }
		public string IconCls { get; set; }
		public Guid Id { get; set; }
		public string Title { get; set; }

		public static List<Entity> GetData()
		{
			var entityList = new List<Entity>();

			for (var i = 0; i <= 40; i++)
			{
				var entity = new Entity
				{
					Id = Guid.NewGuid(),
					Title = $@"Title-{Tools.GetRandomText(Tools.AlphabetTypes.Simple, 10)}",
					CreationDate = DateTime.Now.AddDays(-10),
					DateModified = DateTime.Now,
					Description = $@"Description-{Tools.GetRandomText(Tools.AlphabetTypes.Simple, 10)}"
				};

				var number = new Random().Next(0, 40);
				entity.EntityType = number <= 20 ? "fil" : "__fldr";
				entity.IconCls = number <= 20
					? Icons.File.ToString()
					: Icons.Folder.ToString();

				entityList.Add(entity);
			}

			return entityList;
		}
	}
}