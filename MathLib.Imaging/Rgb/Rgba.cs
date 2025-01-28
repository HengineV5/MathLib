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
	public interface IRgbaOperations<TSelf, TNum>
		where TSelf : IRgbaOperations<TSelf, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{
		
	}

	public struct Rgba<TNum, TOps> : IRgbaOperations<TOps, TNum>, IPixel<Rgba<TNum, TOps>>
		where TNum : unmanaged, INumericType<TNum>
		where TOps : IRgbaOperations<TOps, TNum>
	{
		public static Rgba<TNum, TOps> Zero => new(TNum.Zero);

		public static ScalarType ChannelType => TNum.Type;

		public static int Channels => 4;

		public static int BitDepth => TNum.Size * 8;

		public TNum r;
		public TNum g;
		public TNum b;
		public TNum a;

		public Rgba(TNum value)
		{
			this.r = value;
			this.g = value;
			this.b = value;
			this.a = value;
		}

		public Rgba(TNum r, TNum g, TNum b, TNum a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public override readonly string ToString() => $"{{R: {r} G: {g} B: {b} A: {a}}}";
	}

	public struct Rgba_Ops_Generic<TNum> : IRgbaOperations<Rgba_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{
	}
}
