namespace MathLib
{
	public struct Float64
		: IFloatingNumericType<Float64>, INumericType<Float64>
		, IConvertable<Float64, UInt8>
		, IConvertable<Float64, UInt16>
		, IConvertable<Float64, UInt32>
		, IConvertable<Float64, UInt64>
		, IConvertable<Float64, Int16>
		, IConvertable<Float64, Int32>
		, IConvertable<Float64, Int64>
		, IConvertable<Float64, Float32>
	{
		double value;

		public static ScalarType Type => ScalarType.Floating;

		public static Float64 One => 1f;

		public static Float64 Zero => 0f;

		public static Float64 Two => 2f;

		public static Float64 PI => MathF.PI;

		public static int Size => 4;

		public Float64(double value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static Float64 operator +(Float64 value)
			=> value.value;

		public static Float64 operator +(Float64 left, Float64 right)
			=> left.value + right.value;

		public static Float64 operator -(Float64 value)
			=> -value.value;

		public static Float64 operator -(Float64 left, Float64 right)
			=> left.value - right.value;

		public static Float64 operator ++(Float64 value)
			=> value.value++;

		public static Float64 operator --(Float64 value)
			=> value.value--;

		public static Float64 operator *(Float64 left, Float64 right)
			=> left.value * right.value;

		public static Float64 operator /(Float64 left, Float64 right)
			=> left.value / right.value;

		public static bool operator ==(Float64 left, Float64 right)
			=> left.value == right.value;

		public static bool operator !=(Float64 left, Float64 right)
			=> left.value != right.value;

		public static implicit operator double(Float64 i) => i.value;
		public static implicit operator Float64(double i) => new Float64(i);
		public static implicit operator Float64(int i) => new Float64(i);

		public static Float64 Sqrt(Float64 self)
		{
			return Math.Sqrt(self.value);
		}

		public static Float64 Cos(Float64 self)
		{
			return Math.Cos(self.value);
		}

		public static Float64 Sin(Float64 self)
		{
			return Math.Sin(self.value);
		}

		public static Float64 Tan(Float64 self)
		{
			return Math.Tan(self.value);
		}

		public static Float64 ACos(Float64 self)
		{
			return Math.Acos(self.value);
		}

		public static Float64 ASin(Float64 self)
		{
			return Math.Asin(self.value);
		}

		public static (Float64 sin, Float64 cos) SinCos(Float64 self)
		{
			return Math.SinCos(self.value);
		}

		public static Float64 Abs(Float64 self)
		{
			return Math.Abs(self.value);
		}

		public static bool IsClose(Float64 self, Float64 num)
		{
			return Math.Abs(self - num) < 0.00001f;
		}

		public static Float64 FromInteger(int number)
			=> new(number);

		public static Float64 FromInteger(uint number)
			=> new(number);

		public static Float64 FromFloat(float number)
			=> new(number);

		public static Float64 FromFloat(double number)
			=> new(number);

		#region Unit conversions

		static UInt8 IConvertable<Float64, UInt8>.Convert(Float64 self)
			=> (byte)self.value;

		static UInt16 IConvertable<Float64, UInt16>.Convert(Float64 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<Float64, UInt32>.Convert(Float64 self)
			=> (uint)self.value;

		static UInt64 IConvertable<Float64, UInt64>.Convert(Float64 self)
			=> (ulong)self.value;

		static Int16 IConvertable<Float64, Int16>.Convert(Float64 self)
			=> (short)self.value;

		static Int32 IConvertable<Float64, Int32>.Convert(Float64 self)
			=> (int)self.value;

		static Int64 IConvertable<Float64, Int64>.Convert(Float64 self)
			=> (long)self.value;

		static Float32 IConvertable<Float64, Float32>.Convert(Float64 self)
			=> (float)self.value;

		#endregion
	}
}
