using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class ImageHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rgba<TNumTo, TOpsTo> Convert<TNumFrom, TOpsFrom, TNumTo, TOpsTo>(ref readonly Rgba<TNumFrom, TOpsFrom> value)
			where TNumFrom : unmanaged, INumericType<TNumFrom>, IConvertable<TNumFrom, TNumTo>
			where TOpsFrom : IRgbaOperations<TOpsFrom, TNumFrom>
			where TNumTo : unmanaged, INumericType<TNumTo>
			where TOpsTo : IRgbaOperations<TOpsTo, TNumTo>
		{
			return new Rgba<TNumTo, TOpsTo>(TNumFrom.Convert(value.r), TNumFrom.Convert(value.g), TNumFrom.Convert(value.b), TNumFrom.Convert(value.a));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Write<TNumDest, TOpsDest, TNumSrc, TOpsSrc>(ref Rgba<TNumDest, TOpsDest> dest, ref readonly Rgba<TNumSrc, TOpsSrc> src)
			where TNumDest : unmanaged, INumericType<TNumDest>
			where TOpsDest : IRgbaOperations<TOpsDest, TNumDest>
			where TNumSrc : unmanaged, INumericType<TNumSrc>, IConvertable<TNumSrc, TNumDest>
			where TOpsSrc : IRgbaOperations<TOpsSrc, TNumSrc>
		{
			dest.r = TNumSrc.Convert(src.r);
			dest.g = TNumSrc.Convert(src.g);
			dest.b = TNumSrc.Convert(src.b);
			dest.a = TNumSrc.Convert(src.a);
		}
	}
}
