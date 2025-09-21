using System.Runtime.CompilerServices;

namespace MathLib
{
	public static partial class MathHelpers
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Add<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Add(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Subtract<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Subtract(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Negate<TNum, TOps>(ref readonly Vector2<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Negate(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Multiply(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Multiply<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Multiply(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Divide<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, TNum right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Divide(in left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Divide<TNum, TOps>(TNum left, ref readonly Vector2<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Divide(left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Dot<TNum, TOps>(ref readonly Vector2<TNum, TOps> left, ref readonly Vector2<TNum, TOps> right)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Dot(in left, in right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum LengthSquared<TNum, TOps>(ref readonly Vector2<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.LengthSquared(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Length<TNum, TOps>(ref readonly Vector2<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Length(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Normalize<TNum, TOps>(ref readonly Vector2<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Normalize(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Abs<TNum, TOps>(ref readonly Vector2<TNum, TOps> vec)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Abs(in vec);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2<TNum, TOps> Lerp<TNum, TOps>(ref readonly Vector2<TNum, TOps> start, ref readonly Vector2<TNum, TOps> stop, TNum fraction)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return Vector2<TNum, TOps>.Lerp(in start, in stop, fraction);
		}

		/// <summary>
		/// Get the shortest distance from point p to the line defined by points a and b.
		/// </summary>
		/// <typeparam name="TNum"></typeparam>
		/// <typeparam name="TOps"></typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum DistanceToLine<TNum, TOps>(ref readonly Vector2<TNum, TOps> a, ref readonly Vector2<TNum, TOps> b, ref readonly Vector2<TNum, TOps> p)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			var ab = b - a;
			var pa = a - p;

			var cross = TNum.Abs(ab.x * pa.y - ab.y * pa.x);
			var len = Vector2<TNum, TOps>.Length(in ab);

			if (len == TNum.Zero)
				return Vector2<TNum, TOps>.Length(in pa); // a and b are the same point

            return cross / len;
        }

		/// <summary>
		/// Check if two vectors are close to each other within a certain margin.
		/// </summary>
		/// <typeparam name="TNum"></typeparam>
		/// <typeparam name="TOps"></typeparam>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="margin"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsClose<TNum, TOps>(ref readonly Vector2<TNum, TOps> p1, ref readonly Vector2<TNum, TOps> p2, float margin)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			return TNum.Abs(p1.x - p2.x) < TNum.FromFloat(margin) && TNum.Abs(p1.y - p2.y) < TNum.FromFloat(margin);
		}

		/// <summary>
		/// Check if the points p1, p2, p3 are in clockwise order.
		/// </summary>
		/// <typeparam name="TNum"></typeparam>
		/// <typeparam name="TOps"></typeparam>
		/// <typeparam name="TVec3Ops"></typeparam>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="p3"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsClockwise<TNum, TOps, TVec3Ops>(ref readonly Vector2<TNum, TOps> p1, ref readonly Vector2<TNum, TOps> p2, ref readonly Vector2<TNum, TOps> p3)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
			where TVec3Ops : IVector3Operations<TVec3Ops, TNum>
		{
			var ab = p2 - p1;
			var bc = p2 - p3;

			var cross = Vector3<TNum, TVec3Ops>.Cross(Vector3<TNum, TVec3Ops>.FromVector2(in ab), Vector3<TNum, TVec3Ops>.FromVector2(in bc));
			return TNum.Sign(cross.z) == -1;
		}

        /// <summary>
        /// Check if two line segments intersect.
        /// </summary>
        /// <typeparam name="TNum"></typeparam>
        /// <typeparam name="TOps"></typeparam>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Intersect<TNum, TOps>(ref readonly Vector2<TNum, TOps> p1, ref readonly Vector2<TNum, TOps> p2, ref readonly Vector2<TNum, TOps> q1, ref readonly Vector2<TNum, TOps> q2)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			//https://bryceboe.com/2006/10/23/line-segment-intersection-algorithm/
			static bool ccv(ref readonly Vector2<TNum, TOps> a, ref readonly Vector2<TNum, TOps> b, ref readonly Vector2<TNum, TOps> c)
				=> (c.y - a.y) * (b.x - a.x) > (b.y - a.y) * (c.x - a.x);

			return ccv(in p1, in q1, in q2) != ccv(in p2, in q1, in q2) && ccv(in p1, in p2, in q1) != ccv(in p1, in p2, in q2);
		}

        /// <summary>
        /// Calculate clockwise angle between points a, b, c with center point b.
        /// </summary>
        /// <typeparam name="TNum"></typeparam>
        /// <typeparam name="TOps"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TNum Angle<TNum, TOps>(ref readonly Vector2<TNum, TOps> a, ref readonly Vector2<TNum, TOps> b, ref readonly Vector2<TNum, TOps> c)
			where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
			where TOps : IVector2Operations<TOps, TNum>
		{
			var ba = a - b;
			var bc = b - c;

			TNum dot = ba.x * bc.x + ba.y * bc.y;
			TNum det = ba.x * bc.y - ba.y * bc.x;
			
			return TNum.Atan2(det, dot) + TNum.PI;
		}

        /// <summary>
        /// Check if point q1 is inside the triangle defined by points p1, p2, p3.
        /// </summary>
        /// <typeparam name="TNum"></typeparam>
        /// <typeparam name="TOps"></typeparam>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="q1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInsideTriangle<TNum, TOps>(ref readonly Vector2<TNum, TOps> p1, ref readonly Vector2<TNum, TOps> p2, ref readonly Vector2<TNum, TOps> p3, ref readonly Vector2<TNum, TOps> q1)
            where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
            where TOps : IVector2Operations<TOps, TNum>
        {
            // https://stackoverflow.com/questions/2049582/how-to-determine-if-a-point-is-in-a-2d-triangle
			var d1 = (q1.x - p2.x) * (p1.y - p2.y) - (p1.x - p2.x) * (q1.y - p2.y);
			var d2 = (q1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (q1.y - p3.y);
			var d3 = (q1.x - p1.x) * (p3.y - p1.y) - (p3.x - p1.x) * (q1.y - p1.y);

			bool has_neg = (TNum.Sign(d1) == -1) || (TNum.Sign(d2) == -1) || (TNum.Sign(d3) == -1);
			bool has_pos = (TNum.Sign(d1) == 1) || (TNum.Sign(d2) == 1) || (TNum.Sign(d3) == 1);

			return !(has_neg && has_pos);
        }
    }
}
