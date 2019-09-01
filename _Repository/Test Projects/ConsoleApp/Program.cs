#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/07/30 4:59 PM

#endregion

#region Used Directives

using System;

#endregion

namespace ConsoleApp
{
	internal static class Program
	{
		private static void Main()
		{
			new Bmw1400zx().OpeningDoor();
			new Benz2000zx().PushStartButton();
			new Audi2000zx().Cabin.OpeningWindow();
			new Audi2000zx().Engine.StartEngine();
			new Audi2000zx().PushStartButton();

			Console.Read();
		}
	}

	#region Car Classes

	public class Car<TEngine, TCooler, TCabin>
		where TEngine : EngineBase, new()
		where TCooler : CoolerBase, new()
		where TCabin : CabinBase, new()
	{
		public TCooler Cooler => new TCooler();
		public TEngine Engine => new TEngine();
		public TCabin Cabin => new TCabin();
	}

	public class Benz2000zx : Car<Engine2000CC, Cooler1400CC, Cabin1600xsy>
	{
		public Benz2000zx()
		{
			Console.WriteLine("Benz2000zx Car");
		}

		public void OpeningDoor()
		{
			Cabin.OpeningDoor(CabinBase.DoorTypes.FrontLeft);
		}

		public void PushStartButton()
		{
			Engine.StartEngine();
		}
	}

	public class Audi2000zx : Car<Engine2000CC, Cooler2000CC, Cabin1600xsy>
	{
		public Audi2000zx()
		{
			Console.WriteLine("Audi2000zx Car");
		}

		public void OpeningDoor()
		{
			Cabin.OpeningDoor(CabinBase.DoorTypes.FrontLeft);
		}

		public void PushStartButton()
		{
			Engine.StartEngine();
		}
	}

	public class Bmw1400zx : Car<Engine1400CC, Cooler1400CC, Cabin1400zx>
	{
		public Bmw1400zx()
		{
			Console.WriteLine("Bmw1400zx Car");
		}

		public void OpeningDoor()
		{
			Cabin.OpeningDoor(CabinBase.DoorTypes.FrontLeft);
		}

		public void PushStartButton()
		{
			Engine.StartEngine();
		}
	}

	#endregion

	#region Engin Classes

	public class EngineBase
	{
		public int Cylinder { get; set; }

		public virtual void StartEngine()
		{
			Console.WriteLine(@"Standard Engine Start");
		}
	}

	public class Engine2000CC : EngineBase
	{
		public override void StartEngine()
		{
			base.StartEngine();
			Console.WriteLine(@"Engine2000CC Start srtjklhbgksjrhgiluksbgkljstjhgjh");
		}
	}

	public class Engine1400CC : EngineBase
	{
		public override void StartEngine()
		{
			base.StartEngine();
			Console.WriteLine(@"Engine1400CC Start");
		}
	}

	#endregion

	#region Cooler Classes

	public class CoolerBase
	{
		public int Cylinder { get; set; }

		public virtual void StartCooler()
		{
			Console.WriteLine(@"Standard Cooler Start");
		}
	}

	public class Cooler1400CC : CoolerBase
	{
		public override void StartCooler()
		{
			base.StartCooler();
			Console.WriteLine(@"Cooler1400CC Start");
		}
	}

	public class Cooler2000CC : CoolerBase
	{
		public override void StartCooler()
		{
			base.StartCooler();
			Console.WriteLine(@"Cooler2000CC Start");
		}
	}

	#endregion

	#region Cabin Classes

	public class CabinBase
	{
		public enum CabinTypes
		{
			SUV,
			Standard4Doors,
			Standard5Doors
		}

		public enum DoorTypes
		{
			FrontLeft,
			FrontRight,
			BackLeft,
			BackRight
		}

		public CabinTypes CabinType { get; set; }

		public virtual void OpeningDoor(DoorTypes doorType)
		{
			Console.WriteLine($@"Standard opening door {Enum.GetName(typeof(DoorTypes), doorType)}");
		}

		public virtual void OpeningWindow()
		{
			Console.WriteLine(@"Standard opening Window");
		}
	}

	public class Cabin1600xsy : CabinBase
	{
		public override void OpeningDoor(DoorTypes doorType)
		{
			base.OpeningDoor(doorType);
			Console.WriteLine($@"{GetType()} opening Door");
		}

		public override void OpeningWindow()
		{
			Console.WriteLine($@"{GetType()} opening Window");
		}
	}

	public class Cabin1400zx : CabinBase
	{
		public override void OpeningDoor(DoorTypes doorType)
		{
			base.OpeningDoor(doorType);
			Console.WriteLine($@"{GetType()} opening Door");
		}

		public override void OpeningWindow()
		{
			Console.WriteLine($@"{GetType()} opening Window");
		}
	}

	#endregion
}