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
			var q2 = new Quaternionf(0.25f, 0, 0.45f, 0.33f);

			var r1 = q1 * q1;
			var r2 = Quaternionf.Multiplty(in q2, in q2);

			AssertQuaternion(r1, r2, "");

			var r3 = Quaternion.Multiply(q1, 2.3f);
			var r4 = Quaternionf.Multiplty(in q2, 2.3f);

			AssertQuaternion(r3, r4, "");
		}

		[Test]
		public void Length()
		{
			var q1 = new Quaternion(0.25f, 0, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0, 0.45f, 0.33f);

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
			var q1 = new Quaternion(0.25f, 0, 0.45f, 0.33f);
			var q2 = new Quaternionf(0.25f, 0, 0.45f, 0.33f);

			var r1 = Quaternion.Inverse(q1);
			var r2 = Quaternionf.Inverse(in q2);

			Console.WriteLine(r1);
			Console.WriteLine(r2);

			AssertQuaternion(r1, r2, "");
		}

		[Test]
		public void FromRotationMatrix()
		{
			var rot1 = Matrix4x4f.CreateRotationX(MathF.PI / 2);
			var rot2 = Matrix4x4.CreateRotationX(MathF.PI / 2);

			var q1 = Quaternionf.FromRotationMatrix(in rot1);
			var q2 = Quaternion.CreateFromRotationMatrix(rot2);

			AssertQuaternion(q2, q1, "");
		}

		[Test]
		public void CreateLookAt()
		{
			var rot2 = Matrix4x4.CreateLookAt(Vector3.Zero, v1, Vector3.UnitZ);

			var q1 = Quaternionf.CreateLookAt(in v1f);
			var q2 = Quaternion.CreateFromRotationMatrix(rot2);

			AssertQuaternion(q2, q1, "");
		}

		void AssertQuaternion(Quaternion r1, Quaternionf r2, string op)
		{
			// I chose W as real part, dotnet has X as real part

			Assert.That(r1.W == r2.x, Is.True, $"X should be {r1.X} but is {r2.x}");
			Assert.That(r1.X == r2.y, Is.True, $"Y should be {r1.Y} but is {r2.y}");
			Assert.That(r1.Y == r2.z, Is.True, $"Z should be {r1.Z} but is {r2.z}");
			Assert.That(r1.Z == r2.w, Is.True, $"W should be {r1.W} but is {r2.w}");
		}
	}
}
