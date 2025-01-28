using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Pipelines;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace MathLib
{
	public interface IRgbOperations<TSelf, TNum>
		where TSelf : IRgbOperations<TSelf, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{

	}

	public struct Rgb<TNum, TOps> : IRgbOperations<TOps, TNum>, IPixel<Rgb<TNum, TOps>>
		where TNum : unmanaged, INumericType<TNum>
		where TOps : IRgbOperations<TOps, TNum>
	{
		public static Rgb<TNum, TOps> Zero => new(TNum.Zero);

		public static ScalarType ChannelType => TNum.Type;

		public static int Channels => 3;

		public static int BitDepth => TNum.Size * 8;

		public TNum r;
		public TNum g;
		public TNum b;

		public Rgb(TNum value)
		{
			this.r = value;
			this.g = value;
			this.b = value;
		}

		public Rgb(TNum r, TNum g, TNum b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public override readonly string ToString() => $"{{R: {r} G: {g} B: {b}}}";
	}

	public struct Rgb_Ops_Generic<TNum> : IRgbOperations<Rgb_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{
	}
}
