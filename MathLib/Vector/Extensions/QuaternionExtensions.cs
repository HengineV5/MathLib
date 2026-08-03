using System.Runtime.CompilerServices;

namespace MathLib.Vector.Extensions
{
	// For methods that probably dont need to be optimized
	public static class QuaternionExtensions
	{
		extension<TNum, TOps>(Quaternion<TNum, TOps>)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IQuaternionOperations<TOps, TNum>
		{
			/// <summary>
			/// Create the quaternion that rotates vector v1 onto vector v2.
			/// https://stackoverflow.com/questions/1171849/finding-quaternion-representing-the-rotation-from-one-vector-to-another
			/// </summary>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static Quaternion<TNum, TOps> CreateRotation<TVecOps>(ref readonly Vector3<TNum, TVecOps> v1, ref readonly Vector3<TNum, TVecOps> v2)
				where TVecOps : IVector3Operations<TVecOps, TNum>
			{
				TNum k_cos_theta = Vector3<TNum, TVecOps>.Dot(in v1, in v2);
				TNum k = TNum.Sqrt(Vector3<TNum, TVecOps>.LengthSquared(in v1) * Vector3<TNum, TVecOps>.LengthSquared(in v2));

				if (k_cos_theta / k == -TNum.One)
				{
					var o = MathHelpers.Orthogonal(in v1);
					return new(o.x, o.y, o.z, TNum.Zero);
				}

				var c = Vector3<TNum, TVecOps>.Cross(in v1, in v2);
				return Quaternion<TNum, TOps>.Normalize(new(c.x, c.y, c.z, k_cos_theta + k));
			}
		}
	}
}
