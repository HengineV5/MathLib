
using System.Numerics;

namespace MathLib.Test
{
	public class GenericMatrix4x4Tests
	{
		Matrix4x4f m1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
		Matrix4x4f m2 = new(17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32);

		Vector4f v1 = new(1, 2, 3, 4);

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Initial()
		{
			Matrix4x4 m1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
			Matrix4x4f m2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

			AssertMatrix4x4(m2, m1);
		}

		[Test]
		public void Addition()
		{
			var r = m1 + m2;
			var e = new Matrix4x4f(18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48);

			AssertMatrix4x4(r, e);
		}

		[Test]
		public void Subtraction()
		{
			var r = m2 - m1;
			var e = new Matrix4x4f(16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16);

			AssertMatrix4x4(r, e);
		}

		[Test]
		public void Negate()
		{
			var r = -m1;
			var e = new Matrix4x4f(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16);

			AssertMatrix4x4(r, e);
		}

		[Test]
		public void Multiplication()
		{
			var r = m1 * m2;
			var e = new Matrix4x4f(250, 260, 270, 280, 618, 644, 670, 696, 986, 1028, 1070, 1112, 1354, 1412, 1470, 1528);

			AssertMatrix4x4(r, e);

			r = 2 * m1;
			e = new(2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32);

			AssertMatrix4x4(r, e);

			var r2 = MathHelpers.Multiply(in m1, in v1);
			var e2 = new Vector4f(30, 70, 110, 150);

			AssertFloat4(r2, e2);
		}

		[Test]
		public void Transpose()
		{
			var r = MathHelpers.Transpose(in m1);
			var e = new Matrix4x4f(1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15, 4, 8, 12, 16);

			AssertMatrix4x4(r, e);
		}

		[Test]
		public void Determinant()
		{
			var r = MathHelpers.Determinant(in m1);
			Float32 e = 0;

			AssertFloat(r, e);
		}

		[Test]
		public void TranslationMatrix()
		{
			/*
			var v = new Vector3f(1, 2, 3);
			var m = Matrix4x4f.CreateTranslation(in v);
			var e = new Matrix4x4f(1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 3, 0, 0, 0, 1);

			AssertMatrix4x4(m, e);
			*/

			var m1 = Matrix4x4.CreateTranslation(1, 2, 3);
			var m2 = Matrix4x4f.CreateTranslation(new Vector3f(1, 2, 3));

			Console.WriteLine(m1);
			Console.WriteLine();
			Console.WriteLine(m2);

			AssertMatrix4x4(m2, m1);
		}

