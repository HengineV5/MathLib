using MathLib;
using System.Numerics;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Runner
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if RELEASE
			BenchmarkRunner.Run<PerfTests>();

#else
			Rgba32 pixel1 = new Rgba32(255, 255, 255, 0);
			Rgba64 pixel2 = new();

			Console.WriteLine(pixel2);
			ImageHelpers.Write(ref pixel2, in pixel1);

			Console.WriteLine(pixel1);
			Console.WriteLine(pixel2);
#endif
		}
	}

	[SimpleJob(RuntimeMoniker.Net90)]
	public class PerfTests
	{
		Vector3f v1;
		Vector3f v2;

		Vector3 v3;
		Vector3 v4;

		Vector3fo v5;
		Vector3fo v6;

		[GlobalSetup]
		public void Setup()
		{
			v1 = new(1, 2, 3);
			v2 = new(1, 0, 0);

			v3 = new(1, 2, 3);
			v4 = new(1, 0, 0);

			v5 = new(1, 2, 3);
			v6 = new(1, 0, 0);
		}

		[Benchmark(Baseline = true)]
		public void Add_Baseline()
		{
			for (int i = 0; i < 1_000_000; i++)
			{
				Vector3.Dot(v3, v4);
			}
		}

		//[Benchmark]
		public void Add_Custom()
		{
			for (int i = 0; i < 1_000_000; i++)
			{
				Vector3f.Dot(in v1, in v2);
			}
		}

		[Benchmark]
		public void Add_Custom_O()
		{
			for (int i = 0; i < 1_000_000; i++)
			{
				Vector3fo.Dot(in v5, in v6);
			}
		}

		[Benchmark]
		public void Add_Custom_O_Lib()
		{
			for (int i = 0; i < 1_000_000; i++)
			{
				MathHelpers.Dot(in v5, in v6);
			}
		}
		/*
		*/
	}
}
