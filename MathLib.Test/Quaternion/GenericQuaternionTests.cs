using System.Diagnostics;
using System.Numerics;

namespace MathLib.Test
{
	public class GenericQuaternionTests
	{
		Vector3 v1 = new(1, 2, 3);
		Vector3f v1f = new(1, 2, 3);
		Vector3 v2 = new(4, 5, 6);

		Vector3f v3 = new(1, 2, 3);
		Vector3f v4 = new(4, 5, 6);

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Multiply()
		{
			var q1 = new Quaternion(0.25f, 0, 0.45f, 0.33f);
			var q2 = new Quaternion(0.5f, 1.6f, 0.45f, 0.66f);
			var q3 = new Quaternionf(0.25f, 0, 0.45f, 0.33f);
			var q4 = new Quaternionf(0.5f, 1.6f, 0.45f, 0.66f);

			var r1 = q1 * q2;
			var r2 = Quaternionf.Multiplty(in q3, in q4);

			Console.WriteLine(r1);
			Console.WriteLine(r2);

			AssertQuaternion(r1, r2, "");

			var r3 = Quaternion.Multiply(q1, 2.3f);
			var r4 = Quaternionf.Multiplty(in q3, 2.3f);

			AssertQuaternion(r3, r4, "");

			var r5 = q1 * Quaternion.Identity;
			var r6 = Quaternionf.Multiplty(in q3, Quaternionf.Identity);

			AssertQuaternion(r5, r6, "");
		}

		[Test]
		public void Length()
		{
			var q1 = new Quaternion(0.25f, 0.1f, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0.1f, 0.45f, 0.33f);

			var r1 = q1.Length();
			var r2 = Quaternionf.Length(in q2);

			Assert.That(r1 == r2, Is.True, $"Length should be {r1} but is {r2}");

			var r3 = q1.LengthSquared();
			var r4 = Quaternionf.LengthSquared(in q2);

			Assert.That(r3 == r4, Is.True, $"Length should be {r3} but is {r4}");
		}

		[Test]
		public void Inverse()
		{
			var q1 = new Quaternion(0.25f, 0.1f, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0.1f, 0.45f, 0.33f);

			var r1 = Quaternion.Inverse(q1);
			var r2 = Quaternionf.Inverse(in q2);

			AssertQuaternion(r1, r2, "");
		}

		[Test]
		public void Transform()
		{
			var q1 = new Quaternion(0.25f, 0.1f, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0.1f, 0.45f, 0.33f);

			var v1 = new Vector3(0.75f, 0.66f, 2);
			var v2 = new Vector3f(0.75f, 0.66f, 2);

			var r1 = Vector3.Transform(v1, q1);
			var r2 = Vector3f.Transform(in v2, in q2);

			AssertVector3(r1, r2, "");
		}

		public static IEnumerable<TestCaseData> RotationMatrixCases
		{
			get
			{
				yield return new TestCaseData(
					new Matrix4x4f(
						1f, 0f, 0f, 0f,
						0f, 0.70710677f, -0.70710677f, 0f,
						0f, 0.70710677f,  0.70710677f, 0f,
						0f, 0f, 0f, 1f)
				).SetName("FromRotationMatrix (trace > 0)");

				yield return new TestCaseData(
					new Matrix4x4f(
						1, 0, 0, 0,
						0, -0.5f, -0.8660254f, 0,
						0, 0.8660254f, -0.5f, 0,
						0, 0, 0, 1
					)
				).SetName("FromRotationMatrix (m00 > m11 && m00 > m22)");

				yield return new TestCaseData(
					new Matrix4x4f(
						-0.5f, 0, 0.8660254f, 0,
						0, 1, 0, 0,
						-0.8660254f, 0, -0.5f, 0,
						0, 0, 0, 1
					)
				).SetName("FromRotationMatrix (m11 > m22)");

				yield return new TestCaseData(
					new Matrix4x4f(
						-0.5f, -0.8660254f, 0, 0,
						0.8660254f, -0.5f, 0, 0,
						0, 0, 1, 0,
						0, 0, 0, 1
					)
				).SetName("FromRotationMatrix (else)");
			}
		}

		[Test, TestCaseSource(nameof(RotationMatrixCases))]
		public void FromRotationMatrix_AllBranches(Matrix4x4f rot)
		{
			var q = Quaternionf.FromRotationMatrix(in rot);
			var result = Matrix4x4f.FromQuaternion(in q);
			AssertMatrix4x4(result, rot);
		}

