
namespace MathLib
{
	public struct Int64
		: INumericType<Int64>
		, IConvertable<Int64, UInt8>
		, IConvertable<Int64, UInt16>
		, IConvertable<Int64, UInt32>
		, IConvertable<Int64, UInt64>
		, IConvertable<Int64, Int16>
		, IConvertable<Int64, Int32>
		, IConvertable<Int64, Float32>
		, IConvertable<Int64, Float64>
	{
		long value;

		public static ScalarType Type => ScalarType.Integer;

		public static Int64 One => 1;

		public static Int64 Zero => 0;

		public static Int64 Two => 2;

		public static int Size => 8;

		public Int64(long value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static Int64 operator +(Int64 value)
			=> value.value;

		public static Int64 operator +(Int64 left, Int64 right)
			=> left.value + right.value;

		public static Int64 operator -(Int64 value)
			=> -value.value;

		public static Int64 operator -(Int64 left, Int64 right)
			=> left.value - right.value;

		public static Int64 operator ++(Int64 value)
			=> value.value++;

		public static Int64 operator --(Int64 value)
			=> value.value--;

		public static Int64 operator *(Int64 left, Int64 right)
			=> left.value * right.value;

		public static Int64 operator /(Int64 left, Int64 right)
			=> left.value / right.value;

		public static bool operator ==(Int64 left, Int64 right)
			=> left.value == right.value;

		public static bool operator !=(Int64 left, Int64 right)
			=> left.value != right.value;

		public static implicit operator long(Int64 i) => i.value;
		public static implicit operator Int64(long i) => new Int64(i);

		public static Int64 Abs(Int64 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(Int64 self, Int64 num)
		{
			throw new NotImplementedException();
		}

		public static Int64 FromInteger(int number)
			=> new(number);

		public static Int64 FromInteger(uint number)
			=> new(number);

		#region Unit conversions

		static UInt8 IConvertable<Int64, UInt8>.Convert(Int64 self)
			=> (byte)self.value;

		static UInt16 IConvertable<Int64, UInt16>.Convert(Int64 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<Int64, UInt32>.Convert(Int64 self)
			=> (uint)self.value;

		static UInt64 IConvertable<Int64, UInt64>.Convert(Int64 self)
			=> (ulong)self.value;

		static Int16 IConvertable<Int64, Int16>.Convert(Int64 self)
			=> (short)self.value;

		static Int32 IConvertable<Int64, Int32>.Convert(Int64 self)
			=> (int)self.value;

		static Float32 IConvertable<Int64, Float32>.Convert(Int64 self)
			=> self.value;

		static Float64 IConvertable<Int64, Float64>.Convert(Int64 self)
			=> self.value;

		#endregion
	}
}
