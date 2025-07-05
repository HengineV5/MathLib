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
		public double _value;

		public static ScalarType Type => ScalarType.Floating;

		public static Float64 One => 1f;

		public static Float64 Zero => 0f;

		public static Float64 Two => 2f;

		public static Float64 PI => MathF.PI;

		public static int Size => 4;

		public Float64(double value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static Float64 operator +(Float64 value)
			=> value._value;

		public static Float64 operator +(Float64 left, Float64 right)
			=> left._value + right._value;

		public static Float64 operator -(Float64 value)
			=> -value._value;

		public static Float64 operator -(Float64 left, Float64 right)
			=> left._value - right._value;

		public static Float64 operator ++(Float64 value)
			=> value._value++;

		public static Float64 operator --(Float64 value)
			=> value._value--;

		public static Float64 operator *(Float64 left, Float64 right)
			=> left._value * right._value;

		public static Float64 operator /(Float64 left, Float64 right)
			=> left._value / right._value;

		public static bool operator ==(Float64 left, Float64 right)
			=> left._value == right._value;

		public static bool operator !=(Float64 left, Float64 right)
			=> left._value != right._value;

		public static bool operator <(Float64 left, Float64 right)
			=> left._value < right._value;

		public static bool operator <=(Float64 left, Float64 right)
			=> left._value <= right._value;

		public static bool operator >(Float64 left, Float64 right)
			=> left._value > right._value;

		public static bool operator >=(Float64 left, Float64 right)
			=> left._value >= right._value;

		public static implicit operator double(Float64 i) => i._value;
		public static implicit operator Float64(double i) => new Float64(i);
		public static implicit operator Float64(int i) => new Float64(i);

		public static Float64 Sqrt(Float64 self)
		{
			return Math.Sqrt(self._value);
		}

		public static Float64 Cos(Float64 self)
		{
			return Math.Cos(self._value);
		}

		public static Float64 Sin(Float64 self)
		{
			return Math.Sin(self._value);
		}

		public static Float64 Tan(Float64 self)
		{
			return Math.Tan(self._value);
		}

		public static Float64 ACos(Float64 self)
		{
			return Math.Acos(self._value);
		}

		public static Float64 ASin(Float64 self)
		{
			return Math.Asin(self._value);
		}

		public static (Float64 sin, Float64 cos) SinCos(Float64 self)
		{
			return Math.SinCos(self._value);
		}

		public static Float64 Abs(Float64 self)
		{
			return Math.Abs(self._value);
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
			=> (byte)self._value;

		static UInt16 IConvertable<Float64, UInt16>.Convert(Float64 self)
			=> (ushort)self._value;

		static UInt32 IConvertable<Float64, UInt32>.Convert(Float64 self)
			=> (uint)self._value;

		static UInt64 IConvertable<Float64, UInt64>.Convert(Float64 self)
			=> (ulong)self._value;

		static Int16 IConvertable<Float64, Int16>.Convert(Float64 self)
			=> (short)self._value;

		static Int32 IConvertable<Float64, Int32>.Convert(Float64 self)
			=> (int)self._value;

		static Int64 IConvertable<Float64, Int64>.Convert(Float64 self)
			=> (long)self._value;

		static Float32 IConvertable<Float64, Float32>.Convert(Float64 self)
			=> (float)self._value;

		#endregion
	}
}
