using System.Runtime.CompilerServices;

namespace MathLib
{
	public static class PixelConverions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rgb<TNum, TOps> ToRGB<TNum, TOps, TOtherOps>(ref readonly Rgba<TNum, TOtherOps> rgba)
			where TNum : unmanaged, INumericType<TNum>
			where TOps : IRgbOperations<TOps, TNum>
			where TOtherOps : IRgbaOperations<TOtherOps, TNum>
		{
			return new(rgba.r, rgba.g, rgba.b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rgb<TNum, TOps> ToRGB<TNum, TOps, TOtherOps>(ref readonly YCbCr<TNum, TOtherOps> ycbcr)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IRgbOperations<TOps, TNum>
			where TOtherOps : IYCbCrOperations<TOtherOps, TNum>
		{
			// TODO: pixel should be able to be treated as vector
			Vector3<TNum, Vector3_Ops_Generic<TNum>> vec = new(ycbcr.y, ycbcr.cb, ycbcr.cr);
			Vector3<TNum, Vector3_Ops_Generic<TNum>> constants = new(TNum.FromInteger(16), TNum.FromInteger(128), TNum.FromInteger(128));

			Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> mat = new(
				TNum.FromFloat(0.257f), TNum.FromFloat(0.504f), TNum.FromFloat(0.098f),
				TNum.FromFloat(0.148f), TNum.FromFloat(-0.291f), TNum.FromFloat(0.439f),
				TNum.FromFloat(0.439f), TNum.FromFloat(-0.368f), TNum.FromFloat(-0.071f)
			);

			var result = MathHelpers.Multiply(in mat, (vec - constants));

			return new(result.x, result.y, result.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rgba<TNum, TOps> ToRGBA<TNum, TOps, TOtherOps>(ref readonly Rgb<TNum, TOtherOps> rgb, TNum alpha)
			where TNum : unmanaged, INumericType<TNum>
			where TOps : IRgbaOperations<TOps, TNum>
			where TOtherOps : IRgbOperations<TOtherOps, TNum>
		{
			return new(rgb.r, rgb.g, rgb.b, alpha);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static YCbCr<TNum, TOps> ToYCbCr<TNum, TOps, TOtherOps>(ref readonly Rgb<TNum, TOtherOps> rgb)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IYCbCrOperations<TOps, TNum>
			where TOtherOps : IRgbOperations<TOtherOps, TNum>
		{
			// TODO: pixel should be able to be treated as vector
			Vector3<TNum, Vector3_Ops_Generic<TNum>> vec = new(rgb.r, rgb.g, rgb.b);
			Vector3<TNum, Vector3_Ops_Generic<TNum>> constants = new(TNum.FromInteger(16), TNum.FromInteger(128), TNum.FromInteger(128));

			Matrix3x3<TNum, Matrix3x3_Ops_Generic<TNum>> mat = new(
				TNum.FromFloat(1.164f), TNum.FromFloat(0.000f), TNum.FromFloat(1.596f),
				TNum.FromFloat(1.164f), TNum.FromFloat(-0.392f), TNum.FromFloat(-0.813f),
				TNum.FromFloat(1.164f), TNum.FromFloat(2.017f), TNum.FromFloat(0.000f)
			);

			var result = constants + MathHelpers.Multiply(in mat, in vec);

			return new(result.x, result.y, result.z);
		}
	}
}
