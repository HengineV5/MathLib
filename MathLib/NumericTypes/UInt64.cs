namespace MathLib
{
	public struct UInt64
		: INumericType<UInt64>
		, IConvertable<UInt64, UInt8>
		, IConvertable<UInt64, UInt16>
		, IConvertable<UInt64, UInt32>
		, IConvertable<UInt64, Int16>
		, IConvertable<UInt64, Int32>
		, IConvertable<UInt64, Int64>
		, IConvertable<UInt64, Float32>
		, IConvertable<UInt64, Float64>
	{
		public ulong _value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt64 One => 1;

		public static UInt64 Zero => 0;

		public static UInt64 Two => 2;

		public static int Size => 8;

		public UInt64(ulong value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static UInt64 operator +(UInt64 value)
			=> value._value;

		public static UInt64 operator +(UInt64 left, UInt64 right)
			=> (ulong)(left._value + right._value);

		public static UInt64 operator -(UInt64 value)
			=> throw new NotImplementedException();

		public static UInt64 operator -(UInt64 left, UInt64 right)
			=> (ulong)(left._value - right._value);

		public static UInt64 operator ++(UInt64 value)
			=> value._value++;

		public static UInt64 operator --(UInt64 value)
			=> value._value--;

		public static UInt64 operator *(UInt64 left, UInt64 right)
			=> (ulong)(left._value * right._value);

		public static UInt64 operator /(UInt64 left, UInt64 right)
			=> (ulong)(left._value / right._value);

		public static bool operator ==(UInt64 left, UInt64 right)
			=> left._value == right._value;

		public static bool operator !=(UInt64 left, UInt64 right)
			=> left._value != right._value;

		public static bool operator <(UInt64 left, UInt64 right)
			=> left._value < right._value;

		public static bool operator <=(UInt64 left, UInt64 right)
			=> left._value <= right._value;

		public static bool operator >(UInt64 left, UInt64 right)
			=> left._value > right._value;

		public static bool operator >=(UInt64 left, UInt64 right)
			=> left._value >= right._value;

		public static implicit operator ulong(UInt64 i) => i._value;
		public static implicit operator UInt64(ulong i) => new UInt64(i);

		public static UInt64 Abs(UInt64 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt64 self, UInt64 num)
		{
			throw new NotImplementedException();
		}

		public static UInt64 FromInteger(int number)
			=> new((ulong)number);

		public static UInt64 FromInteger(uint number)
			=> new(number);

		#region Unit conversions

		static UInt8 IConvertable<UInt64, UInt8>.Convert(UInt64 self)
			=> (byte)self._value;

		static UInt16 IConvertable<UInt64, UInt16>.Convert(UInt64 self)
			=> (ushort)self._value;

		static UInt32 IConvertable<UInt64, UInt32>.Convert(UInt64 self)
			=> (uint)self._value;

		static Int16 IConvertable<UInt64, Int16>.Convert(UInt64 self)
			=> (short)self._value;

		static Int32 IConvertable<UInt64, Int32>.Convert(UInt64 self)
			=> (int)self._value;

		static Int64 IConvertable<UInt64, Int64>.Convert(UInt64 self)
			=> (long)self._value;

		static Float32 IConvertable<UInt64, Float32>.Convert(UInt64 self)
			=> self._value;

		static Float64 IConvertable<UInt64, Float64>.Convert(UInt64 self)
			=> self._value;

		#endregion
	}
}