		[Test]
		public void RotationMatrix()
		{
			var r = MathF.PI;
			var m = Matrix4x4f.CreateRotationX(r);
			var e = new Matrix4x4f(1, 0, 0, 0, 0, MathF.Cos(r), -MathF.Sin(r), 0, 0, MathF.Sin(r), MathF.Cos(r), 0, 0, 0, 0, 1);

			AssertMatrix4x4(m, e);

			m = Matrix4x4f.CreateRotationY(r);
			e = new Matrix4x4f(MathF.Cos(r), 0, -MathF.Sin(r), 0, 0, 1, 0, 0, MathF.Sin(r), 0, MathF.Cos(r), 0, 0, 0, 0, 1);

			AssertMatrix4x4(m, e);

			m = Matrix4x4f.CreateRotationZ(r);
			e = new Matrix4x4f(MathF.Cos(r), -MathF.Sin(r), 0, 0,- MathF.Sin(r), MathF.Cos(r), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

			AssertMatrix4x4(m, e);
		}

		[Test]
		public void ScaleMatrix()
		{
			var v = new Vector3f(1, 2, 3);
			var m = Matrix4x4f.CreateScale(in v);
			var e = new Matrix4x4f(1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1);

			AssertMatrix4x4(m, e);
		}

		[Test]
		public void FromQuaternion()
		{
			var q1 = new Quaternion(0.25f, 0.1f, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0.1f, 0.45f, 0.33f);

			var m1 = Matrix4x4.CreateFromQuaternion(q1);
			var m2 = Matrix4x4f.FromQuaternion(in q2);

			Console.WriteLine(m1);
			Console.WriteLine();
			Console.WriteLine(m2);

			AssertMatrix4x4(m2, m1);
		}

		[Test]
		public void CreatePerspective()
		{
			var m1 = Matrix4x4.CreatePerspectiveFieldOfView(MathF.PI / 2, 0.5f, 0.1f, 100);
			var m2 = Matrix4x4f.CreatePersperctive(MathF.PI / 2, 0.5f, 0.1f, 100);

			AssertMatrix4x4(m2, m1);
		}

		void AssertMatrix4x4(Matrix4x4f result, Matrix4x4f expected)
		{
			Assert.That(result.m11 == expected.m11, Is.True, $"M11 should be {expected.m11} but is {result.m11}");
			Assert.That(result.m12 == expected.m12, Is.True, $"M12 should be {expected.m12} but is {result.m12}");
			Assert.That(result.m13 == expected.m13, Is.True, $"M13 should be {expected.m13} but is {result.m13}");
			Assert.That(result.m14 == expected.m14, Is.True, $"M14 should be {expected.m14} but is {result.m14}");

			Assert.That(result.m21 == expected.m21, Is.True, $"M21 should be {expected.m21} but is {result.m21}");
			Assert.That(result.m22 == expected.m22, Is.True, $"M22 should be {expected.m22} but is {result.m22}");
			Assert.That(result.m23 == expected.m23, Is.True, $"M23 should be {expected.m23} but is {result.m23}");
			Assert.That(result.m24 == expected.m24, Is.True, $"M23 should be {expected.m24} but is {result.m24}");

			Assert.That(result.m31 == expected.m31, Is.True, $"M31 should be {expected.m31} but is {result.m31}");
			Assert.That(result.m32 == expected.m32, Is.True, $"M32 should be {expected.m32} but is {result.m32}");
			Assert.That(result.m33 == expected.m33, Is.True, $"M33 should be {expected.m33} but is {result.m33}");
			Assert.That(result.m34 == expected.m34, Is.True, $"M34 should be {expected.m34} but is {result.m34}");

			Assert.That(result.m41 == expected.m41, Is.True, $"M41 should be {expected.m41} but is {result.m41}");
			Assert.That(result.m42 == expected.m42, Is.True, $"M42 should be {expected.m42} but is {result.m42}");
			Assert.That(result.m43 == expected.m43, Is.True, $"M43 should be {expected.m43} but is {result.m43}");
			Assert.That(result.m44 == expected.m44, Is.True, $"M44 should be {expected.m44} but is {result.m44}");
		}

		void AssertMatrix4x4(Matrix4x4f result, Matrix4x4 expected)
		{
			Assert.That(result.m11 == expected.M11, Is.True, $"M11 should be {expected.M11} but is {result.m11}");
			Assert.That(result.m12 == expected.M12, Is.True, $"M12 should be {expected.M12} but is {result.m12}");
			Assert.That(result.m13 == expected.M13, Is.True, $"M13 should be {expected.M13} but is {result.m13}");
			Assert.That(result.m14 == expected.M14, Is.True, $"M14 should be {expected.M14} but is {result.m14}");

			Assert.That(result.m21 == expected.M21, Is.True, $"M21 should be {expected.M21} but is {result.m21}");
			Assert.That(result.m22 == expected.M22, Is.True, $"M22 should be {expected.M22} but is {result.m22}");
			Assert.That(result.m23 == expected.M23, Is.True, $"M23 should be {expected.M23} but is {result.m23}");
			Assert.That(result.m24 == expected.M24, Is.True, $"M23 should be {expected.M24} but is {result.m24}");

			Assert.That(result.m31 == expected.M31, Is.True, $"M31 should be {expected.M31} but is {result.m31}");
			Assert.That(result.m32 == expected.M32, Is.True, $"M32 should be {expected.M32} but is {result.m32}");
			Assert.That(result.m33 == expected.M33, Is.True, $"M33 should be {expected.M33} but is {result.m33}");
			Assert.That(result.m34 == expected.M34, Is.True, $"M34 should be {expected.M34} but is {result.m34}");

			Assert.That(result.m41 == expected.M41, Is.True, $"M41 should be {expected.M41} but is {result.m41}");
			Assert.That(result.m42 == expected.M42, Is.True, $"M42 should be {expected.M42} but is {result.m42}");
			Assert.That(result.m43 == expected.M43, Is.True, $"M43 should be {expected.M43} but is {result.m43}");
			Assert.That(result.m44 == expected.M44, Is.True, $"M44 should be {expected.M44} but is {result.m44}");
		}

		void AssertFloat4(Vector4f result, Vector4f expected)
		{
			Assert.That(result.x == expected.x, Is.True, $"X should be {expected.x} but is {result.x}");
			Assert.That(result.y == expected.y, Is.True, $"Y should be {expected.y} but is {result.y}");
			Assert.That(result.z == expected.z, Is.True, $"Z should be {expected.z} but is {result.z}");
			Assert.That(result.w == expected.w, Is.True, $"W should be {expected.w} but is {result.w}");
		}

		void AssertFloat(Float32 result, Float32 expected)
		{
			Assert.That(result == expected, Is.True, $"Value should be {expected} but is {result}");
		}
	}
}
