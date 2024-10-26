
namespace MathLib.Test
{
	public class GenericMatrix3x3Tests
	{
		Matrix3x3f m1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);
		Matrix3x3f m2 = new(10, 11, 12, 13, 14, 15, 16, 17, 18);

		Vector3f v1 = new(1, 2, 3);

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Addition()
		{
			var r = m1 + m2;
			var e = new Matrix3x3f(11, 13, 15, 17, 19, 21, 23, 25, 27);

			AssertMatrix3x3(r, e);
		}

		[Test]
		public void Subtraction()
		{
			var r = m2 - m1;
			var e = new Matrix3x3f(9, 9, 9, 9, 9, 9, 9, 9, 9);

			AssertMatrix3x3(r, e);
		}

		[Test]
		public void Negate()
		{
			var r = -m1;
			var e = new Matrix3x3f(-1, -2, -3, -4, -5, -6, -7, -8, -9);

			AssertMatrix3x3(r, e);
		}

		[Test]
		public void Multiplication()
		{
			var r = m1 * m2;
			var e = new Matrix3x3f(84, 90, 96, 201, 216, 231, 318, 342, 366);

			AssertMatrix3x3(r, e);

			r = 2 * m1;
			e = new(2, 4, 6, 8, 10, 12, 14, 16, 18); ;

			AssertMatrix3x3(r, e);

			var r2 = MathHelpers.Multiply(in m1, in v1);
			var e2 = new Vector3f(14, 32, 50);

			AssertFloat3(r2, e2);
		}

		[Test]
		public void Transpose()
		{
			var r = MathHelpers.Transpose(in m1);
			var e = new Matrix3x3f(1, 4, 7, 2, 5, 8, 3, 6, 9);

			AssertMatrix3x3(r, e);
		}

		[Test]
		public void Determinant()
		{
			var r = MathHelpers.Determinant(in m1);
			Float32 e = 0;

			AssertFloat(r, e);
		}

		void AssertMatrix3x3(Matrix3x3f result, Matrix3x3f expected)
		{
			Assert.That(result.m11 == expected.m11, Is.True, $"M11 should be {expected.m11} but is {result.m11}");
			Assert.That(result.m12 == expected.m12, Is.True, $"M12 should be {expected.m12} but is {result.m12}");
			Assert.That(result.m13 == expected.m13, Is.True, $"M13 should be {expected.m13} but is {result.m13}");

			Assert.That(result.m21 == expected.m21, Is.True, $"M21 should be {expected.m21} but is {result.m21}");
			Assert.That(result.m22 == expected.m22, Is.True, $"M22 should be {expected.m22} but is {result.m22}");
			Assert.That(result.m23 == expected.m23, Is.True, $"M23 should be {expected.m23} but is {result.m23}");

			Assert.That(result.m31 == expected.m31, Is.True, $"M31 should be {expected.m31} but is {result.m31}");
			Assert.That(result.m32 == expected.m32, Is.True, $"M32 should be {expected.m32} but is {result.m32}");
			Assert.That(result.m33 == expected.m33, Is.True, $"M33 should be {expected.m33} but is {result.m33}");
		}

		void AssertFloat3(Vector3f result, Vector3f expected)
		{
			Assert.That(result.x == expected.x, Is.True, $"X should be {expected.x} but is {result.x}");
			Assert.That(result.y == expected.y, Is.True, $"Y should be {expected.y} but is {result.y}");
			Assert.That(result.z == expected.z, Is.True, $"Z should be {expected.z} but is {result.z}");
		}

		void AssertFloat(Float32 result, Float32 expected)
		{
			Assert.That(result == expected, Is.True, $"Value should be {expected} but is {result}");
		}
	}
}
