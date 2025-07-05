using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MathLib.Vector.Extensions
{
	// For methos that probably dont need to be optimized
	public static class VectorExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3<TNum, TOps> Orthogonal<TNum, TOps>(this ref readonly Vector3<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector3Operations<TOps, TNum>
		{
			TNum x = TNum.Abs(vec.x);
			TNum y = TNum.Abs(vec.y);
			TNum z = TNum.Abs(vec.z);

			Vector3<TNum, TOps> other = x < y ? (x < z ? Vector3<TNum, TOps>.UnitX : Vector3<TNum, TOps>.UnitZ) : (y < z ? Vector3<TNum, TOps>.UnitY : Vector3<TNum, TOps>.UnitZ);
			return TOps.Cross(in vec, in other);
		}
	}
}
