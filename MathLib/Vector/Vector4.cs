using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace MathLib
{
	public interface IVector4Operations<TSelf, TNum>
		where TSelf : IVector4Operations<TSelf, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		static abstract Vector4<TNum, TSelf> Add(ref readonly Vector4<TNum, TSelf> left, ref readonly Vector4<TNum, TSelf> right);

		static abstract Vector4<TNum, TSelf> Subtract(ref readonly Vector4<TNum, TSelf> left, ref readonly Vector4<TNum, TSelf> right);

		static abstract Vector4<TNum, TSelf> Negate(ref readonly Vector4<TNum, TSelf> vec);

		static abstract Vector4<TNum, TSelf> Multiply(ref readonly Vector4<TNum, TSelf> left, ref readonly Vector4<TNum, TSelf> right);

		static abstract Vector4<TNum, TSelf> Multiply(ref readonly Vector4<TNum, TSelf> left, TNum right);

		static abstract Vector4<TNum, TSelf> Divide(ref readonly Vector4<TNum, TSelf> left, TNum right);

		static abstract TNum Dot(ref readonly Vector4<TNum, TSelf> left, ref readonly Vector4<TNum, TSelf> right);

		static abstract TNum LengthSquared(ref readonly Vector4<TNum, TSelf> vec);

		static abstract TNum Length(ref readonly Vector4<TNum, TSelf> vec);

		static abstract Vector4<TNum, TSelf> Normalize(ref readonly Vector4<TNum, TSelf> vec);
	}

	public struct Vector4<TNum, TOps> : IVector4Operations<TOps, TNum>
		where TNum : unmanaged, IScalar<TNum>
		where TOps : IVector4Operations<TOps, TNum>
	{
		public static Vector4<TNum, TOps> Zero => new(TNum.Zero);

		public static Vector4<TNum, TOps> One => new(TNum.One);

		public static Vector4<TNum, TOps> UnitX => new(TNum.One, TNum.Zero, TNum.Zero, TNum.Zero);

		public static Vector4<TNum, TOps> UnitY => new(TNum.Zero, TNum.One, TNum.Zero, TNum.Zero);

		public static Vector4<TNum, TOps> UnitZ => new(TNum.Zero, TNum.Zero, TNum.One, TNum.Zero);

		public static Vector4<TNum, TOps> UnitW => new(TNum.Zero, TNum.Zero, TNum.Zero, TNum.One);


		public TNum x;
		public TNum y;
		public TNum z;
		public TNum w;

		public Vector4(TNum value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
			this.w = value;
		}

		public Vector4(TNum x, TNum y, TNum z, TNum w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static Vector4<TNum, TOps> operator +(Vector4<TNum, TOps> left, Vector4<TNum, TOps> right) => TOps.Add(in left, in right);

		public static Vector4<TNum, TOps> operator -(Vector4<TNum, TOps> left, Vector4<TNum, TOps> right) => TOps.Subtract(in left, in right);

		public static Vector4<TNum, TOps> operator -(Vector4<TNum, TOps> vec) => TOps.Negate(in vec);

		public static Vector4<TNum, TOps> operator *(Vector4<TNum, TOps> left, Vector4<TNum, TOps> right) => TOps.Multiply(in left, in right);

		public static Vector4<TNum, TOps> operator *(Vector4<TNum, TOps> left, TNum right) => TOps.Multiply(in left, right);

		public static Vector4<TNum, TOps> operator *(TNum left, Vector4<TNum, TOps> right) => TOps.Multiply(in right, left);

		public static Vector4<TNum, TOps> operator /(Vector4<TNum, TOps> left, TNum right) => TOps.Divide(in left, right);

		public override readonly string ToString() => $"{{X: {x} Y: {y} Z: {z} W: {w}}}";

		public static Vector4<TNum, TOps> Add(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			=> TOps.Add(in left, in right);

		public static Vector4<TNum, TOps> Subtract(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			=> TOps.Subtract(in left, in right);

		public static Vector4<TNum, TOps> Multiply(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
				=> TOps.Multiply(in left, in right);

		public static Vector4<TNum, TOps> Multiply(ref readonly Vector4<TNum, TOps> left, TNum right)
			=> TOps.Multiply(in left, right);

		public static Vector4<TNum, TOps> Divide(ref readonly Vector4<TNum, TOps> left, TNum right)
			=> TOps.Divide(in left, right);

		public static Vector4<TNum, TOps> Negate(ref readonly Vector4<TNum, TOps> vec)
			=> TOps.Negate(in vec);

		public static TNum Dot(ref readonly Vector4<TNum, TOps> left, ref readonly Vector4<TNum, TOps> right)
			=> TOps.Dot(in left, in right);

		public static TNum LengthSquared(ref readonly Vector4<TNum, TOps> vec)
			=> TOps.LengthSquared(in vec);

		public static TNum Length(ref readonly Vector4<TNum, TOps> vec)
			=> TOps.Length(in vec);

		public static Vector4<TNum, TOps> Normalize(ref readonly Vector4<TNum, TOps> vec)
			=> TOps.Normalize(in vec);

		public static Vector4<TNum, TOps> FromVector3<T>(ref readonly Vector3<TNum, T> vec)
			where T : IVector3Operations<T, TNum>
		{
			return new Vector4<TNum, TOps>(vec.x, vec.y, vec.z, TNum.Zero);
		}
	}

	public struct Vector4_Ops_Generic<TNum> : IVector4Operations<Vector4_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Add(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> right)
		{
			return new(right.x + left.x, right.y + left.y, right.z + left.z, right.w + left.w);
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Multiply(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> right)
		{
			return new(right.x * left.x, right.y * left.y, right.z * left.z, right.w * left.w);
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Multiply(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x * right, left.y * right, left.z * right, left.w * right);
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Divide(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x / right, left.y / right, left.z / right, left.w / right);
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Negate(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> vec)
		{
			return new(-vec.x,  -vec.y, -vec.z, -vec.w);
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Subtract(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> right)
		{
			return new(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
		}

		public static TNum Dot(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> left, ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> right)
		{
			var mul = Multiply(in right, in left);
			return mul.x + mul.y + mul.z + mul.w;
		}

		public static TNum LengthSquared(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> vec)
		{
			return Dot(in vec, in vec);
		}

		public static TNum Length(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> vec)
		{
			return TNum.Sqrt(LengthSquared(in vec));
		}

		public static Vector4<TNum, Vector4_Ops_Generic<TNum>> Normalize(ref readonly Vector4<TNum, Vector4_Ops_Generic<TNum>> vec)
		{
			return vec / Length(in vec);
		}
	}
}
