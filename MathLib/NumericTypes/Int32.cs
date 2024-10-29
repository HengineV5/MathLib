
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
		int value;

		public static ScalarType Type => ScalarType.Integer;

		public static Int32 One => 1;

		public static Int32 Zero => 0;

		public static Int32 Two => 4;

		public static int Size => 4;

		public Int32(int value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static Int32 operator +(Int32 value)
			=> value.value;

		public static Int32 operator +(Int32 left, Int32 right)
			=> left.value + right.value;

		public static Int32 operator -(Int32 value)
			=> -value.value;

		public static Int32 operator -(Int32 left, Int32 right)
			=> left.value - right.value;

		public static Int32 operator ++(Int32 value)
			=> value.value++;

		public static Int32 operator --(Int32 value)
			=> value.value--;

		public static Int32 operator *(Int32 left, Int32 right)
			=> left.value * right.value;

		public static Int32 operator /(Int32 left, Int32 right)
			=> left.value / right.value;

		public static bool operator ==(Int32 left, Int32 right)
			=> left.value == right.value;

		public static bool operator !=(Int32 left, Int32 right)
			=> left.value != right.value;

		public static implicit operator int(Int32 i) => i.value;
		public static implicit operator Int32(int i) => new Int32(i);

		public static Int32 Abs(Int32 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(Int32 self, Int32 num)
		{
			throw new NotImplementedException();
		}

		public static Int32 FromInteger(int number)
			=> new(number);

		public static Int32 FromInteger(uint number)
			=> new((int)number);

		#region Unit conversions

		static UInt8 IConvertable<Int32, UInt8>.Convert(Int32 self)
			=> (byte)self.value;

		static UInt16 IConvertable<Int32, UInt16>.Convert(Int32 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<Int32, UInt32>.Convert(Int32 self)
			=> (uint)self.value;

		static UInt64 IConvertable<Int32, UInt64>.Convert(Int32 self)
			=> (ulong)self.value;

		static Int16 IConvertable<Int32, Int16>.Convert(Int32 self)
			=> (short)self.value;

		static Int64 IConvertable<Int32, Int64>.Convert(Int32 self)
			=> self.value;

		static Float32 IConvertable<Int32, Float32>.Convert(Int32 self)
			=> self.value;

		static Float64 IConvertable<Int32, Float64>.Convert(Int32 self)
			=> self.value;

		#endregion
	}
}