		/*
		[Test]
		public void CreateLookAt()
		{
			var rot2 = Matrix4x4.CreateLookAt(Vector3.Zero, v1, Vector3.UnitZ);

			var q1 = Quaternionf.CreateLookAt(Vector3f.Normalize(in v1f));
			var q2 = Quaternion.CreateFromRotationMatrix(rot2);

			Console.WriteLine(q1);
			Console.WriteLine(Quaternionf.Length(in q1));
			Console.WriteLine(q2);
			Console.WriteLine(q2.Length());

			var vec1 = Vector3.Transform(Vector3.UnitX, q2);
			var vec2 = Vector3f.Transform(Vector3f.UnitY, in q1);

			Console.WriteLine(vec1);
			Console.WriteLine(vec1.Length());

			Console.WriteLine(vec2);
			Console.WriteLine(Vector3f.Length(in vec2));

			AssertQuaternion(q2, q1, "");
		}
		*/

		void AssertQuaternion(Quaternion r1, Quaternionf r2, string op)
		{
			// I chose W as real part, dotnet has X as real part

			Assert.That(Float32.IsClose(r1.X, r2.x), Is.True, $"X should be {r1.X} but is {r2.x}");
			Assert.That(Float32.IsClose(r1.Y, r2.y), Is.True, $"Y should be {r1.Y} but is {r2.y}");
			Assert.That(Float32.IsClose(r1.Z, r2.z), Is.True, $"Z should be {r1.Z} but is {r2.z}");
			Assert.That(Float32.IsClose(r1.W, r2.w), Is.True, $"W should be {r1.W} but is {r2.w}");
		}

		void AssertVector3(Vector3 r1, Vector3f r2, string op)
		{
			// I chose W as real part, dotnet has X as real part

			Assert.That(Float32.IsClose(r1.X, r2.x), Is.True, $"X should be {r1.X} but is {r2.x}");
			Assert.That(Float32.IsClose(r1.Y, r2.y), Is.True, $"Y should be {r1.Y} but is {r2.y}");
			Assert.That(Float32.IsClose(r1.Z, r2.z), Is.True, $"Z should be {r1.Z} but is {r2.z}");
		}

		void AssertMatrix4x4(Matrix4x4f result, Matrix4x4f expected)
		{
			Assert.That(Float32.IsClose(result.m11, expected.m11), Is.True, $"M11 should be {expected.m11} but is {result.m11}");
			Assert.That(Float32.IsClose(result.m11, expected.m11), Is.True, $"M11 should be {expected.m11} but is {result.m11}");
			Assert.That(Float32.IsClose(result.m12, expected.m12), Is.True, $"M12 should be {expected.m12} but is {result.m12}");
			Assert.That(Float32.IsClose(result.m13, expected.m13), Is.True, $"M13 should be {expected.m13} but is {result.m13}");
			Assert.That(Float32.IsClose(result.m14, expected.m14), Is.True, $"M14 should be {expected.m14} but is {result.m14}");

			Assert.That(Float32.IsClose(result.m21, expected.m21), Is.True, $"M21 should be {expected.m21} but is {result.m21}");
			Assert.That(Float32.IsClose(result.m22, expected.m22), Is.True, $"M22 should be {expected.m22} but is {result.m22}");
			Assert.That(Float32.IsClose(result.m23, expected.m23), Is.True, $"M23 should be {expected.m23} but is {result.m23}");
			Assert.That(Float32.IsClose(result.m24, expected.m24), Is.True, $"M23 should be {expected.m24} but is {result.m24}");

			Assert.That(Float32.IsClose(result.m31, expected.m31), Is.True, $"M31 should be {expected.m31} but is {result.m31}");
			Assert.That(Float32.IsClose(result.m32, expected.m32), Is.True, $"M32 should be {expected.m32} but is {result.m32}");
			Assert.That(Float32.IsClose(result.m33, expected.m33), Is.True, $"M33 should be {expected.m33} but is {result.m33}");
			Assert.That(Float32.IsClose(result.m34, expected.m34), Is.True, $"M34 should be {expected.m34} but is {result.m34}");

			Assert.That(Float32.IsClose(result.m41, expected.m41), Is.True, $"M41 should be {expected.m41} but is {result.m41}");
			Assert.That(Float32.IsClose(result.m42, expected.m42), Is.True, $"M42 should be {expected.m42} but is {result.m42}");
			Assert.That(Float32.IsClose(result.m43, expected.m43), Is.True, $"M43 should be {expected.m43} but is {result.m43}");
			Assert.That(Float32.IsClose(result.m44, expected.m44), Is.True, $"M44 should be {expected.m44} but is {result.m44}");
		}
	}
}
