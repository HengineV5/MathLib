using System.Numerics;

namespace MathLib.Test
{
	public class GenericVector4Tests
	{
		Vector4 v1 = new(1, 2, 3, 4);
		Vector4 v2 = new(5, 6, 7, 8);

		Vector4f v3 = new(1, 2, 3, 4);
		Vector4f v4 = new(5, 6, 7, 8);

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Addition()
		{
			Vector4 r1 = Vector4.Add(v1, v2);
			Vector4f r2 = MathHelpers.Add(in v3, in v4);

			AssertVec3(r1, r2, "+");
		}

		[Test]
		public void Subtraction()
		{
			Vector4 r1 = Vector4.Subtract(v1, v2);
			Vector4f r2 = MathHelpers.Subtract(in v3, in v4);

			AssertVec3(r1, r2, "-");
		}

		[Test]
		public void Multiplication()
		{
			Vector4 r1 = Vector4.Multiply(v1, v2);
			Vector4f r2 = MathHelpers.Multiply(in v3, in v4);

			AssertVec3(r1, r2, "*");

			r1 = Vector4.Multiply(v1, 4);
			r2 = Vector4f.Multiply(in v3, 4);

			AssertVec3(r1, r2, "*");
		}

		[Test]
		public void Division()
		{
			Vector4 r1 = Vector4.Divide(v1, 4);
			Vector4f r2 = MathHelpers.Divide(in v3, 4);

			AssertVec3(r1, r2, "/");
		}

		[Test]
		public void Negate()
		{
			Vector4 r1 = Vector4.Negate(v1);
			Vector4f r2 = MathHelpers.Negate(in v3);

			AssertNegateVec3(r1, r2);
		}

		[Test]
		public void Dot()
		{
			float r1 = Vector4.Dot(v1, v2);
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

		void AssertVec3(Vector4 r1, Vector4f r2, string op)
		{
			Assert.That(r1.X == r2.x, Is.True, $"{v1.X} {op} {v2.X} should be {r1.X} but is {r2.x}");
			Assert.That(r1.Y == r2.y, Is.True, $"{v1.Y} {op} {v2.Y} should be {r1.Y} but is {r2.y}");
			Assert.That(r1.Z == r2.z, Is.True, $"{v1.Z} {op} {v2.Z} should be {r1.Z} but is {r2.z}");
			Assert.That(r1.W == r2.w, Is.True, $"{v1.W} {op} {v2.W} should be {r1.W} but is {r2.w}");
		}

		void AssertNegateVec3(Vector4 r1, Vector4f r2)
		{
			Assert.That(r1.X == r2.x, Is.True, $"-{v1.X} should be {r1.X} but is {r2.x}");
			Assert.That(r1.Y == r2.y, Is.True, $"-{v1.Y} should be {r1.Y} but is {r2.y}");
			Assert.That(r1.Z == r2.z, Is.True, $"-{v1.Z} should be {r1.Z} but is {r2.z}");
			Assert.That(r1.W == r2.w, Is.True, $"-{v1.W} should be {r1.W} but is {r2.w}");
		}
	}
}
