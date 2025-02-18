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
			Quaternionf q_new_1 = new(0.5f, 0.66f, 0.33f, 0);
			Quaternionf q_new_2 = new(0.5f, 0.5f, 0, 0);

			Quaternion q_old_1 = new(0.5f, 0.66f, 0.33f, 0);
			Quaternion q_old_2 = new(0.5f, 0.5f, 0, 0);

			Vector3f v_new_1 = new(1.5f, 0.33f, 0);
			Vector3 v_old_1 = new(1.5f, 0.33f, 0);

			Vector3f r_new = Vector3f.Transform(v_new_1, in q_new_1);
			Vector3 r_old = Vector3.Transform(v_old_1, q_old_1);

			Console.WriteLine(r_new);
			Console.WriteLine(r_old);

			//Console.WriteLine(Quaternionf.Multiplty(qVec, Quaternionf.Inverse(q_new_1)));
			//Console.WriteLine(Quaternion.Multiply(qVec_old, Quaternion.Inverse(q_old_1)));

			//Console.WriteLine(Quaternionf.Conjugate(q_new_1));
			//Console.WriteLine(Quaternion.Conjugate(q_old_1));
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
