using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Sqrt<TNum>(TNum num)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		{
			return TNum.Sqrt(num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Cos<TNum>(TNum num)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		{
			return TNum.Cos(num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Sin<TNum>(TNum num)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		{
			return TNum.Sin(num);
		}
	}
}
