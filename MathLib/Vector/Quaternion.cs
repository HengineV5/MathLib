using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace MathLib
{
	public interface IQuaternionOperations<TSelf, TNum>
		where TSelf : IQuaternionOperations<TSelf, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		static abstract TNum LengthSquared(ref readonly Quaternion<TNum, TSelf> q);

		static abstract TNum Length(ref readonly Quaternion<TNum, TSelf> q);

		static abstract Quaternion<TNum, TSelf> Normalize(ref readonly Quaternion<TNum, TSelf> q);
	}

	public struct Quaternion<TNum, TOps> : IQuaternionOperations<TOps, TNum>
		where TNum : unmanaged, IScalar<TNum>
		where TOps : IQuaternionOperations<TOps, TNum>
	{
		public static Quaternion<TNum, TOps> Identity => new(TNum.One, TNum.Zero, TNum.Zero, TNum.Zero);

		public TNum x;
		public TNum y;
		public TNum z;
		public TNum w;

		public Quaternion(TNum value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
			this.w = value;
		}

		public Quaternion(TNum x, TNum y, TNum z, TNum w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public override readonly string ToString() => $"{{X: {x} Y: {y} Z: {z} W: {w}}}";

		public static Quaternion<TNum, TOps> FromAxisAngle<TVecOps>(ref readonly Vector3<TNum, TVecOps> axis, TNum angle)
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			TNum halfAngle = angle / TNum.Two;
			TNum s = TNum.Sin(halfAngle);

			return new(axis.x * s, axis.y * s, axis.z * s, TNum.Cos(halfAngle));
		}

		// https://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/
		public static Quaternion<TNum, TOps> FromRotationMatrix<TMatOps>(ref readonly Matrix4x4<TNum, TMatOps> matrix)
			where TMatOps : IMatrix4x4Operations<TMatOps, TNum>
		{
			var w = TNum.Sqrt(TNum.One + matrix.m11 + matrix.m22 + matrix.m33);
			var w4 = TNum.Two * w;

			return new((matrix.m32 - matrix.m23) / w4, (matrix.m13 - matrix.m31) / w4, (matrix.m21 - matrix.m12) / w4, w / TNum.Two);
		}

		// https://stackoverflow.com/questions/12435671/quaternion-lookat-function
		public static Quaternion<TNum, TOps> CreateLookAt<TVecOps>(ref readonly Vector3<TNum, TVecOps> dir)
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			TNum dot = TVecOps.Dot(Vector3<TNum, TVecOps>.UnitX, in dir);

			if (TNum.IsClose(dot + TNum.One, TNum.Zero))
			{
				return new(TNum.PI, Vector3<TNum, TVecOps>.UnitY.x, Vector3<TNum, TVecOps>.UnitY.y, Vector3<TNum, TVecOps>.UnitY.z);
			}
			else if (TNum.IsClose(dot - TNum.One, TNum.Zero))
			{
				return Identity;
			}

			var rotAxis = TVecOps.Normalize(TVecOps.Cross(Vector3<TNum, TVecOps>.UnitX, in dir));
			return FromAxisAngle(in rotAxis, TNum.ACos(dot));
		}

		public static TNum LengthSquared(ref readonly Quaternion<TNum, TOps> q)
			=> TOps.LengthSquared(in q);

		public static TNum Length(ref readonly Quaternion<TNum, TOps> q)
			=> TOps.Length(in q);

		public static Quaternion<TNum, TOps> Normalize(ref readonly Quaternion<TNum, TOps> q)
			=> TOps.Normalize(in q);
	}

	public struct Quaternion_Ops_Generic<TNum> : IQuaternionOperations<Quaternion_Ops_Generic<TNum>, TNum>
		where TNum : unmanaged, IScalar<TNum>
	{
		public static TNum Length(ref readonly Quaternion<TNum, Quaternion_Ops_Generic<TNum>> q)
		{
			return TNum.Sqrt(LengthSquared(in q));
		}

		public static TNum LengthSquared(ref readonly Quaternion<TNum, Quaternion_Ops_Generic<TNum>> q)
		{
			return q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w;
		}

		public static Quaternion<TNum, Quaternion_Ops_Generic<TNum>> Normalize(ref readonly Quaternion<TNum, Quaternion_Ops_Generic<TNum>> q)
		{
			var magnitude = Length(in q);
			return new(q.x / magnitude, q.y / magnitude, q.z / magnitude, q.w / magnitude);
		}
	}
}
