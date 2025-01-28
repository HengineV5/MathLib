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
	public interface IYCbCrOperations<TSelf, TNum>
		where TSelf : IYCbCrOperations<TSelf, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{

	}

	public struct YCbCr<TNum, TOps> : IYCbCrOperations<TOps, TNum>, IPixel<YCbCr<TNum, TOps>>
		where TNum : unmanaged, INumericType<TNum>
		where TOps : IYCbCrOperations<TOps, TNum>
	{
		public static YCbCr<TNum, TOps> Zero => new(TNum.Zero);

		public static ScalarType ChannelType => TNum.Type;

		public static int Channels => 3;

		public static int BitDepth => TNum.Size * 8;

		public TNum y;
		public TNum cb;
		public TNum cr;

		public YCbCr(TNum value)
		{
			this.y = value;
			this.cb = value;
			this.cr = value;
		}

		public YCbCr(TNum y, TNum cb, TNum cr)
		{
			this.y = y;
			this.cb = cb;
			this.cr = cr;
		}

		public override readonly string ToString() => $"{{Y: {y} Cb: {cb} Cr: {cr}}}";
	}

	public struct YCbCr_Ops_Generic<TNum> : IYCbCrOperations<YCbCr_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, INumericType<TNum>
	{
	}
}
