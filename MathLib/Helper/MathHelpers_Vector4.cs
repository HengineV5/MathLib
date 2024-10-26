using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Add<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Add(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Subtract<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Subtract(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Negate<TNum, TOps>(ref readonly Vector4<TNum, TOps> vec)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Negate(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Multiply(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Divide<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Divide(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Dot<TNum, TOps>(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Dot(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum LengthSquared<TNum, TOps>(ref readonly Vector4<TNum, TOps> vec)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.LengthSquared(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Length<TNum, TOps>(ref readonly Vector4<TNum, TOps> vec)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Length(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4<TNum, TOps> Normalize<TNum, TOps>(ref readonly Vector4<TNum, TOps> vec)
			where TNum : unmanaged, IScalar<TNum>
			where TOps : IVector4Operations<TOps, TNum>
		{
			return Vector4<TNum, TOps>.Normalize(in vec);
		}
	}
}
