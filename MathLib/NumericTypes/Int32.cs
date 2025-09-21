
namespace MathLib
{
	public struct Int32
		: INumericType<Int32>
		, IConvertable<Int32, UInt8>
		, IConvertable<Int32, UInt16>
		, IConvertable<Int32, UInt32>
		, IConvertable<Int32, UInt64>
		, IConvertable<Int32, Int16>
		, IConvertable<Int32, Int64>
		, IConvertable<Int32, Float32>
		, IConvertable<Int32, Float64>
	{
		public int _value;

		public static ScalarType Type => ScalarType.Integer;

		public static Int32 One => 1;

		public static Int32 Zero => 0;

		public static Int32 Two => 4;

		public static int Size => 4;

		public Int32(int value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static Int32 operator +(Int32 value)
			=> value._value;

		public static Int32 operator +(Int32 left, Int32 right)
			=> left._value + right._value;

		public static Int32 operator -(Int32 value)
			=> -value._value;

		public static Int32 operator -(Int32 left, Int32 right)
			=> left._value - right._value;

		public static Int32 operator ++(Int32 value)
			=> value._value++;

		public static Int32 operator --(Int32 value)
			=> value._value--;

		public static Int32 operator *(Int32 left, Int32 right)
			=> left._value * right._value;

		public static Int32 operator /(Int32 left, Int32 right)
			=> left._value / right._value;

		public static bool operator ==(Int32 left, Int32 right)
			=> left._value == right._value;

		public static bool operator !=(Int32 left, Int32 right)
			=> left._value != right._value;

		public static bool operator <(Int32 left, Int32 right)
			=> left._value < right._value;

		public static bool operator <=(Int32 left, Int32 right)
			=> left._value <= right._value;

		public static bool operator >(Int32 left, Int32 right)
			=> left._value > right._value;

		public static bool operator >=(Int32 left, Int32 right)
			=> left._value >= right._value;

		public static implicit operator int(Int32 i) => i._value;
		public static implicit operator Int32(int i) => new Int32(i);

		public static Int32 Abs(Int32 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(Int32 self, Int32 num)
		{
			throw new NotImplementedException();
		}

		public static int Sign(Int32 self)
		{
			return MathF.Sign(self._value);
		}

		public static Int32 FromInteger(int number)
			=> new(number);

		public static Int32 FromInteger(uint number)
			=> new((int)number);

		#region Unit conversions

		static UInt8 IConvertable<Int32, UInt8>.Convert(Int32 self)
			=> (byte)self._value;

		static UInt16 IConvertable<Int32, UInt16>.Convert(Int32 self)
			=> (ushort)self._value;

		static UInt32 IConvertable<Int32, UInt32>.Convert(Int32 self)
			=> (uint)self._value;

		static UInt64 IConvertable<Int32, UInt64>.Convert(Int32 self)
			=> (ulong)self._value;

		static Int16 IConvertable<Int32, Int16>.Convert(Int32 self)
			=> (short)self._value;

		static Int64 IConvertable<Int32, Int64>.Convert(Int32 self)
			=> self._value;

		static Float32 IConvertable<Int32, Float32>.Convert(Int32 self)
			=> self._value;

		static Float64 IConvertable<Int32, Float64>.Convert(Int32 self)
			=> self._value;

		#endregion
	}
}
