﻿using MathLib.Vector.Extensions;
using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Add<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Add(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Subtract<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Subtract(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Negate<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Negate(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Multiply(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Divide<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Divide(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Divide<TNum, TOps>(TNum left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Divide(left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Dot<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Dot(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Cross<TNum, TOps>(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Cross(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum LengthSquared<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.LengthSquared(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Length<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Length(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Normalize<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Normalize(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Abs<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Abs(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Lerp<TNum, TOps>(ref readonly Vector3<TNum, TOps> start, ref readonly Vector3<TNum, TOps> stop, TNum fraction)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return Vector3<TNum, TOps>.Lerp(in stop, in stop, fraction);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Orthogonal<TNum, TOps>(ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			return vec.Orthogonal();
		}
	}
}
