
namespace MathLib
{
	public struct Int16
		: INumericType<Int16>
		, IConvertable<Int16, UInt8>
		, IConvertable<Int16, UInt16>
		, IConvertable<Int16, UInt32>
		, IConvertable<Int16, UInt64>
		, IConvertable<Int16, Int32>
		, IConvertable<Int16, Int64>
		, IConvertable<Int16, Float32>
		, IConvertable<Int16, Float64>
	{
		public short _value;

		public static ScalarType Type => ScalarType.Integer;

		public static Int16 One => 1;

		public static Int16 Zero => 0;

		public static Int16 Two => 2;

		public static int Size => 2;

		public Int16(short value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static Int16 operator +(Int16 value)
			=> value._value;

		public static Int16 operator +(Int16 left, Int16 right)
			=> (short)(left._value + right._value);

		public static Int16 operator -(Int16 value)
			=> (short)(-value._value);

		public static Int16 operator -(Int16 left, Int16 right)
			=> (short)(left._value - right._value);

		public static Int16 operator ++(Int16 value)
			=> value._value++;

		public static Int16 operator --(Int16 value)
			=> value._value--;

		public static Int16 operator *(Int16 left, Int16 right)
			=> (short)(left._value * right._value);

		public static Int16 operator /(Int16 left, Int16 right)
			=> (short)(left._value / right._value);

		public static bool operator ==(Int16 left, Int16 right)
			=> left._value == right._value;

		public static bool operator !=(Int16 left, Int16 right)
			=> left._value != right._value;

		public static bool operator <(Int16 left, Int16 right)
			=> left._value < right._value;

		public static bool operator <=(Int16 left, Int16 right)
			=> left._value <= right._value;

		public static bool operator >(Int16 left, Int16 right)
			=> left._value > right._value;

		public static bool operator >=(Int16 left, Int16 right)
			=> left._value >= right._value;

		public static implicit operator short(Int16 i) => i._value;
		public static implicit operator Int16(short i) => new Int16(i);

		public static Int16 Abs(Int16 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(Int16 self, Int16 num)
		{
			throw new NotImplementedException();
		}

		public static int Sign(Int16 self)
		{
			return MathF.Sign(self._value);
		}

		public static Int16 FromInteger(int number)
			=> new((short)number);

		public static Int16 FromInteger(uint number)
			=> new((short)number);

		#region Unit conversions

		static UInt8 IConvertable<Int16, UInt8>.Convert(Int16 self)
			=> (byte)self._value;

		static UInt16 IConvertable<Int16, UInt16>.Convert(Int16 self)
			=> (ushort)self._value;

		static UInt32 IConvertable<Int16, UInt32>.Convert(Int16 self)
			=> (uint)self._value;

		static UInt64 IConvertable<Int16, UInt64>.Convert(Int16 self)
			=> (ulong)self._value;

		static Int32 IConvertable<Int16, Int32>.Convert(Int16 self)
			=> self._value;

		static Int64 IConvertable<Int16, Int64>.Convert(Int16 self)
			=> self._value;

		static Float32 IConvertable<Int16, Float32>.Convert(Int16 self)
			=> self._value;

		static Float64 IConvertable<Int16, Float64>.Convert(Int16 self)
			=> self._value;

		#endregion
	}
}
