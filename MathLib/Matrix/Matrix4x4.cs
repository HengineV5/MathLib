
using System;

namespace MathLib
{
	public interface IMatrix4x4Operations<TSelf, TNum>
		where TSelf : IMatrix4x4Operations<TSelf, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		static abstract Matrix4x4<TNum, TSelf> Add(ref readonly Matrix4x4<TNum, TSelf> left, ref readonly Matrix4x4<TNum, TSelf> right);

		static abstract Matrix4x4<TNum, TSelf> Subtract(ref readonly Matrix4x4<TNum, TSelf> left, ref readonly Matrix4x4<TNum, TSelf> right);

		static abstract Matrix4x4<TNum, TSelf> Negate(ref readonly Matrix4x4<TNum, TSelf> value);

		static abstract Matrix4x4<TNum, TSelf> Multiply(TNum left, ref readonly Matrix4x4<TNum, TSelf> right);

		static abstract Matrix4x4<TNum, TSelf> Multiply(ref readonly Matrix4x4<TNum, TSelf> left, ref readonly Matrix4x4<TNum, TSelf> right);

		static abstract Vector4<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix4x4<TNum, TSelf> left, ref readonly Vector4<TNum, TVecOps> right)
			where TVecOps : IVector4Operations<TVecOps, TNum>;

		static abstract Matrix4x4<TNum, TSelf> Transpose(ref readonly Matrix4x4<TNum, TSelf> value);

		static abstract TNum Determinant(ref readonly Matrix4x4<TNum, TSelf> value);
	}

	public struct Matrix4x4<TNum, TOps> : IMatrix4x4Operations<TOps, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		where TOps : IMatrix4x4Operations<TOps, TNum>
	{
		public static Matrix4x4<TNum, TOps> Identity => new(
				TNum.One, TNum.Zero, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.One, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.One, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);

		public TNum m11;
		public TNum m12;
		public TNum m13;
		public TNum m14;
		public TNum m21;
		public TNum m22;
		public TNum m23;
		public TNum m24;
		public TNum m31;
		public TNum m32;
		public TNum m33;
		public TNum m34;
		public TNum m41;
		public TNum m42;
		public TNum m43;
		public TNum m44;

		public Matrix4x4(TNum m11, TNum m12, TNum m13, TNum m14, TNum m21, TNum m22, TNum m23, TNum m24, TNum m31, TNum m32, TNum m33, TNum m34, TNum m41, TNum m42, TNum m43, TNum m44)
		{
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m14 = m14;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m24 = m24;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
			this.m34 = m34;
			this.m41 = m41;
			this.m42 = m42;
			this.m43 = m43;
			this.m44 = m44;
		}

		public static Matrix4x4<TNum, TOps> operator +(Matrix4x4<TNum, TOps> left, Matrix4x4<TNum, TOps> right) => TOps.Add(in left, in right);

		public static Matrix4x4<TNum, TOps> operator -(Matrix4x4<TNum, TOps> left, Matrix4x4<TNum, TOps> right) => TOps.Subtract(in left, in right);

		public static Matrix4x4<TNum, TOps> operator -(Matrix4x4<TNum, TOps> matrix) => TOps.Negate(in matrix);

		public static Matrix4x4<TNum, TOps> operator *(Matrix4x4<TNum, TOps> left, Matrix4x4<TNum, TOps> right) => TOps.Multiply(in left, in right);

		public static Matrix4x4<TNum, TOps> operator *(TNum left, Matrix4x4<TNum, TOps> right) => TOps.Multiply(left, in right);

		public override readonly string ToString()
			=> $"{{ {{M11:{m11} M12:{m12} M13:{m13} M14:{m14}}} {{M21:{m21} M22:{m22} M23:{m23} M24:{m24}}} {{M31:{m31} M32:{m32} M33:{m33} M34:{m34}}} {{M41:{m41} M42:{m42} M43:{m43} M44:{m44}}} }}";

		public static Vector4<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Vector4<TNum, TVecOps> right) where TVecOps : IVector4Operations<TVecOps, TNum>
			=> TOps.Multiply(in left, in right);

		public static Matrix4x4<TNum, TOps> Multiply(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			=> TOps.Multiply(in left, in right);

		public static Matrix4x4<TNum, TOps> Add(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			=> TOps.Add(in left, in right);

		public static Matrix4x4<TNum, TOps> Subtract(ref readonly Matrix4x4<TNum, TOps> left, ref readonly Matrix4x4<TNum, TOps> right)
			=> TOps.Subtract(in left, in right);

		public static Matrix4x4<TNum, TOps> Negate(ref readonly Matrix4x4<TNum, TOps> value)
			=> TOps.Negate(in value);

		public static Matrix4x4<TNum, TOps> Multiply(TNum left, ref readonly Matrix4x4<TNum, TOps> right)
			=> TOps.Multiply(left, in right);

		public static Matrix4x4<TNum, TOps> Transpose(ref readonly Matrix4x4<TNum, TOps> value)
			=> TOps.Transpose(in value);

		public static TNum Determinant(ref readonly Matrix4x4<TNum, TOps> value)
			=> TOps.Determinant(in value);

		public static Matrix4x4<TNum, TOps> FromMatrix3x3<T>(ref readonly Matrix3x3<TNum, T> value)
			where T : IMatrix3x3Operations<T, TNum>
		{
			return new Matrix4x4<TNum, TOps>(
				value.m11, value.m12, value.m13, TNum.Zero,
				value.m21, value.m22, value.m23, TNum.Zero,
				value.m31, value.m32, value.m33, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.Zero
			);
		}

		// https://www.songho.ca/opengl/gl_quaternion.html
		public static Matrix4x4<TNum, TOps> FromQuaternion<TQOps>(ref readonly Quaternion<TNum, TQOps> value)
			where TQOps : IQuaternionOperations<TQOps, TNum>
		{
			return new Matrix4x4<TNum, TOps>(
				TNum.One - TNum.Two * (value.y * value.y + value.z * value.z), TNum.Two * (value.x * value.y - value.w * value.z), TNum.Two * (value.z * value.x + value.w * value.y), TNum.Zero,
				TNum.Two * (value.x * value.y + value.w * value.z), TNum.One - TNum.Two * (value.x * value.x + value.z * value.z), TNum.Two * (value.y * value.z - value.w * value.x), TNum.Zero,
				TNum.Two * (value.x * value.z - value.w * value.y), TNum.Two * (value.y * value.z + value.w * value.x), TNum.One - TNum.Two * (value.x * value.x + value.y * value.y), TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateTranslation<TVecOps>(ref readonly Vector3<TNum, TVecOps> vec)
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			return new(
				TNum.One, TNum.Zero, TNum.Zero, vec.x,
				TNum.Zero, TNum.One, TNum.Zero, vec.y,
				TNum.Zero, TNum.Zero, TNum.One, vec.z,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateRotationX(TNum radians)
		{
			return new(
				TNum.One, TNum.Zero, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.Cos(radians), -TNum.Sin(radians), TNum.Zero,
				TNum.Zero, TNum.Sin(radians), TNum.Cos(radians), TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateRotationY(TNum radians)
		{
			return new(
				TNum.Cos(radians), TNum.Zero, -TNum.Sin(radians), TNum.Zero,
				TNum.Zero, TNum.One, TNum.Zero, TNum.Zero,
				TNum.Sin(radians), TNum.Zero, TNum.Cos(radians), TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateRotationZ(TNum radians)
		{
			return new(
				TNum.Cos(radians), -TNum.Sin(radians), TNum.Zero, TNum.Zero,
				-TNum.Sin(radians), TNum.Cos(radians), TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.One, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateRotation(TNum roll, TNum pitch, TNum yaw)
		{
			return CreateRotationZ(yaw) * CreateRotationY(pitch) * CreateRotationX(roll);
		}

		public static Matrix4x4<TNum, TOps> CreateScale<TVecOps>(ref readonly Vector3<TNum, TVecOps> vec)
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			return new(
				vec.x, TNum.Zero, TNum.Zero, TNum.Zero,
				TNum.Zero, vec.y, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.Zero, vec.z, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreateLookAt<TVecOps>(ref readonly Vector3<TNum, TVecOps> forward, ref readonly Vector3<TNum, TVecOps> right, ref readonly Vector3<TNum, TVecOps> up)
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			return new(
				right.x, right.y, right.z, TNum.Zero,
				up.x, up.y, up.z, TNum.Zero,
				forward.x, forward.y, forward.z, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.Zero, TNum.One
			);
		}

		public static Matrix4x4<TNum, TOps> CreatePersperctive(TNum fieldOfView, TNum aspectRatio, TNum nearPlane, TNum farPlane)
		{
			return new(
				TNum.One / (aspectRatio * TNum.Tan(fieldOfView / TNum.Two)), TNum.Zero, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.One / (TNum.Tan(fieldOfView / TNum.Two)), TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.Zero, (-nearPlane - farPlane) / (nearPlane - farPlane), (TNum.Two * farPlane * nearPlane) / (nearPlane - farPlane),
				TNum.Zero, TNum.Zero, TNum.One, TNum.Zero
			);
		}
	}

	public struct Matrix4x4_Ops_Generic<TNum> : IMatrix4x4Operations<Matrix4x4_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
	{
		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Add(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> left, ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 + right.m11, left.m12 + right.m12, left.m13 + right.m13, left.m14 + right.m14,
				left.m21 + right.m21, left.m22 + right.m22, left.m23 + right.m23, left.m24 + right.m24,
				left.m31 + right.m31, left.m32 + right.m32, left.m33 + right.m33, left.m34 + right.m34,
				left.m41 + right.m41, left.m42 + right.m42, left.m43 + right.m43, left.m44 + right.m44
			);
		}

		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Subtract(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> left, ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 - right.m11, left.m12 - right.m12, left.m13 - right.m13, left.m14 - right.m14,
				left.m21 - right.m21, left.m22 - right.m22, left.m23 - right.m23, left.m24 - right.m24,
				left.m31 - right.m31, left.m32 - right.m32, left.m33 - right.m33, left.m34 - right.m34,
				left.m41 - right.m41, left.m42 - right.m42, left.m43 - right.m43, left.m44 - right.m44
			);
		}

		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Negate(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> value)
		{
			return new(
				-value.m11, -value.m12, -value.m13, -value.m14,
				-value.m21, -value.m22, -value.m23, -value.m24,
				-value.m31, -value.m32, -value.m33, -value.m34,
				-value.m41, -value.m42, -value.m43, -value.m44
			);
		}

		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Multiply(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> left, ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 * right.m11 + left.m12 * right.m21 + left.m13 * right.m31 + left.m14 * right.m41,
				left.m11 * right.m12 + left.m12 * right.m22 + left.m13 * right.m32 + left.m14 * right.m42,
				left.m11 * right.m13 + left.m12 * right.m23 + left.m13 * right.m33 + left.m14 * right.m43,
				left.m11 * right.m14 + left.m12 * right.m24 + left.m13 * right.m34 + left.m14 * right.m44,

				left.m21 * right.m11 + left.m22 * right.m21 + left.m23 * right.m31 + left.m24 * right.m41,
				left.m21 * right.m12 + left.m22 * right.m22 + left.m23 * right.m32 + left.m24 * right.m42,
				left.m21 * right.m13 + left.m22 * right.m23 + left.m23 * right.m33 + left.m24 * right.m43,
				left.m21 * right.m14 + left.m22 * right.m24 + left.m23 * right.m34 + left.m24 * right.m44,

				left.m31 * right.m11 + left.m32 * right.m21 + left.m33 * right.m31 + left.m34 * right.m41,
				left.m31 * right.m12 + left.m32 * right.m22 + left.m33 * right.m32 + left.m34 * right.m42,
				left.m31 * right.m13 + left.m32 * right.m23 + left.m33 * right.m33 + left.m34 * right.m43,
				left.m31 * right.m14 + left.m32 * right.m24 + left.m33 * right.m34 + left.m34 * right.m44,

				left.m41 * right.m11 + left.m42 * right.m21 + left.m43 * right.m31 + left.m44 * right.m41,
				left.m41 * right.m12 + left.m42 * right.m22 + left.m43 * right.m32 + left.m44 * right.m42,
				left.m41 * right.m13 + left.m42 * right.m23 + left.m43 * right.m33 + left.m44 * right.m43,
				left.m41 * right.m14 + left.m42 * right.m24 + left.m43 * right.m34 + left.m44 * right.m44
			);
		}

		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Multiply(TNum left, ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> right)
		{
			return new(
				left * right.m11, left * right.m12, left * right.m13, left * right.m14,
				left * right.m21, left * right.m22, left * right.m23, left * right.m24,
				left * right.m31, left * right.m32, left * right.m33, left * right.m34,
				left * right.m41, left * right.m42, left * right.m43, left * right.m44
			);
		}

		public static Vector4<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> left, ref readonly Vector4<TNum, TVecOps> right) where TVecOps : IVector4Operations<TVecOps, TNum>
		{
			return new(
				left.m11 * right.x + left.m12 * right.y + left.m13 * right.z + left.m14 * right.w,
				left.m21 * right.x + left.m22 * right.y + left.m23 * right.z + left.m24 * right.w,
				left.m31 * right.x + left.m32 * right.y + left.m33 * right.z + left.m34 * right.w,
				left.m41 * right.x + left.m42 * right.y + left.m43 * right.z + left.m44 * right.w
			);
		}

		public static Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> Transpose(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> value)
		{
			return new(
				value.m11, value.m21, value.m31, value.m41,
				value.m12, value.m22, value.m32, value.m42,
				value.m13, value.m23, value.m33, value.m43,
				value.m14, value.m24, value.m34, value.m44
			);
		}

		public static TNum Determinant(ref readonly Matrix4x4<TNum, Matrix4x4_Ops_Generic<TNum>> value)
		{
			return value.m11 * (value.m22 * (value.m33 * value.m44 - value.m43 * value.m34) - value.m23 * (value.m32 * value.m44 - value.m42 * value.m34) + value.m24 * (value.m32 * value.m43 - value.m42 * value.m33)) -
					value.m12 * (value.m21 * (value.m33 * value.m44 - value.m43 * value.m34) - value.m23 * (value.m31 * value.m44 - value.m41 * value.m34) + value.m24 * (value.m31 * value.m43 - value.m41 * value.m33)) +
					value.m13 * (value.m21 * (value.m32 * value.m44 - value.m42 * value.m34) - value.m22 * (value.m31 * value.m44 - value.m41 * value.m34) + value.m24 * (value.m31 * value.m42 - value.m41 * value.m32)) -
					value.m14 * (value.m21 * (value.m32 * value.m43 - value.m42 * value.m33) - value.m22 * (value.m31 * value.m43 - value.m41 * value.m33) + value.m23 * (value.m31 * value.m42 - value.m41 * value.m32));
		}
	}
}
