using MathLib.Vector.Extensions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MathLib.Test
{
	public class Vector2ExtensionTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Intersection()
		{
			{
				var a1 = new Vector2f(0, 1);
				var a2 = new Vector2f(2, 1);

				var b1 = new Vector2f(1, 0);
				var b2 = new Vector2f(1, 2);

				var intersection1 = MathHelpers.Intersect(in a1, in a2, in b1, in b2);
				Assert.That(intersection1, Is.True);

				var intersection2 = MathHelpers.Intersect(in b1, in b2, in a1, in a2);
				Assert.That(intersection2, Is.True);
			}

			{
				var a1 = new Vector2f(0, 1);
				var a2 = new Vector2f(2, 1);

				var b1 = new Vector2f(0, 0);
				var b2 = new Vector2f(2, 2);

				var intersection = MathHelpers.Intersect(in a1, in a2, in b1, in b2);
				Assert.That(intersection, Is.True);
			}

			{
				var a1 = new Vector2f(0, 0);
				var a2 = new Vector2f(2, 0);

				var b1 = new Vector2f(0, 1);
				var b2 = new Vector2f(2, 2);

				var intersection = MathHelpers.Intersect(in a1, in a2, in b1, in b2);
				Assert.That(intersection, Is.False);
			}

			{
				var a1 = new Vector2f(0, 1);
				var a2 = new Vector2f(2, 1);

				var b1 = new Vector2f(0, 1);
				var b2 = new Vector2f(2, 2);

				var intersection = MathHelpers.Intersect(in a1, in a2, in b1, in b2);
				Assert.That(intersection, Is.False);
			}
		}

		[Test]
		public void Angle()
		{
			{
				var a1 = new Vector2f(0, 1);
				var a2 = new Vector2f(2, 1);
				var a3 = new Vector2f(2, 2);

				var angle = MathHelpers.Angle(in a1, in a2, in a3);
				Assert.That(Float32.IsClose(angle, (3 * Float32.PI) / 2f), Is.True);
			}

			{
				var a1 = new Vector2f(0, 1);
				var a2 = new Vector2f(2, 1);
				var a3 = new Vector2f(4, 1);

				var angle = MathHelpers.Angle(in a1, in a2, in a3);
				Assert.That(Float32.IsClose(angle, Float32.PI), Is.True);
			}
		}
	}
}
