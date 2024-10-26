using System.Numerics;

namespace MathLib.Test
{
	public class GenericVector2Tests
	{
		Vector2 v1 = new(1, 2);
		Vector2 v2 = new(4, 5);

		Vector2f v3 = new(1, 2);
		Vector2f v4 = new(4, 5);

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Addition()
		{
			Vector2 r1 = Vector2.Add(v1, v2);
			Vector2f r2 = MathHelpers.Add(in v3, in v4);

			AssertVec2(r1, r2, "+");
		}

		[Test]
		public void Subtraction()
		{
			Vector2 r1 = Vector2.Subtract(v1, v2);
			Vector2f r2 = MathHelpers.Subtract(in v3, in v4);

			AssertVec2(r1, r2, "-");
		}

		[Test]
		public void Multiplication()
		{
			Vector2 r1 = Vector2.Multiply(v1, v2);
			Vector2f r2 = MathHelpers.Multiply(in v3, in v4);

			AssertVec2(r1, r2, "*");

			r1 = Vector2.Multiply(v1, 4);
			r2 = MathHelpers.Multiply(in v3, 4);

			AssertVec2(r1, r2, "*");
		}

		[Test]
		public void Division()
		{
			Vector2 r1 = Vector2.Divide(v1, 4);
			Vector2f r2 = MathHelpers.Divide(in v3, 4);

			AssertVec2(r1, r2, "/");
		}

		[Test]
		public void Negate()
		{
			Vector2 r1 = Vector2.Negate(v1);
			Vector2f r2 = MathHelpers.Negate(in v3);

			AssertNegateVec3(r1, r2);
		}

		[Test]
		public void Dot()
		{
			float r1 = Vector2.Dot(v1, v2);
			Float32 r2 = MathHelpers.Dot(in v3, in v4);

			Assert.That(r1 == r2, Is.True, $"{v1} dot {v2} should be {r1} but is {r2}");
		}

		[Test]
		public void LengthSquared()
		{
			float r1 = v1.LengthSquared();
			Float32 r2 = MathHelpers.LengthSquared(in v3);

			Assert.That(r1 == r2, Is.True, $"|{v1}|^2 should be {r1} but is {r2}");
		}

		[Test]
		public void Length()
		{
			float r1 = v1.Length();
			Float32 r2 = MathHelpers.Length(in v3);

			Assert.That(r1 == r2, Is.True, $"|{v1}| should be {r1} but is {r2}");
		}

		void AssertVec2(Vector2 r1, Vector2f r2, string op)
		{
			Assert.That(r1.X == r2.x, Is.True, $"{v1.X} {op} {v2.X} should be {r1.X} but is {r2.x}");
			Assert.That(r1.Y == r2.y, Is.True, $"{v1.Y} {op} {v2.Y} should be {r1.Y} but is {r2.y}");
		}

		void AssertNegateVec3(Vector2 r1, Vector2f r2)
		{
			Assert.That(r1.X == r2.x, Is.True, $"-{v1.X} should be {r1.X} but is {r2.x}");
			Assert.That(r1.Y == r2.y, Is.True, $"-{v1.Y} should be {r1.Y} but is {r2.y}");
		}
	}
}
