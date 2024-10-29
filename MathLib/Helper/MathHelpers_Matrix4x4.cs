using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Add<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Add(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Subtract<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Subtract(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Negate<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Negate(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Multiply<TNum, TOps>(TNum left, ref readonly Matrix4x4<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Multiply(left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Multiply<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TVecOps> Multiply<TNum, TOps, TVecOps>(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Vector4<TNum, TVecOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
			where TVecOps : IVector4Operations<TVecOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Matrix4x4<TNum, TOps> Transpose<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Transpose(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Determinant<TNum, TOps>(ref readonly Matrix4x4<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IMatrix4x4Operations<TOps, TNum>
		{
			return Matrix4x4<TNum, TOps>.Determinant(in vec);
		}
	}
}
