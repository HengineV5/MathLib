
namespace MathLib
{
	public interface IMatrix3x3Operations<TSelf, TNum>
		where TSelf : IMatrix3x3Operations<TSelf, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		static abstract Matrix3x3<TNum, TSelf> Add(ref readonly Matrix3x3<TNum, TSelf> left, ref readonly Matrix3x3<TNum, TSelf> right);

		static abstract Matrix3x3<TNum, TSelf> Subtract(ref readonly Matrix3x3<TNum, TSelf> left, ref readonly Matrix3x3<TNum, TSelf> right);

		static abstract Matrix3x3<TNum, TSelf> Negate(ref readonly Matrix3x3<TNum, TSelf> value);

		static abstract Matrix3x3<TNum, TSelf> Multiply(TNum left, ref readonly Matrix3x3<TNum, TSelf> right);

		static abstract Matrix3x3<TNum, TSelf> Multiply(ref readonly Matrix3x3<TNum, TSelf> left, ref readonly Matrix3x3<TNum, TSelf> right);

		static abstract Vector3<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix3x3<TNum, TSelf> left, ref readonly Vector3<TNum, TVecOps> right)
			where TVecOps : IVector3Operations<TVecOps, TNum>;

		static abstract Matrix3x3<TNum, TSelf> Transpose(ref readonly Matrix3x3<TNum, TSelf> value);

		static abstract TNum Determinant(ref readonly Matrix3x3<TNum, TSelf> value);
	}

	public struct Matrix3x3<TNum, TOps> : IMatrix3x3Operations<TOps, TNum>
		where TNum : unmanaged, IScalar<TNum>
		where TOps : IMatrix3x3Operations<TOps, TNum>
	{
		public static Matrix3x3<TNum, TOps> Identity => new(
				TNum.One, TNum.Zero, TNum.Zero,
				TNum.Zero, TNum.One, TNum.Zero,
				TNum.Zero, TNum.Zero, TNum.One
			);

		public TNum m11;
		public TNum m12;
		public TNum m13;
		public TNum m21;
		public TNum m22;
		public TNum m23;
		public TNum m31;
		public TNum m32;
		public TNum m33;

		public Matrix3x3(TNum m11, TNum m12, TNum m13, TNum m21, TNum m22, TNum m23, TNum m31, TNum m32, TNum m33)
		{
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
		}

		public static Matrix3x3<TNum, TOps> operator +(Matrix3x3<TNum, TOps> left, Matrix3x3<TNum, TOps> right) => TOps.Add(in left, in right);

		public static Matrix3x3<TNum, TOps> operator -(Matrix3x3<TNum, TOps> left, Matrix3x3<TNum, TOps> right) => TOps.Subtract(in left, in right);

		public static Matrix3x3<TNum, TOps> operator -(Matrix3x3<TNum, TOps> matrix) => TOps.Negate(in matrix);

		public static Matrix3x3<TNum, TOps> operator *(Matrix3x3<TNum, TOps> left, Matrix3x3<TNum, TOps> right) => TOps.Multiply(in left, in right);

		public static Matrix3x3<TNum, TOps> operator *(TNum left, Matrix3x3<TNum, TOps> right) => TOps.Multiply(left, in right);

		public override readonly string ToString()
			=> $"{{ {{M11:{m11} M12:{m12} M13:{m13}}} {{M21:{m21} M22:{m22} M23:{m23}}} {{M31:{m31} M32:{m32} M33:{m33}}} }}";

		public static Vector3<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Vector3<TNum, TVecOps> right) where TVecOps : IVector3Operations<TVecOps, TNum>
			=> TOps.Multiply(in left, in right);

		public static Matrix3x3<TNum, TOps> Multiply(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			=> TOps.Multiply(in left, in right);

		public static Matrix3x3<TNum, TOps> Add(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			=> TOps.Add(in left, in right);

		public static Matrix3x3<TNum, TOps> Subtract(ref readonly Matrix3x3<TNum, TOps> left, ref readonly Matrix3x3<TNum, TOps> right)
			=> TOps.Subtract(in left, in right);

		public static Matrix3x3<TNum, TOps> Negate(ref readonly Matrix3x3<TNum, TOps> value)
			=> TOps.Negate(in value);

		public static Matrix3x3<TNum, TOps> Multiply(TNum left, ref readonly Matrix3x3<TNum, TOps> right)
			=> TOps.Multiply(left, in right);

		public static Matrix3x3<TNum, TOps> Transpose(ref readonly Matrix3x3<TNum, TOps> value)
			=> TOps.Transpose(in value);

		public static TNum Determinant(ref readonly Matrix3x3<TNum, TOps> value)
			=> TOps.Determinant(in value);
	}

	public struct Matrix3x3_Ops_Generic<TNum> : IMatrix3x3Operations<Matrix3x3_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Add(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> left, ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 + right.m11, left.m12 + right.m12, left.m13 + right.m13,
				left.m21 + right.m21, left.m22 + right.m22, left.m23 + right.m23,
				left.m31 + right.m31, left.m32 + right.m32, left.m33 + right.m33
			);
		}

		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Subtract(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> left, ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 - right.m11, left.m12 - right.m12, left.m13 - right.m13,
				left.m21 - right.m21, left.m22 - right.m22, left.m23 - right.m23,
				left.m31 - right.m31, left.m32 - right.m32, left.m33 - right.m33
			);
		}

		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Negate(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> value)
		{
			return new(
				-value.m11, -value.m12, -value.m13,
				-value.m21, -value.m22, -value.m23,
				-value.m31, -value.m32, -value.m33
			);
		}

		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Multiply(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> left, ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> right)
		{
			return new(
				left.m11 * right.m11 + left.m12 * right.m21 + left.m13 * right.m31,
				left.m11 * right.m12 + left.m12 * right.m22 + left.m13 * right.m32,
				left.m11 * right.m13 + left.m12 * right.m23 + left.m13 * right.m33,

				left.m21 * right.m11 + left.m22 * right.m21 + left.m23 * right.m31,
				left.m21 * right.m12 + left.m22 * right.m22 + left.m23 * right.m32,
				left.m21 * right.m13 + left.m22 * right.m23 + left.m23 * right.m33,

				left.m31 * right.m11 + left.m32 * right.m21 + left.m33 * right.m31,
				left.m31 * right.m12 + left.m32 * right.m22 + left.m33 * right.m32,
				left.m31 * right.m13 + left.m32 * right.m23 + left.m33 * right.m33
			);
		}

		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Multiply(TNum left, ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> right)
		{
			return new(
				left * right.m11, left * right.m12, left * right.m13,
				left * right.m21, left * right.m22, left * right.m23,
				left * right.m31, left * right.m32, left * right.m33
			);
		}

		public static Vector3<TNum, TVecOps> Multiply<TVecOps>(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> left, ref readonly Vector3<TNum, TVecOps> right) where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			return new(
				left.m11 * right.x + left.m12 * right.y + left.m13 * right.z,
				left.m21 * right.x + left.m22 * right.y + left.m23 * right.z,
				left.m31 * right.x + left.m32 * right.y + left.m33 * right.z
			);
		}

		public static Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> Transpose(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> value)
		{
			return new(
				value.m11, value.m21, value.m31,
				value.m12, value.m22, value.m32,
				value.m13, value.m23, value.m33
			);
		}

		public static TNum Determinant(ref readonly Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> value)
		{
			return value.m11 * (value.m22 * value.m33 - value.m23 * value.m32) - value.m12 * (value.m21 * value.m33 - value.m23 * value.m31) + value.m13 * (value.m21 * value.m32 - value.m22 * value.m31);
		}
	}
}
