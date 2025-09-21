using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MathLib
{
    public ref struct Triangle<TNum, TOps>
		where TNum : unmanaged, IFloatingNumericType<TNum>, INumericType<TNum>
		where TOps : IVector2Operations<TOps, TNum>
    {
        public ref Vector2<TNum, TOps> a;
		public ref Vector2<TNum, TOps> b;
		public ref Vector2<TNum, TOps> c;

		public Triangle(ref Vector2<TNum, TOps> a, ref Vector2<TNum, TOps> b, ref Vector2<TNum, TOps> c)
		{
			this.a = ref a;
			this.b = ref b;
			this.c = ref c;
        }

		public static Triangle<TNum, TOps> FromPoints(ref Vector2<TNum, TOps> a, ref Vector2<TNum, TOps> b, ref Vector2<TNum, TOps> c) => new(ref a, ref b, ref c);

		public bool IsPointInside(ref readonly Vector2<TNum, TOps> point)
		{
			return MathHelpers.IsInsideTriangle(ref a, ref b, ref c, in point);
        }
    }
}
