using MathLib.Vector.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MathLib
{
	public static partial class MathHelpers
	{
		/// <summary>
		/// Rotate vector v2 onto vector v2
		/// https://stackoverflow.com/questions/1171849/finding-quaternion-representing-the-rotation-from-one-vector-to-another
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion<TNum, TOps> RotateTo<TNum, TOps, TVecOps>(ref readonly Vector3<TNum, TVecOps> v1, ref readonly Vector3<TNum, TVecOps> v2)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IQuaternionOperations<TOps, TNum>
			where TVecOps : IVector3Operations<TVecOps, TNum>
		{
			TNum k_cos_theta = Vector3<TNum, TVecOps>.Dot(in v1, in v2);
			TNum k = TNum.Sqrt(Vector3<TNum, TVecOps>.LengthSquared(in v1) * Vector3<TNum, TVecOps>.LengthSquared(in v2));

			if (k_cos_theta / k == -TNum.One)
			{
				var o = Orthogonal(in v1);
				return new(o.x, o.y, o.z, TNum.Zero);
			}

			var c = Vector3<TNum, TVecOps>.Cross(in v1, in v2);
			return Quaternion<TNum, TOps>.Normalize(new(c.x, c.y, c.z, k_cos_theta + k));
		}
	}
}
