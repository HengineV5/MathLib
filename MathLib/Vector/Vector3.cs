using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace MathLib
{

	public interface IVector3Operations<TSelf, TNum>
		where TSelf : IVector3Operations<TSelf, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		static abstract Vector3<TNum, TSelf> Add(ref readonly Vector3<TNum, TSelf> left, ref readonly Vector3<TNum, TSelf> right);

		static abstract Vector3<TNum, TSelf> Subtract(ref readonly Vector3<TNum, TSelf> left, ref readonly Vector3<TNum, TSelf> right);

		static abstract Vector3<TNum, TSelf> Negate(ref readonly Vector3<TNum, TSelf> vec);

		static abstract Vector3<TNum, TSelf> Multiply(ref readonly Vector3<TNum, TSelf> left, ref readonly Vector3<TNum, TSelf> right);

		static abstract Vector3<TNum, TSelf> Multiply(ref readonly Vector3<TNum, TSelf> left, TNum right);

		static abstract Vector3<TNum, TSelf> Divide(ref readonly Vector3<TNum, TSelf> left, TNum right);

		static abstract Vector3<TNum, TSelf> Divide(TNum left, ref readonly Vector3<TNum, TSelf> right);

		static abstract TNum Dot(ref readonly Vector3<TNum, TSelf> left, ref readonly Vector3<TNum, TSelf> right);

		static abstract Vector3<TNum, TSelf> Cross(ref readonly Vector3<TNum, TSelf> left, ref readonly Vector3<TNum, TSelf> right);

		static abstract TNum LengthSquared(ref readonly Vector3<TNum, TSelf> vec);

		static abstract TNum Length(ref readonly Vector3<TNum, TSelf> vec);

		static abstract Vector3<TNum, TSelf> Normalize(ref readonly Vector3<TNum, TSelf> vec);

		static abstract Vector3<TNum, TSelf> Lerp(ref readonly Vector3<TNum, TSelf> start, ref readonly Vector3<TNum, TSelf> stop, TNum fraction);

		static abstract Vector3<TNum, TSelf> Transform<TQuaternionOps>(ref readonly Vector3<TNum, TSelf> vec, ref readonly Quaternion<TNum, TQuaternionOps> q)
			where TQuaternionOps : IQuaternionOperations<TQuaternionOps, TNum>;
	}

	public struct Vector3<TNum, TOps> : IVector3Operations<TOps, TNum>, IEquatable<Vector3<TNum, TOps>>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		where TOps : IVector3Operations<TOps, TNum>
	{
		public static Vector3<TNum, TOps> Zero => new(TNum.Zero);

		public static Vector3<TNum, TOps> One => new(TNum.One);

		public static Vector3<TNum, TOps> UnitX => new(TNum.One, TNum.Zero, TNum.Zero);

		public static Vector3<TNum, TOps> UnitY => new(TNum.Zero, TNum.One, TNum.Zero);

		public static Vector3<TNum, TOps> UnitZ => new(TNum.Zero, TNum.Zero, TNum.One);

		public TNum x;
		public TNum y;
		public TNum z;

		public Vector3(TNum value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
		}

		public Vector3(TNum x, TNum y, TNum z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector3<TNum, TOps> operator +(Vector3<TNum, TOps> left, Vector3<TNum, TOps> right) => TOps.Add(in left, in right);

		public static Vector3<TNum, TOps> operator -(Vector3<TNum, TOps> left, Vector3<TNum, TOps> right) => TOps.Subtract(in left, in right);

		public static Vector3<TNum, TOps> operator -(Vector3<TNum, TOps> vec) => TOps.Negate(in vec);

		public static Vector3<TNum, TOps> operator *(Vector3<TNum, TOps> left, Vector3<TNum, TOps> right) => TOps.Multiply(in left, in right);

		public static Vector3<TNum, TOps> operator *(Vector3<TNum, TOps> left, TNum right) => TOps.Multiply(in left, right);

		public static Vector3<TNum, TOps> operator *(TNum left, Vector3<TNum, TOps> right) => TOps.Multiply(in right, left);

		public static Vector3<TNum, TOps> operator /(Vector3<TNum, TOps> left, TNum right) => TOps.Divide(in left, right);

		public static Vector3<TNum, TOps> operator /(TNum left, Vector3<TNum, TOps> right) => TOps.Divide(left, in right);

		public static bool operator ==(Vector3<TNum, TOps> left, Vector3<TNum, TOps> right) => left.Equals(right);

		public static bool operator !=(Vector3<TNum, TOps> left, Vector3<TNum, TOps> right) => !left.Equals(right);

		public override readonly string ToString() => $"{{X: {x} Y: {y} Z: {z}}}";

		public static Vector3<TNum, TOps> Add(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			=> TOps.Add(in left, in right);

		public static Vector3<TNum, TOps> Subtract(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			=> TOps.Subtract(in left, in right);

		public static Vector3<TNum, TOps> Multiply(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
				=> TOps.Multiply(in left, in right);

		public static Vector3<TNum, TOps> Multiply(ref readonly Vector3<TNum, TOps> left, TNum right)
			=> TOps.Multiply(in left, right);

		public static Vector3<TNum, TOps> Divide(ref readonly Vector3<TNum, TOps> left, TNum right)
			=> TOps.Divide(in left, right);

		public static Vector3<TNum, TOps> Divide(TNum left, ref readonly Vector3<TNum, TOps> right)
		 => TOps.Divide(left, in right);

		public static Vector3<TNum, TOps> Negate(ref readonly Vector3<TNum, TOps> vec)
			=> TOps.Negate(in vec);

		public static TNum Dot(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			=> TOps.Dot(in left, in right);

		public static Vector3<TNum, TOps> Cross(ref readonly Vector3<TNum, TOps> left, ref readonly Vector3<TNum, TOps> right)
			=> TOps.Cross(in left, in right);

		public static TNum LengthSquared(ref readonly Vector3<TNum, TOps> vec)
			=> TOps.LengthSquared(in vec);

		public static TNum Length(ref readonly Vector3<TNum, TOps> vec)
			=> TOps.Length(in vec);

		public static Vector3<TNum, TOps> Normalize(ref readonly Vector3<TNum, TOps> vec)
			=> TOps.Normalize(in vec);

		public static Vector3<TNum, TOps> Lerp(ref readonly Vector3<TNum, TOps> start, ref readonly Vector3<TNum, TOps> stop, TNum fraction)
			=> TOps.Lerp(in start, in stop, fraction);

		public static Vector3<TNum, TOps> Transform<TQuaternionOps>(ref readonly Vector3<TNum, TOps> vec, ref readonly Quaternion<TNum, TQuaternionOps> q) where TQuaternionOps : IQuaternionOperations<TQuaternionOps, TNum>
			=> TOps.Transform(in vec, in q);

		public static Vector3<TNum, TOps> FromVector2<T>(ref readonly Vector2<TNum, T> vec)
			where T : IVector2Operations<T, TNum>
		{
			return new Vector3<TNum, TOps>(vec.x, vec.y, TNum.Zero);
		}

		public bool Equals(Vector3<TNum, TOps> other)
		{
			return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
		}
	}

	public struct Vector3_Ops_Generic<TNum> : IVector3Operations<Vector3_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Add(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			return new(right.x + left.x, right.y + left.y, right.z + left.z);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Multiply(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			return new(right.x * left.x, right.y * left.y, right.z * left.z);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Multiply(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x * right, left.y * right, left.z * right);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Divide(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, TNum right)
		{
			return new(left.x / right, left.y / right, left.z / right);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Divide(TNum left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			return new(left / right.x, left / right.y, left / right.z);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Negate(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> vec)
		{
			return new(-vec.x, -vec.y, -vec.z);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Subtract(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			return new(left.x - right.x, left.y - right.y, left.z - right.z);
		}

		public static TNum Dot(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			var mul = Multiply(in right, in left);
			return mul.x + mul.y + mul.z;
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Cross(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> right)
		{
			return new(left.y * right.z - left.z * right.y, left.z * right.x - left.x * right.z, left.x * right.y - left.y * right.x);
		}

		public static TNum LengthSquared(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> vec)
		{
			return Dot(in vec, in vec);
		}

		public static TNum Length(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> vec)
		{
			return TNum.Sqrt(LengthSquared(in vec));
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Normalize(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> vec)
		{
			return vec / Length(in vec);
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Lerp(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> start, ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> stop, TNum fraction)
		{
			return start + (stop - start) * fraction;
		}

		public static Vector3<TNum, Vector3_Ops_Generic<TNum>> Transform<TQuaternionOps>(ref readonly Vector3<TNum, Vector3_Ops_Generic<TNum>> vec, ref readonly Quaternion<TNum, TQuaternionOps> q) where TQuaternionOps : IQuaternionOperations<TQuaternionOps, TNum>
		{
			Quaternion<TNum, TQuaternionOps> qv = new(vec.x, vec.y, vec.z, TNum.Zero);
			var qi = Quaternion<TNum, TQuaternionOps>.Conjugate(in q);

			var q1 = Quaternion<TNum, TQuaternionOps>.Multiplty(in q, in qv);
			Quaternion<TNum, TQuaternionOps> qr = Quaternion<TNum, TQuaternionOps>.Multiplty(in q1, in qi);
			return new(qr.x, qr.y, qr.z);
		}
	}

	public struct Vector3_Ops_Float : IVector3Operations<Vector3_Ops_Float, Float32>
	{
		public unsafe static Vector3<Float32, Vector3_Ops_Float> Add(ref readonly Vector3<Float32, Vector3_Ops_Float> left, ref readonly Vector3<Float32, Vector3_Ops_Float> right)
		{
			var r = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)) + Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in right));
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Divide(ref readonly Vector3<Float32, Vector3_Ops_Float> left, Float32 right)
		{
			var r = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)) / right;
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Vector3fo Divide(Float32 left, ref readonly Vector3fo right)
		{
			throw new NotImplementedException();
		}

		public static Vector3<Float32, Vector3_Ops_Float> Multiply(ref readonly Vector3<Float32, Vector3_Ops_Float> left, ref readonly Vector3<Float32, Vector3_Ops_Float> right)
		{
			var r = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)) * Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in right));
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Multiply(ref readonly Vector3<Float32, Vector3_Ops_Float> left, Float32 right)
		{
			var r = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)) * right;
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Negate(ref readonly Vector3<Float32, Vector3_Ops_Float> vec)
		{
			var r = -Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in vec));
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Subtract(ref readonly Vector3<Float32, Vector3_Ops_Float> left, ref readonly Vector3<Float32, Vector3_Ops_Float> right)
		{
			var r = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)) - Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in right));
			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Float32 Dot(ref readonly Vector3<Float32, Vector3_Ops_Float> left, ref readonly Vector3<Float32, Vector3_Ops_Float> right)
		{
			//return Vector128.Dot(Unsafe.As<Vector3<Signed32BitFloat, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left)), Unsafe.As<Vector3<Signed32BitFloat, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in right)));
			return DotInternal(left, right);
		}

		static Float32 DotInternal(Vector3<Float32, Vector3_Ops_Float> left, Vector3<Float32, Vector3_Ops_Float> right)
		{
			// Vector128.Dot modifies both values
			return Vector128.Dot(Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref left), Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref right));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Cross(ref readonly Vector3<Float32, Vector3_Ops_Float> left, ref readonly Vector3<Float32, Vector3_Ops_Float> right)
		{
			// This was taken from dotnet runtime implementation.
			// This implementation is based on the DirectX Math Library XMVector3Cross method
			// https://github.com/microsoft/DirectXMath/blob/master/Inc/DirectXMathVector.inl

			var v1 = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in left));
			var v2 = Unsafe.As<Vector3<Float32, Vector3_Ops_Float>, Vector128<float>>(ref Unsafe.AsRef(in right));

			Vector128<float> temp = Vector128.Shuffle(v1, Vector128.Create(1, 2, 0, 3)) * Vector128.Shuffle(v2, Vector128.Create(2, 0, 1, 3));

			var r = Vector128.MultiplyAddEstimate(
				-Vector128.Shuffle(v1, Vector128.Create(2, 0, 1, 3)),
				 Vector128.Shuffle(v2, Vector128.Create(1, 2, 0, 3)),
				 temp
			);

			return Unsafe.ReadUnaligned<Vector3<Float32, Vector3_Ops_Float>>(ref Unsafe.As<Vector128<float>, byte>(ref r));
		}

		public static Float32 LengthSquared(ref readonly Vector3<Float32, Vector3_Ops_Float> vec)
		{
			return Dot(in vec, in vec);
		}

		public static Float32 Length(ref readonly Vector3<Float32, Vector3_Ops_Float> vec)
		{
			return Float32.Sqrt(LengthSquared(in vec));
		}

		public static Vector3<Float32, Vector3_Ops_Float> Normalize(ref readonly Vector3<Float32, Vector3_Ops_Float> vec)
		{
			return vec / Length(in vec);
		}

		public static Vector3fo Lerp(ref readonly Vector3fo start, ref readonly Vector3fo stop, Float32 fraction)
		{
			throw new NotImplementedException();
		}

		public static Vector3fo Transform<TQuaternionOps>(ref readonly Vector3<Float32, Vector3_Ops_Float> vec, ref readonly Quaternion<Float32, TQuaternionOps> q) where TQuaternionOps : IQuaternionOperations<TQuaternionOps, Float32>
		{
			throw new NotImplementedException();
		}
	}
}
