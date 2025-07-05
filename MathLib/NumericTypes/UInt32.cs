namespace MathLib
{
	public struct UInt32
		: INumericType<UInt32>
		, IConvertable<UInt32, UInt8>
		, IConvertable<UInt32, UInt16>
		, IConvertable<UInt32, UInt64>
		, IConvertable<UInt32, Int16>
		, IConvertable<UInt32, Int32>
		, IConvertable<UInt32, Int64>
		, IConvertable<UInt32, Float32>
		, IConvertable<UInt32, Float64>
	{
		public uint _value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt32 One => 1;

		public static UInt32 Zero => 0;

		public static UInt32 Two => 2;

		public static int Size => 4;

		public UInt32(uint value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static UInt32 operator +(UInt32 value)
			=> value._value;

		public static UInt32 operator +(UInt32 left, UInt32 right)
			=> (uint)(left._value + right._value);

		public static UInt32 operator -(UInt32 value)
			=> (uint)-value._value;

		public static UInt32 operator -(UInt32 left, UInt32 right)
			=> (uint)(left._value - right._value);

		public static UInt32 operator ++(UInt32 value)
			=> value._value++;

		public static UInt32 operator --(UInt32 value)
			=> value._value--;

		public static UInt32 operator *(UInt32 left, UInt32 right)
			=> (uint)(left._value * right._value);

		public static UInt32 operator /(UInt32 left, UInt32 right)
			=> (uint)(left._value / right._value);

		public static bool operator ==(UInt32 left, UInt32 right)
			=> left._value == right._value;

		public static bool operator !=(UInt32 left, UInt32 right)
			=> left._value != right._value;

		public static bool operator <(UInt32 left, UInt32 right)
			=> left._value < right._value;

		public static bool operator <=(UInt32 left, UInt32 right)
			=> left._value <= right._value;

		public static bool operator >(UInt32 left, UInt32 right)
			=> left._value > right._value;

		public static bool operator >=(UInt32 left, UInt32 right)
			=> left._value >= right._value;

		public static implicit operator uint(UInt32 i) => i._value;
		public static implicit operator UInt32(uint i) => new UInt32(i);

		public static UInt32 Abs(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt32 self, UInt32 num)
		{
			throw new NotImplementedException();
		}

		public static UInt32 FromInteger(int number)
			=> new((uint)number);

		public static UInt32 FromInteger(uint number)
			=> new(number);

		#region Unit conversions

		static UInt8 IConvertable<UInt32, UInt8>.Convert(UInt32 self)
			=> (byte)self._value;

		static UInt16 IConvertable<UInt32, UInt16>.Convert(UInt32 self)
			=> (ushort)self._value;

		static UInt64 IConvertable<UInt32, UInt64>.Convert(UInt32 self)
			=> self._value;

		static Int16 IConvertable<UInt32, Int16>.Convert(UInt32 self)
			=> (short)self._value;

		static Int32 IConvertable<UInt32, Int32>.Convert(UInt32 self)
			=> (int)self._value;

		static Int64 IConvertable<UInt32, Int64>.Convert(UInt32 self)
			=> self._value;

		static Float32 IConvertable<UInt32, Float32>.Convert(UInt32 self)
			=> self._value;

		static Float64 IConvertable<UInt32, Float64>.Convert(UInt32 self)
			=> self._value;

		#endregion
	}
}
