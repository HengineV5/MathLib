namespace MathLib
{
	public struct Float32
		: IFloatingNumericType<Float32>, INumericType<Float32>
		, IConvertable<Float32, UInt8>
		, IConvertable<Float32, UInt16>
		, IConvertable<Float32, UInt32>
		, IConvertable<Float32, UInt64>
		, IConvertable<Float32, Int16>
		, IConvertable<Float32, Int32>
		, IConvertable<Float32, Int64>
		, IConvertable<Float32, Float64>
	{
		public float _value;

		public static ScalarType Type => ScalarType.Floating;

		public static Float32 One => 1f;

		public static Float32 Zero => 0f;

		public static Float32 Two => 2f;

		public static Float32 PI => MathF.PI;

		public static int Size => 4;

		public Float32(float value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static Float32 operator +(Float32 value)
			=> value._value;

		public static Float32 operator +(Float32 left, Float32 right)
			=> left._value + right._value;

		public static Float32 operator -(Float32 value)
			=> -value._value;

		public static Float32 operator -(Float32 left, Float32 right)
			=> left._value - right._value;

		public static Float32 operator ++(Float32 value)
			=> value._value++;

		public static Float32 operator --(Float32 value)
			=> value._value--;

		public static Float32 operator *(Float32 left, Float32 right)
			=> left._value * right._value;

		public static Float32 operator /(Float32 left, Float32 right)
			=> left._value / right._value;

		public static bool operator ==(Float32 left, Float32 right)
			=> left._value == right._value;

		public static bool operator !=(Float32 left, Float32 right)
			=> left._value != right._value;

		public static bool operator <(Float32 left, Float32 right)
			=> left._value < right._value;

		public static bool operator <=(Float32 left, Float32 right)
			=> left._value <= right._value;

		public static bool operator >(Float32 left, Float32 right)
			=> left._value > right._value;

		public static bool operator >=(Float32 left, Float32 right)
			=> left._value >= right._value;

		public static implicit operator float(Float32 i) => i._value;
		public static implicit operator Float32(float i) => new Float32(i);
		public static implicit operator Float32(int i) => new Float32(i);

		public static Float32 Sqrt(Float32 self)
		{
			return MathF.Sqrt(self._value);
		}

		public static Float32 Cos(Float32 self)
		{
			return MathF.Cos(self._value);
		}

		public static Float32 Sin(Float32 self)
		{
			return MathF.Sin(self._value);
		}

		public static Float32 Tan(Float32 self)
		{
			return MathF.Tan(self._value);
		}

		public static Float32 ACos(Float32 self)
		{
			return MathF.Acos(self._value);
		}

		public static Float32 ASin(Float32 self)
		{
			return MathF.Asin(self._value);
		}

		public static (Float32 sin, Float32 cos) SinCos(Float32 self)
		{
			return MathF.SinCos(self._value);
		}

		public static Float32 Abs(Float32 self)
		{
			return MathF.Abs(self._value);
		}

		public static bool IsClose(Float32 self, Float32 num)
		{
			return MathF.Abs(self - num) < 0.00001f;
		}

		public static Float32 FromInteger(int number)
			=> new(number);

		public static Float32 FromInteger(uint number)
			=> new(number);

		public static Float32 FromFloat(float number)
			=> new(number);

		public static Float32 FromFloat(double number)
			=> new((float)number);

		#region Unit conversions

		static UInt8 IConvertable<Float32, UInt8>.Convert(Float32 self)
			=> (byte)self._value;

		static UInt16 IConvertable<Float32, UInt16>.Convert(Float32 self)
			=> (ushort)self._value;

		static UInt32 IConvertable<Float32, UInt32>.Convert(Float32 self)
			=> (uint)self._value;

		static UInt64 IConvertable<Float32, UInt64>.Convert(Float32 self)
			=> (ulong)self._value;

		static Int16 IConvertable<Float32, Int16>.Convert(Float32 self)
			=> (short)self._value;

		static Int32 IConvertable<Float32, Int32>.Convert(Float32 self)
			=> (int)self._value;

		static Int64 IConvertable<Float32, Int64>.Convert(Float32 self)
			=> (long)self._value;

		static Float64 IConvertable<Float32, Float64>.Convert(Float32 self)
			=> self._value;

		#endregion
	}
}
