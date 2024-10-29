using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Add<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Add(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Subtract<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Subtract(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Negate<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Negate(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Multiply<TNum, TOps>(TNum left, ref readonly Matrix3x3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Multiply(left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Multiply<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TVecOps> Multiply<TNum, TOps, TVecOps>(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Vector3<TNum, TVecOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix3x3<TNum, TOps> Transpose<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Transpose(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Determinant<TNum, TOps>(ref readonly Matrix3x3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix3x3Operations<TOps, TNum>
		{
			return Matrix3x3<TNum, TOps>.Determinant(in vec);
		}
	}
}
