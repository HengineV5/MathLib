using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace MathLib
{
	public interface IVector2Operations<TSelf, TNum>
		where TSelf : IVector2Operations<TSelf, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		static abstract Vector2<TNum, TSelf> Add(ref readonly Vector2<TNum, TSelf> left, ref readonly Vector2<TNum, TSelf> right);

		static abstract Vector2<TNum, TSelf> Subtract(ref readonly Vector2<TNum, TSelf> left, ref readonly Vector2<TNum, TSelf> right);

		static abstract Vector2<TNum, TSelf> Negate(ref readonly Vector2<TNum, TSelf> vec);

		static abstract Vector2<TNum, TSelf> Multiply(ref readonly Vector2<TNum, TSelf> left, ref readonly Vector2<TNum, TSelf> right);

		static abstract Vector2<TNum, TSelf> Multiply(ref readonly Vector2<TNum, TSelf> left, TNum right);

		static abstract Vector2<TNum, TSelf> Divide(ref readonly Vector2<TNum, TSelf> left, TNum right);

		static abstract Vector2<TNum, TSelf> Divide(TNum left, ref readonly Vector2<TNum, TSelf> right);

		static abstract TNum Dot(ref readonly Vector2<TNum, TSelf> left, ref readonly Vector2<TNum, TSelf> right);

		static abstract TNum LengthSquared(ref readonly Vector2<TNum, TSelf> vec);

		static abstract TNum Length(ref readonly Vector2<TNum, TSelf> vec);

		static abstract Vector2<TNum, TSelf> Normalize(ref readonly Vector2<TNum, TSelf> vec);

		static abstract Vector2<TNum, TSelf> Abs(ref readonly Vector2<TNum, TSelf> vec);

		static abstract Vector2<TNum, TSelf> Lerp(ref readonly Vector2<TNum, TSelf> start, ref readonly Vector2<TNum, TSelf> stop, TNum fraction);
	}

	public struct Vector2<TNum, TOps> : IVector2Operations<TOps, TNum>, IEquatable<Vector2<TNum, TOps>>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		where TOps : IVector2Operations<TOps, TNum>
	{
		public static Vector2<TNum, TOps> Zero => new(TNum.Zero);

		public static Vector2<TNum, TOps> One => new(TNum.One);

		public static Vector2<TNum, TOps> UnitX => new(TNum.One, TNum.Zero);

		public static Vector2<TNum, TOps> UnitY => new(TNum.Zero, TNum.One);

		public TNum x;
		public TNum y;

		public Vector2(TNum value)
		{
			this.x = value;
			this.y = value;
		}

		public Vector2(TNum x, TNum y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2<TNum, TOps> operator +(Vector2<TNum, TOps> left, Vector2<TNum, TOps> right) => TOps.Add(in left, in right);

		public static Vector2<TNum, TOps> operator -(Vector2<TNum, TOps> left, Vector2<TNum, TOps> right) => TOps.Subtract(in left, in right);

		public static Vector2<TNum, TOps> operator -(Vector2<TNum, TOps> vec) => TOps.Negate(in vec);

		public static Vector2<TNum, TOps> operator *(Vector2<TNum, TOps> left, Vector2<TNum, TOps> right) => TOps.Multiply(in left, in right);

		public static Vector2<TNum, TOps> operator *(Vector2<TNum, TOps> left, TNum right) => TOps.Multiply(in left, right);

		public static Vector2<TNum, TOps> operator *(TNum left, Vector2<TNum, TOps> right) => TOps.Multiply(in right, left);

		public static Vector2<TNum, TOps> operator /(Vector2<TNum, TOps> left, TNum right) => TOps.Divide(in left, right);

		public static Vector2<TNum, TOps> operator /(TNum left, Vector2<TNum, TOps> right) => TOps.Divide(left, in right);

		public static bool operator ==(Vector2<TNum, TOps> left, Vector2<TNum, TOps> right) => left.Equals(right);

		public static bool operator !=(Vector2<TNum, TOps> left, Vector2<TNum, TOps> right) => !left.Equals(right);

		public override readonly string ToString() => $"{{X: {x} Y: {y}}}";

		public static Vector2<TNum, TOps> Add(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			=> TOps.Add(in left, in right);

		public static Vector2<TNum, TOps> Subtract(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			=> TOps.Subtract(in left, in right);

		public static Vector2<TNum, TOps> Multiply(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
				=> TOps.Multiply(in left, in right);

		public static Vector2<TNum, TOps> Multiply(ref readonly Vector2<TNum, TOps> left, TNum right)
			=> TOps.Multiply(in left, right);

		public static Vector2<TNum, TOps> Divide(ref readonly Vector2<TNum, TOps> left, TNum right)
			=> TOps.Divide(in left, right);

		public static Vector2<TNum, TOps> Divide(TNum left, ref readonly Vector2<TNum, TOps> right)
			=> TOps.Divide(left, in right);

		public static Vector2<TNum, TOps> Negate(ref readonly Vector2<TNum, TOps> vec)
			=> TOps.Negate(in vec);

		public static TNum Dot(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			=> TOps.Dot(in left, in right);

		public static TNum LengthSquared(ref readonly Vector2<TNum, TOps> vec)
			=> TOps.LengthSquared(in vec);

		public static TNum Length(ref readonly Vector2<TNum, TOps> vec)
			=> TOps.Length(in vec);

		public static Vector2<TNum, TOps> Normalize(ref readonly Vector2<TNum, TOps> vec)
			=> TOps.Normalize(in vec);

		public static Vector2<TNum, TOps> Abs(ref readonly Vector2<TNum, TOps> vec)
			=> TOps.Abs(in vec);

		public static Vector2<TNum, TOps> Lerp(ref readonly Vector2<TNum, TOps> start, ref readonly Vector2<TNum, TOps> stop, TNum fraction)
			=> TOps.Lerp(in start, in stop, fraction);

		public bool Equals(Vector2<TNum, TOps> other)
		{
			return x.Equals(other.x) && y.Equals(other.y);
		}
	}

	public struct Vector2_Ops_Generic<TNum> : IVector2Operations<Vector2_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Add(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> right)
		{
			return new(right.x + left.x, right.y + left.y);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Multiply(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> right)
		{
			return new(right.x * left.x, right.y * left.y);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Multiply(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x * right, left.y * right);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Divide(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x / right, left.y / right);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Divide(TNum left, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> right)
		{
			return new(left / right.x, left / right.y);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Negate(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> vec)
		{
			return new(-vec.x,  -vec.y);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Subtract(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> right)
		{
			return new(left.x - right.x, left.y - right.y);
		}

		public static TNum Dot(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> left, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> right)
		{
			var mul = Multiply(in right, in left);
			return mul.x + mul.y;
		}

		public static TNum LengthSquared(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> vec)
		{
			return Dot(in vec, in vec);
		}

		public static TNum Length(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> vec)
		{
			return TNum.Sqrt(LengthSquared(in vec));
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Normalize(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> vec)
		{
			return vec / Length(in vec);
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Abs(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> vec)
		{
			return new(TNum.Abs(vec.x), TNum.Abs(vec.y));
		}

		public static Vector2<TNum, Vector2_Ops_Generic<TNum>> Lerp(ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> start, ref readonly Vector2<TNum, Vector2_Ops_Generic<TNum>> stop, TNum fraction)
		{
			return start + (stop - start) * fraction;
		}
	}
}
