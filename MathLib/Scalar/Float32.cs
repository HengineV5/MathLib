namespace MathLib
{
	public struct Float32
		: IScalar<Float32>
		, IConvertable<Float32, UInt8>
		, IConvertable<Float32, UInt16>
		, IConvertable<Float32, UInt32>
		, IConvertable<Float32, UInt64>
		, IConvertable<Float32, Int16>
		, IConvertable<Float32, Int32>
		, IConvertable<Float32, Int64>
		, IConvertable<Float32, Float64>
	{
		float value;

		public static ScalarType Type => ScalarType.Floating;

		public static Float32 One => 1f;

		public static Float32 Zero => 0f;

		public static Float32 Two => 2f;

		public static Float32 PI => MathF.PI;

		public static int Size => 4;

		public Float32(float value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static Float32 operator +(Float32 value)
			=> value.value;

		public static Float32 operator +(Float32 left, Float32 right)
			=> left.value + right.value;

		public static Float32 operator -(Float32 value)
			=> -value.value;

		public static Float32 operator -(Float32 left, Float32 right)
			=> left.value - right.value;

		public static Float32 operator ++(Float32 value)
			=> value.value++;

		public static Float32 operator --(Float32 value)
			=> value.value--;

		public static Float32 operator *(Float32 left, Float32 right)
			=> left.value * right.value;

		public static Float32 operator /(Float32 left, Float32 right)
			=> left.value / right.value;

		public static bool operator ==(Float32 left, Float32 right)
			=> left.value == right.value;

		public static bool operator !=(Float32 left, Float32 right)
			=> left.value != right.value;

		public static implicit operator float(Float32 i) => i.value;
		public static implicit operator Float32(float i) => new Float32(i);
		public static implicit operator Float32(int i) => new Float32(i);

		public static Float32 Sqrt(Float32 self)
		{
			return MathF.Sqrt(self.value);
		}

		public static Float32 Cos(Float32 self)
		{
			return MathF.Cos(self.value);
		}

		public static Float32 Sin(Float32 self)
		{
			return MathF.Sin(self.value);
		}

		public static Float32 Tan(Float32 self)
		{
			return MathF.Tan(self.value);
		}

		public static Float32 ACos(Float32 self)
		{
			return MathF.Acos(self.value);
		}

		public static Float32 ASin(Float32 self)
		{
			return MathF.Asin(self.value);
		}

		public static (Float32 sin, Float32 cos) SinCos(Float32 self)
		{
			return MathF.SinCos(self.value);
		}

		public static Float32 Abs(Float32 self)
		{
			return MathF.Abs(self.value);
		}

		public static bool IsClose(Float32 self, Float32 num)
		{
			return MathF.Abs(self - num) < 0.00001f;
		}

		#region Unit conversions

		static UInt8 IConvertable<Float32, UInt8>.Convert(Float32 self)
			=> (byte)self.value;

		static UInt16 IConvertable<Float32, UInt16>.Convert(Float32 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<Float32, UInt32>.Convert(Float32 self)
			=> (uint)self.value;

		static UInt64 IConvertable<Float32, UInt64>.Convert(Float32 self)
			=> (ulong)self.value;

		static Int16 IConvertable<Float32, Int16>.Convert(Float32 self)
			=> (short)self.value;

		static Int32 IConvertable<Float32, Int32>.Convert(Float32 self)
			=> (int)self.value;

		static Int64 IConvertable<Float32, Int64>.Convert(Float32 self)
			=> (long)self.value;

		static Float64 IConvertable<Float32, Float64>.Convert(Float32 self)
			=> self.value;

		#endregion
	}
}
